using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Calculators;
using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using MBusParserCS.PostProcessing.Interfaces;
using System.Security.Cryptography;

namespace MBusParserCS.PostProcessing
{
    internal class WirelessMbusDataConteiner : IWirelessMbusDataConteiner
    {
        private static WirelessMbusDataConteiner? instance;

        public static WirelessMbusDataConteiner GetCalculator()
        {
            if (instance == null)
            {
                instance = new WirelessMbusDataConteiner();
            }
            return instance;
        }

        private WirelessMbusDataConteiner()
        {
        }

        public void Process(ref ParserMessage parserMessage, ref List<Byte> key)
        {
            DataRecord? wirelessMbusDataContainer =
                parserMessage.Datagram.DataRecords.Find(x => x.Dib.DataType == DibDataType.DataVariableLength &&
                                                        x.Vib?.DataType == VibDataType.WirelessMbusDataContainer);

            if (wirelessMbusDataContainer == null || wirelessMbusDataContainer.Data.Count < 12)
            {
                return;
            }

            Queue<Byte> lvarWithoutLength = new(wirelessMbusDataContainer.Data.Skip(1));
            wirelessMbusDataContainer.TextValue = lvarWithoutLength.ToHexString();

            lvarWithoutLength.Dequeue(); // remove L field
            Byte cField = lvarWithoutLength.Dequeue();
            Byte[] manufacturer = new Byte[] { lvarWithoutLength.Dequeue(), lvarWithoutLength.Dequeue() };
            Byte[] identificationNumber = new Byte[] { lvarWithoutLength.Dequeue(), lvarWithoutLength.Dequeue(), lvarWithoutLength.Dequeue(), lvarWithoutLength.Dequeue() };
            Byte version = lvarWithoutLength.Dequeue();
            Byte deviceType = lvarWithoutLength.Dequeue();
            Byte ciField = lvarWithoutLength.Dequeue();

            Information information = new Information()
            {
                CField = cField,
                PrimaryAddress = null,
                CiField = ciField,
                DecryptionStatus = DecryptionStatus.NotEncrypted,
            };

            IExtendedLinkLayerCalculator extendedLinkLayerCalculator = ExtendedLinkLayerCalculator.GetCalculator();
            ExtendedLinkLayerMessage extendedLinkLayerMessage = extendedLinkLayerCalculator.CalculateExtendedLinkLayer(ciField, ref lvarWithoutLength);

            if (extendedLinkLayerMessage.IsError)
            {
                return;
            }

            if (extendedLinkLayerMessage.ExtendedLinkLayer.Type != ExtendedLinkLayerType.None)
            {
                if (!lvarWithoutLength.Any())
                {
                    return;
                }

                information.CiField = lvarWithoutLength.Dequeue();
            }

            IHeaderCalculator headerCalculator = HeaderCalculator.GetCalculator();

            HeaderMessage headerMessage = headerCalculator.CalculateHeader(information.CiField, ref lvarWithoutLength);

            if (headerMessage.IsError)
            {
                return;
            }

            if (headerMessage.Header.HeaderType == HeaderType.None)
            {
                return;
            }
            else if (headerMessage.Header.HeaderType == HeaderType.Short)
            {
                headerMessage.Header.IdentificationNumber = identificationNumber;
                headerMessage.Header.Manufacturer = manufacturer;
                headerMessage.Header.Version = version;
                headerMessage.Header.DeviceType = deviceType;
            }

            if (lvarWithoutLength.Count < 2 || (lvarWithoutLength.Count % 16) != 0)
            {
                return;
            }

            if (headerMessage.Header.Encryption == EncryptionMethod.AesCbcIvNonZero &&
                lvarWithoutLength.ElementAt(0) != 0x2F &&
                lvarWithoutLength.ElementAt(1) != 0x2F)
            {
                information.DecryptionStatus = DecryptionStatus.Encrypted;

                if (key.Count == 16)
                {
                    Byte[] iv = new Byte[16];
                    iv[0] = manufacturer[0];
                    iv[1] = manufacturer[1];
                    iv[2] = identificationNumber[0];
                    iv[3] = identificationNumber[1];
                    iv[4] = identificationNumber[2];
                    iv[5] = identificationNumber[3];
                    iv[6] = version;
                    iv[7] = deviceType;

                    for (Byte n = 8; n < 16; n++)
                    {
                        iv[n] = headerMessage.Header.AccessNumber ?? 0;
                    }

                    using (Aes aes = Aes.Create())
                    {
                        aes.KeySize = 128;
                        aes.Mode = CipherMode.CBC;
                        aes.BlockSize = 128;
                        aes.Padding = PaddingMode.None;
                        aes.Key = key.ToArray();
                        aes.IV = iv;

                        Byte[] decodedBytes = new Byte[lvarWithoutLength.Count];
                        ICryptoTransform transform = aes.CreateDecryptor();
                        using (MemoryStream stream = new(lvarWithoutLength.ToArray()))
                        {
                            using (CryptoStream cryptoStream = new(stream, transform, CryptoStreamMode.Read))
                            {
                                cryptoStream.Read(decodedBytes, 0, decodedBytes.Count());
                            }
                        }

                        lvarWithoutLength = new(decodedBytes);
                    }
                }
            }

            List<DataRecord> dataRecords = new();

            if (lvarWithoutLength.Count >= 2F && lvarWithoutLength.ElementAt(0) == 0x2F && lvarWithoutLength.ElementAt(1) == 0x2F)
            {
                information.DecryptionStatus = DecryptionStatus.Decrypted;

                Byte lastRecordNumber = parserMessage.Datagram.DataRecords.Max(x => x.RecordNumber);

                IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();

                while (lvarWithoutLength.Count > 0)
                {
                    DataRecordCalculatorMessage dataRecordCalculatorMessage = dataRecordCalculator.CalculateDataRecord(ref lvarWithoutLength, headerMessage.Header.Manufacturer);
                    if (dataRecordCalculatorMessage.IsError)
                    {
                        return;
                    }

                    if (dataRecordCalculatorMessage.ShouldProcess)
                    {
                        lastRecordNumber += 1;
                        DataRecord dataRecord = dataRecordCalculatorMessage.DataRecord;
                        dataRecord.RecordNumber = lastRecordNumber;
                        dataRecords.Add(dataRecord);
                    }
                }

                // Compact profile procedure
                ICompactProfileCalculator compactProfileCalculator = CompactProfileCalculator.GetCalculator();
                compactProfileCalculator.CalculateCompactProfile(ref dataRecords);
                // ---
            }

            parserMessage.Datagram.DataRecords.AddRange(dataRecords);
            parserMessage.Datagram.Information.DecryptionStatus = information.DecryptionStatus;
            parserMessage.Datagram.Header.Encryption = headerMessage.Header.Encryption;

            return;
        }
    }
}