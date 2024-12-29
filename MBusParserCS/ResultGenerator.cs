using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS
{
    internal sealed class ResultGenerator : IResultGenerator
    {
        private static ResultGenerator? instance;

        public static ResultGenerator GetGenerator()
        {
            if (instance == null)
            {
                instance = new ResultGenerator();
            }
            return instance;
        }

        private ResultGenerator()
        {
        }

        public Result GenerateResult(ref ParserMessage parserMessage)
        {
            Result result = new();

            if (parserMessage.IsError)
            {
                result.Error = parserMessage.GetErrorDescriptions();
                return result;
            }

            InformationResult informationResult = new();
            informationResult.CField = parserMessage.Datagram.Information.CField.ToHexString();
            informationResult.PrimaryAddress = parserMessage.Datagram.Information.PrimaryAddress;
            informationResult.CiField = parserMessage.Datagram.Information.CiField.ToHexString();
            informationResult.DecryptionStatus = parserMessage.Datagram.Information.DecryptionStatus.DecryptionStatusToString();

            HeaderResult headerResult = new();
            if (parserMessage.Datagram.Header.IdentificationNumber == null)
            {
                result.Error = "Header identification number is null";
                return result;
            }
            headerResult.IdentificationNumber = (UInt32)parserMessage.Datagram.Header.IdentificationNumber.BCDToUIt64();
            if (parserMessage.Datagram.Header.Manufacturer == null)
            {
                result.Error = "Header manufacturer is null";
                return result;
            }
            headerResult.Manufacturer = parserMessage.Datagram.Header.Manufacturer.ManufacturerToString();
            if (parserMessage.Datagram.Header.Version == null)
            {
                result.Error = "Header version is null";
                return result;
            }
            headerResult.Version = (Byte)parserMessage.Datagram.Header.Version;
            if (parserMessage.Datagram.Header.DeviceType == null)
            {
                result.Error = "Header device type is null";
                return result;
            }
            headerResult.DeviceType = (Byte)parserMessage.Datagram.Header.DeviceType;
            headerResult.DeviceTypeHum = headerResult.DeviceType.DeviceTypeToString();
            if (parserMessage.Datagram.Header.AccessNumber == null)
            {
                result.Error = "Header access number is null";
                return result;
            }
            headerResult.AccessNumber = (Byte)parserMessage.Datagram.Header.AccessNumber;
            if (parserMessage.Datagram.Header.Status == null)
            {
                result.Error = "Header status is null";
                return result;
            }
            headerResult.Status = ((Byte)(parserMessage.Datagram.Header.Status)).StatusToString();
            if (parserMessage.Datagram.Header.Configuration == null)
            {
                result.Error = "Header configuration is null";
                return result;
            }
            headerResult.Configuration = parserMessage.Datagram.Header.Configuration.ToHexString();
            if (parserMessage.Datagram.Header.Encryption == null)
            {
                result.Error = "Header encryption is null";
                return result;
            }
            headerResult.Encryption = ((EncryptionMethod)parserMessage.Datagram.Header.Encryption).EncryptionToString();

            List<DataRecordResult> dataRecords = new();
            foreach (DataRecord dataRecord in parserMessage.Datagram.DataRecords)
            {
                DibResult dibResult = new()
                {
                    DifByte = dataRecord.Dib.DifByte.ToHexString(),
                    DifeBytes = (dataRecord.Dib.DifeBytes == null || !dataRecord.Dib.DifeBytes.Any()) ? null : dataRecord.Dib.DifeBytes.ToHexString(),
                    StorageNumber = dataRecord.Dib.StorageNumber,
                    Tariff = dataRecord.Dib.Tariff,
                    Subunit = dataRecord.Dib.Subunit,
                    FunctionField = dataRecord.Dib.FunctionField?.DibFunctionFieldToString(),
                    DataType = dataRecord.Dib.DataType.DibDataTypeToString(),
                };

                VibResult vibResult = new();
                if (dataRecord.Vib != null)
                {
                    vibResult.VifByte = dataRecord.Vib.VifByte.ToHexString();
                    vibResult.VifeBytes = (dataRecord.Vib.VifeBytes == null || !dataRecord.Vib.VifeBytes.Any()) ? null : dataRecord.Vib.VifeBytes.ToHexString();
                    vibResult.Unit = String.IsNullOrEmpty(dataRecord.Vib.Unit) ? null : dataRecord.Vib.Unit;
                    vibResult.Description = String.IsNullOrEmpty(dataRecord.Vib.Description) ? null : dataRecord.Vib.Description;
                }

                DataRecordResult dataRecordResult = new()
                {
                    RecordNumber = dataRecord.RecordNumber,
                    Dib = dibResult,
                    Vib = dataRecord.Vib == null ? null : vibResult,
                    Data = dataRecord.Data.Any() ? dataRecord.Data.ToHexString() : null,
                    NumericValue = dataRecord.NumericValue,
                    TextValue = String.IsNullOrEmpty(dataRecord.TextValue) ? null : dataRecord.TextValue,
                    Comment = String.IsNullOrEmpty(dataRecord.Comment) ? null : dataRecord.Comment,
                };

                dataRecords.Add(dataRecordResult);
            }

            DatagramResult datagramResult = new()
            {
                Information = informationResult,
                Header = headerResult,
                DataRecords = dataRecords,
            };

            result.Datagram = datagramResult;

            return result;
        }
    }

    internal static class ResultExt
    {
        public static String DecryptionStatusToString(this DecryptionStatus decryptionStatus)
        {
            return decryptionStatus switch
            {
                DecryptionStatus.NotEncrypted => "Not encrypted",
                DecryptionStatus.Encrypted => "Encrypted",
                DecryptionStatus.Decrypted => "Decrypted",
                _ => "Unknown"
            };
        }

        public static String EncryptionToString(this EncryptionMethod encryptionMethod)
        {
            return encryptionMethod switch
            {
                EncryptionMethod.None => "None",
                EncryptionMethod.Reserved1 => "Reserved",
                EncryptionMethod.DesCbcIvZero => "DES CBC with zero IV",
                EncryptionMethod.DesCbcIvNonZero => "DES CBC with non zero IV",
                EncryptionMethod.Reserved0x04 => "Reserved 0x04",
                EncryptionMethod.AesCbcIvNonZero => "AES CBC with non zero IV",
                EncryptionMethod.Reserved0x06 => "Reserved 0x06",
                EncryptionMethod.Reserved0x07 => "Reserved 0x07",
                EncryptionMethod.Reserved0x08 => "Reserved 0x08",
                EncryptionMethod.Reserved0x09 => "Reserved 0x09",
                EncryptionMethod.Reserved0x0A => "Reserved 0x0A",
                EncryptionMethod.Reserved0x0B => "Reserved 0x0B",
                EncryptionMethod.Reserved0x0C => "Reserved 0x0C",
                EncryptionMethod.Reserved0x0D => "Reserved 0x0D",
                EncryptionMethod.Reserved0x0E => "Reserved 0x0E",
                EncryptionMethod.Reserved0x0F => "Reserved 0x0F",
                EncryptionMethod.Unknown => "Unknown",
                _ => "Unknown",
            };
        }

        public static String ManufacturerToString(this IEnumerable<Byte> manufacturerBytes)
        {
            Byte[] dataBytes = manufacturerBytes.ToArray();
            UInt16 manufacturer = BitConverter.ToUInt16(dataBytes, 0);

            Char[] chr = new Char[3];

            for (Int32 i = chr.Length - 1; i >= 0; i--)
            {
                chr[i] = Convert.ToChar((manufacturer % 32) + 64);
                manufacturer = (UInt16)((manufacturer - (manufacturer % 32)) / 32);
            }

            return new String(chr);
        }

        public static String DeviceTypeToString(this Byte deviceType)
        {
            return deviceType switch
            {
                0x00 => "Other",
                0x01 => "Oil meter",
                0x02 => "Electricity meter",
                0x03 => "Gas meter",
                0x04 => "Heat meter",
                0x05 => "Steam meter",
                0x06 => "Warm water meter",
                0x07 => "Water meter",
                0x08 => "Heat cost allocator",
                0x09 => "Compressed air",
                0x0A => "Cooling meter (volume measured at return temperature: outlet",
                0x0B => "Cooling meter (Volume measured at flow temperature: inlet)",
                0x0C => "Heat meter (volume measured at flow temperature: inlet",
                0x0D => "Combined heat/cooling meter",
                0x0E => "Bus/system component",
                0x0F => "Unknown device type",
                0x10 => "Reserved for consumption meter 10h",
                0x11 => "Reserved for consumption meter 11h",
                0x12 => "Reserved for consumption meter 12h",
                0x13 => "Reserved for consumption meter 13h",
                0x14 => "Calorific value",
                0x15 => "Hot water meter",
                0x16 => "Cold water meter",
                0x17 => "Dual register hot/cold water meter",
                0x18 => "Pressure meter",
                0x19 => "A/D converter",
                0x1A => "Smoke detector",
                0x1B => "Room sensor",
                0x1C => "Gas detector",
                0x1D => "Reserved for sensors 1Dh",
                0x1E => "Reserved for sensors 1Eh",
                0x1F => "Reserved for sensors 1Fh",
                0x20 => "Breaker (electricity)",
                0x21 => "Valve (gas or water)",
                0x22 => "Reserved for switching devices 22h",
                0x23 => "Reserved for switching devices 23h",
                0x24 => "Reserved for switching devices 24h",
                0x25 => "Customer unit (display device)",
                0x26 => "Reserved for customer units 26h",
                0x27 => "Reserved for customer units 27h",
                0x28 => "Waste water meter",
                0x29 => "Garbage",
                0x2A => "Carbon dioxide",
                0x2B => "Reserved for environmental meter 2Bh",
                0x2C => "Reserved for environmental meter 2Ch",
                0x2D => "Reserved for environmental meter 2Dh",
                0x2E => "Reserved for environmental meter 2Eh",
                0x2F => "Reserved for environmental meter 2Fh",
                0x30 => "Reserved for system devices 30h",
                0x31 => "Communication controler (gateway)",
                0x32 => "Unidirectional repeater",
                0x33 => "Bidirectional repeater",
                0x34 => "Reserved for system devices 34h",
                0x35 => "Reserved for system devices 35h",
                0x36 => "Radio converter (system side)",
                0x37 => "Radio converter (meter side)",
                0x38 => "Reserved for system devices 38h",
                0x39 => "Reserved for system devices 39h",
                0x3A => "Reserved for system devices 3Ah",
                0x3B => "Reserved for system devices 3Bh",
                0x3C => "Reserved for system devices 3Ch",
                0x3D => "Reserved for system devices 3Dh",
                0x3E => "Reserved for system devices 3Eh",
                0x3F => "Reserved for system devices 3Fh",
                0x40 => "Reserved 40h",
                0x41 => "Reserved 41h",
                0x42 => "Reserved 42h",
                0x43 => "Reserved 43h",
                0x44 => "Reserved 44h",
                0x45 => "Reserved 45h",
                0x46 => "Reserved 46h",
                0x47 => "Reserved 47h",
                0x48 => "Reserved 48h",
                0x49 => "Reserved 49h",
                0x4A => "Reserved 4Ah",
                0x4B => "Reserved 4Bh",
                0x4C => "Reserved 4Ch",
                0x4D => "Reserved 4Dh",
                0x4E => "Reserved 4Eh",
                0x4F => "Reserved 4Fh",
                0x50 => "Reserved 50h",
                0x51 => "Reserved 51h",
                0x52 => "Reserved 52h",
                0x53 => "Reserved 53h",
                0x54 => "Reserved 54h",
                0x55 => "Reserved 55h",
                0x56 => "Reserved 56h",
                0x57 => "Reserved 57h",
                0x58 => "Reserved 58h",
                0x59 => "Reserved 59h",
                0x5A => "Reserved 5Ah",
                0x5B => "Reserved 5Bh",
                0x5C => "Reserved 5Ch",
                0x5D => "Reserved 5Dh",
                0x5E => "Reserved 5Eh",
                0x5F => "Reserved 5Fh",
                0x60 => "Reserved 60h",
                0x61 => "Reserved 61h",
                0x62 => "Reserved 62h",
                0x63 => "Reserved 63h",
                0x64 => "Reserved 64h",
                0x65 => "Reserved 65h",
                0x66 => "Reserved 66h",
                0x67 => "Reserved 67h",
                0x68 => "Reserved 68h",
                0x69 => "Reserved 69h",
                0x6A => "Reserved 6Ah",
                0x6B => "Reserved 6Bh",
                0x6C => "Reserved 6Ch",
                0x6D => "Reserved 6Dh",
                0x6E => "Reserved 6Eh",
                0x6F => "Reserved 6Fh",
                0x70 => "Reserved 70h",
                0x71 => "Reserved 71h",
                0x72 => "Reserved 72h",
                0x73 => "Reserved 73h",
                0x74 => "Reserved 74h",
                0x75 => "Reserved 75h",
                0x76 => "Reserved 76h",
                0x77 => "Reserved 77h",
                0x78 => "Reserved 78h",
                0x79 => "Reserved 79h",
                0x7A => "Reserved 7Ah",
                0x7B => "Reserved 7Bh",
                0x7C => "Reserved 7Ch",
                0x7D => "Reserved 7Dh",
                0x7E => "Reserved 7Eh",
                0x7F => "Reserved 7Fh",
                0x80 => "Reserved 80h",
                0x81 => "Reserved 81h",
                0x82 => "Reserved 82h",
                0x83 => "Reserved 83h",
                0x84 => "Reserved 84h",
                0x85 => "Reserved 85h",
                0x86 => "Reserved 86h",
                0x87 => "Reserved 87h",
                0x88 => "Reserved 88h",
                0x89 => "Reserved 89h",
                0x8A => "Reserved 8Ah",
                0x8B => "Reserved 8Bh",
                0x8C => "Reserved 8Ch",
                0x8D => "Reserved 8Dh",
                0x8E => "Reserved 8Eh",
                0x8F => "Reserved 8Fh",
                0x90 => "Reserved 90h",
                0x91 => "Reserved 91h",
                0x92 => "Reserved 92h",
                0x93 => "Reserved 93h",
                0x94 => "Reserved 94h",
                0x95 => "Reserved 95h",
                0x96 => "Reserved 96h",
                0x97 => "Reserved 97h",
                0x98 => "Reserved 98h",
                0x99 => "Reserved 99h",
                0x9A => "Reserved 9Ah",
                0x9B => "Reserved 9Bh",
                0x9C => "Reserved 9Ch",
                0x9D => "Reserved 9Dh",
                0x9E => "Reserved 9Eh",
                0x9F => "Reserved A0h",
                0xA1 => "Reserved A1h",
                0xA2 => "Reserved A2h",
                0xA3 => "Reserved A3h",
                0xA4 => "Reserved A4h",
                0xA5 => "Reserved A5h",
                0xA6 => "Reserved A6h",
                0xA7 => "Reserved A7h",
                0xA8 => "Reserved A8h",
                0xA9 => "Reserved A9h",
                0xAA => "Reserved AAh",
                0xAB => "Reserved ABh",
                0xAC => "Reserved ACh",
                0xAD => "Reserved ADh",
                0xAE => "Reserved AEh",
                0xAF => "Reserved AFh",
                0xB0 => "Reserved B0h",
                0xB1 => "Reserved B1h",
                0xB2 => "Reserved B2h",
                0xB3 => "Reserved B3h",
                0xB4 => "Reserved B4h",
                0xB5 => "Reserved B5h",
                0xB6 => "Reserved B6h",
                0xB7 => "Reserved B7h",
                0xB8 => "Reserved B8h",
                0xB9 => "Reserved B9h",
                0xBA => "Reserved BAh",
                0xBB => "Reserved BBh",
                0xBC => "Reserved BCh",
                0xBD => "Reserved BDh",
                0xBE => "Reserved BEh",
                0xBF => "Reserved BFh",
                0xC0 => "Reserved C0h",
                0xC1 => "Reserved C1h",
                0xC2 => "Reserved C2h",
                0xC3 => "Reserved C3h",
                0xC4 => "Reserved C4h",
                0xC5 => "Reserved C5h",
                0xC6 => "Reserved C6h",
                0xC7 => "Reserved C7h",
                0xC8 => "Reserved C8h",
                0xC9 => "Reserved C9h",
                0xCA => "Reserved CAh",
                0xCB => "Reserved CBh",
                0xCC => "Reserved CCh",
                0xCD => "Reserved CDh",
                0xCE => "Reserved CEh",
                0xCF => "Reserved CFh",
                0xD0 => "Reserved D0h",
                0xD1 => "Reserved D1h",
                0xD2 => "Reserved D2h",
                0xD3 => "Reserved D3h",
                0xD4 => "Reserved D4h",
                0xD5 => "Reserved D5h",
                0xD6 => "Reserved D6h",
                0xD7 => "Reserved D7h",
                0xD8 => "Reserved D8h",
                0xD9 => "Reserved D9h",
                0xDA => "Reserved DAh",
                0xDB => "Reserved DBh",
                0xDC => "Reserved DCh",
                0xDD => "Reserved DDh",
                0xDE => "Reserved DEh",
                0xDF => "Reserved DFh",
                0xE0 => "Reserved E0h",
                0xE1 => "Reserved E1h",
                0xE2 => "Reserved E2h",
                0xE3 => "Reserved E3h",
                0xE4 => "Reserved E4h",
                0xE5 => "Reserved E5h",
                0xE6 => "Reserved E6h",
                0xE7 => "Reserved E7h",
                0xE8 => "Reserved E8h",
                0xE9 => "Reserved E9h",
                0xEA => "Reserved EAh",
                0xEB => "Reserved EBh",
                0xEC => "Reserved ECh",
                0xED => "Reserved EDh",
                0xEE => "Reserved EEh",
                0xEF => "Reserved EFh",
                0xF0 => "Reserved F0h",
                0xF1 => "Reserved F1h",
                0xF2 => "Reserved F2h",
                0xF3 => "Reserved F3h",
                0xF4 => "Reserved F4h",
                0xF5 => "Reserved F5h",
                0xF6 => "Reserved F6h",
                0xF7 => "Reserved F7h",
                0xF8 => "Reserved F8h",
                0xF9 => "Reserved F9h",
                0xFA => "Reserved FAh",
                0xFB => "Reserved FBh",
                0xFC => "Reserved FCh",
                0xFD => "Reserved FDh",
                0xFE => "Reserved FEh",
                0xFF => "Reserved FFh",
                _ => "Unknown",
            };
        }

        public static String StatusToString(this Byte statusByte)
        {
            String status = String.Empty;

            Boolean bit0 = (Byte)((statusByte >> 0) & 0x01) == 1;
            Boolean bit1 = (Byte)((statusByte >> 1) & 0x01) == 1;
            Boolean bit2 = (Byte)((statusByte >> 2) & 0x01) == 1;
            Boolean bit3 = (Byte)((statusByte >> 3) & 0x01) == 1;
            Boolean bit4 = (Byte)((statusByte >> 4) & 0x01) == 1;
            Boolean bit5 = (Byte)((statusByte >> 5) & 0x01) == 1;
            Boolean bit6 = (Byte)((statusByte >> 6) & 0x01) == 1;
            Boolean bit7 = (Byte)((statusByte >> 7) & 0x01) == 1;

            if (!bit1 && !bit0)
            {
                status = status + "[No error] ";
            }

            if (!bit1 && bit0)
            {
                status = status + "[Application busy] ";
            }

            if (bit1 && !bit0)
            {
                status = status + "[Any application error] ";
            }

            if (bit1 && bit0)
            {
                status = status + "[Abnormal condition / alarm] ";
            }

            if (bit2)
            {
                status = status + "[Power low] ";
            }

            if (bit3)
            {
                status = status + "[Permanent error] ";
            }

            if (bit4)
            {
                status = status + "[Temporary error] ";
            }

            if (bit5)
            {
                status = status + "[Specific to manufacturer bit 5] ";
            }

            if (bit6)
            {
                status = status + "[Specific to manufacturer bit 6] ";
            }

            if (bit7)
            {
                status = status + "[Specific to manufacturer bit 7] ";
            }

            return status.Trim();
        }

        public static String DibFunctionFieldToString(this DibFunctionField dibFunctionField)
        {
            return dibFunctionField switch
            {
                DibFunctionField.Instantaneous => "Instantaneous",
                DibFunctionField.Maximum => "Maximum",
                DibFunctionField.Minimum => "Minimum",
                DibFunctionField.ValueDuringError => "Value during error state",
                _ => "Unknown",
            };
        }

        public static String DibDataTypeToString(this DibDataType dibDataType)
        {
            return dibDataType switch
            {
                DibDataType.NoData => "No data",
                DibDataType.Data8BitInteger => "8 bit integer",
                DibDataType.Data16BitInteger => "16 bit integer",
                DibDataType.Data24BitInteger => "24 bit integer",
                DibDataType.Data32BitInteger => "32 bit integer",
                DibDataType.Data32BitReal => "32 bit real",
                DibDataType.Data48BitInteger => "48 bit integer",
                DibDataType.Data64BitInteger => "64 bit integer",
                DibDataType.SelectionForReadout => "Selection for readout",
                DibDataType.Data2DigitBCD => "2 digit BCD",
                DibDataType.Data4DigitBCD => "4 digit BCD",
                DibDataType.Data6DigitBCD => "6 digit BCD",
                DibDataType.Data8DigitBCD => "8 digit BCD",
                DibDataType.DataVariableLength => "Variable length",
                DibDataType.Data12DigitBCD => "12 digit BCD",
                DibDataType.SpecialFunctionManufacturerSpecific => "Manufacturer specific data",
                DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram => "Manufacturer specific data, more data in next datagram",
                DibDataType.SpecialFunctionIdleFilter => "Idle filter",
                DibDataType.SpecialFunctionReserved0x3F => "Reserved 0x3F",
                DibDataType.SpecialFunctionReserved0x4F => "Reserved 0x4F",
                DibDataType.SpecialFunctionReserved0x5F => "Reserved 0x5F",
                DibDataType.SpecialFunctionReserved0x6F => "Reserved 0x6F",
                DibDataType.SpecialFunctionGlobalReadout => "Global readout",
                _ => "Unknown",
            };
        }
    }
}
