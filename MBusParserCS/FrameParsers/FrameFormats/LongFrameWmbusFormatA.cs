using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Calculators;
using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using System.Security.Cryptography;

namespace MBusParserCS.FrameParsers
{
    internal sealed partial class FrameFormatSelector
    {
        public ParserMessage LongFrameWMBusFormatA(ref Queue<Byte> data, ref List<Byte> key)
        {
            ParserMessage parserMessage = new();

            if (data.Count < 13)
            {
                parserMessage.AddErrorCode(ErrorCode.LongFrameWmbusAError);
                return parserMessage;
            }

            data.Dequeue(); // remove L field
            Byte cField = data.Dequeue();
            Byte[] manufacturer = new Byte[]{ data.Dequeue(), data.Dequeue() };
            Byte[] identificationNumber = new Byte[] { data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue() };
            Byte version = data.Dequeue();
            Byte deviceType = data.Dequeue();
            data.DequeueChunk(2); // remove CRC
            Byte ciField = data.Dequeue();

            Information information = new Information()
            {
                CField = cField,
                PrimaryAddress = null,
                CiField = ciField,
                DecryptionStatus = DecryptionStatus.NotEncrypted,
            };

            IExtendedLinkLayerCalculator extendedLinkLayerCalculator = ExtendedLinkLayerCalculator.GetCalculator();
            ExtendedLinkLayerMessage extendedLinkLayerMessage = extendedLinkLayerCalculator.CalculateExtendedLinkLayer(ciField, ref data);

            if (extendedLinkLayerMessage.IsError)
            {
                parserMessage.AddErrors(extendedLinkLayerMessage.Errors);
                return parserMessage;
            }

            if (extendedLinkLayerMessage.ExtendedLinkLayer.Type != ExtendedLinkLayerType.None)
            {
                if (!data.Any())
                {
                    parserMessage.AddErrorCode(ErrorCode.LongFrameWmbusAError);
                    return parserMessage;
                }

                information.CiField = data.Dequeue();
            }

            IHeaderCalculator headerCalculator = HeaderCalculator.GetCalculator();

            HeaderMessage headerMessage = headerCalculator.CalculateHeader(information.CiField, ref data);

            if (headerMessage.IsError)
            {
                parserMessage.AddErrors(headerMessage.Errors);
                return parserMessage;
            }

            if (headerMessage.Header.HeaderType == HeaderType.None)
            {
                parserMessage.AddErrorCode(ErrorCode.LongFrameWmbusAError);
                return parserMessage;
            }
            else if (headerMessage.Header.HeaderType == HeaderType.Short)
            {
                headerMessage.Header.IdentificationNumber = identificationNumber;
                headerMessage.Header.Manufacturer = manufacturer;
                headerMessage.Header.Version = version;
                headerMessage.Header.DeviceType = deviceType;
            }

            Queue<Byte> applicationLayer = new();
            applicationLayer.EnqueueChunk(Enumerable.Repeat((Byte)0x00, headerCalculator.GetHeaderLength(headerMessage.Header.HeaderType) + 1)); // add zeroed ci field and header
            
            if (extendedLinkLayerMessage.ExtendedLinkLayer.Type != ExtendedLinkLayerType.None)
            {
                applicationLayer.EnqueueChunk(Enumerable.Repeat((Byte)0x00, extendedLinkLayerMessage.ExtendedLinkLayer.Length + 1)); // add zeroed ci field and extended link layer
            }

            applicationLayer.EnqueueChunk(data);
            data.Clear();

            while (applicationLayer.Count >= 18)
            {
                data.EnqueueChunk(applicationLayer.DequeueChunk(16));
                applicationLayer.DequeueChunk(2); // remove crc
            }

            if (applicationLayer.Count > 2)
            {
                applicationLayer.RemoveBack(2); // remove crc
                data.EnqueueChunk(applicationLayer);
            }

            data.DequeueChunk(headerCalculator.GetHeaderLength(headerMessage.Header.HeaderType) + 1); // remove zereoed ci field and header

            if (extendedLinkLayerMessage.ExtendedLinkLayer.Type != ExtendedLinkLayerType.None)
            {
                data.DequeueChunk(extendedLinkLayerMessage.ExtendedLinkLayer.Length + 1); // remove zereoed ci field and extended link layer
            }

            if (data.Count < 2 || (data.Count % 16) != 0)
            {
                parserMessage.AddErrorCode(ErrorCode.LongFrameWmbusAError);
                return parserMessage;
            }

            if (headerMessage.Header.Encryption == EncryptionMethod.AesCbcIvNonZero &&
                data.ElementAt(0) != 0x2F &&
                data.ElementAt(1) != 0x2F)
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

                        Byte[] decodedBytes = new Byte[data.Count];
                        ICryptoTransform transform = aes.CreateDecryptor();
                        using (MemoryStream stream = new(data.ToArray()))
                        {
                            using (CryptoStream cryptoStream = new(stream, transform, CryptoStreamMode.Read))
                            {
                                cryptoStream.Read(decodedBytes, 0, decodedBytes.Count());
                            }
                        }

                        data = new(decodedBytes);
                    }
                }
            }

            List<DataRecord> dataRecords = new();

            if (data.Count >= 2F && data.ElementAt(0) == 0x2F && data.ElementAt(1) == 0x2F)
            {
                information.DecryptionStatus = DecryptionStatus.Decrypted;

                Byte recordNumber = 0;

                IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();

                while (data.Count > 0)
                {
                    DataRecordCalculatorMessage dataRecordCalculatorMessage = dataRecordCalculator.CalculateDataRecord(ref data, headerMessage.Header.Manufacturer);
                    if (dataRecordCalculatorMessage.IsError)
                    {
                        parserMessage.AddErrors(dataRecordCalculatorMessage.Errors);
                        return parserMessage;
                    }

                    if (dataRecordCalculatorMessage.ShouldProcess)
                    {
                        recordNumber += 1;
                        DataRecord dataRecord = dataRecordCalculatorMessage.DataRecord;
                        dataRecord.RecordNumber = recordNumber;
                        dataRecords.Add(dataRecord);
                    }
                }

                // Compact profile procedure
                ICompactProfileCalculator compactProfileCalculator = CompactProfileCalculator.GetCalculator();
                compactProfileCalculator.CalculateCompactProfile(ref dataRecords);
                // ---
            }

            Datagram datagram = new()
            {
                Information = information,
                Header = headerMessage.Header,
                DataRecords = dataRecords,
            };

            parserMessage.SetDatagram(datagram);
            return parserMessage;
        }
    }
}