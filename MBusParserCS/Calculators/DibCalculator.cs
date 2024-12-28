using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators
{
    internal sealed class DibCalculator : IDibCalculator
    {
        private static DibCalculator? instance;

        public static DibCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new DibCalculator();
            }
            return instance;
        }

        private DibCalculator()
        {
        }

        public DibCalculatorMessage CalculateDib(ref Queue<Byte> data)
        {
            DibCalculatorMessage dibCalculatorMessage = new();

            if (data.Count < 1)
            {
                dibCalculatorMessage.AddErrorCode(ErrorCode.DibCalculatorError);
                return dibCalculatorMessage;
            }

            Byte difByte = data.Dequeue();
            DibDataType dataType = this.GetDibDataType(difByte);
            Byte dataLength = this.GetDataLength(dataType);

            Dib dib = new()
            {
                DifByte = difByte,
                ExtensionBit = false,
                StorageNumber = null,
                Tariff = null,
                Subunit = null,
                FunctionField = null,
                DataType = dataType,
                DataLength = dataLength,
            };

            if (dib.DataType == DibDataType.SpecialFunctionIdleFilter ||
                dib.DataType == DibDataType.SpecialFunctionManufacturerSpecific ||
                dib.DataType == DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram ||
                dib.DataType == DibDataType.SpecialFunctionReserved0x3F ||
                dib.DataType == DibDataType.SpecialFunctionReserved0x4F ||
                dib.DataType == DibDataType.SpecialFunctionReserved0x5F ||
                dib.DataType == DibDataType.SpecialFunctionReserved0x6F ||
                dib.DataType == DibDataType.SpecialFunctionGlobalReadout)
            {
                dibCalculatorMessage.SetDib(dib);
                return dibCalculatorMessage;
            }

            dib.FunctionField = this.GetFunctionField(dib.DifByte);
            dib.ExtensionBit = (dib.DifByte & 0x80) >> 7 == 1;
            dib.StorageNumber = (UInt32)((dib.DifByte & 0x40) >> 6);

            UInt32 storageNumber = (UInt32)dib.StorageNumber;
            UInt32 subunit = 0;
            UInt32 tariff = 0;
            Byte loopCount = 0;

            while (dib.ExtensionBit)
            {
                if (data.Count < 1)
                {
                    dibCalculatorMessage.AddErrorCode(ErrorCode.DibCalculatorError);
                    return dibCalculatorMessage;
                }

                Byte difeByte = data.Dequeue();
                dib.DifeBytes.Add(difeByte);
                dib.ExtensionBit = (difeByte & 0x80) >> 7 == 1;

                UInt32 subunitLoop = (UInt32)((difeByte & 0x40) >> 6);
                UInt32 teriffLoop = (UInt32)((difeByte & 0x30) >> 4);
                UInt32 storageNumberLoop = (UInt32)(difeByte & 0x0F);

                subunit |= subunitLoop << loopCount;
                tariff |= teriffLoop << (loopCount * 2);
                storageNumber |= storageNumberLoop << (loopCount * 4 + 1);

                loopCount++;
            }

            if (loopCount != 0)
            {
                dib.StorageNumber = storageNumber;
                dib.Subunit = subunit;
                dib.Tariff = tariff;
            }

            dibCalculatorMessage.SetDib(dib);
            return dibCalculatorMessage;
        }

        public DibDataType GetDibDataType(Byte dataTypeByte)
        {
            if ((dataTypeByte & 0x0F) == 0x0F)
            {
                switch (dataTypeByte)
                {
                    case 0x0F:
                        return DibDataType.SpecialFunctionManufacturerSpecific;
                    case 0x1F:
                        return DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram;
                    case 0x2F:
                        return DibDataType.SpecialFunctionIdleFilter;
                    case 0x3F:
                        return DibDataType.SpecialFunctionReserved0x3F;
                    case 0x4F:
                        return DibDataType.SpecialFunctionReserved0x4F;
                    case 0x5F:
                        return DibDataType.SpecialFunctionReserved0x5F;
                    case 0x6F:
                        return DibDataType.SpecialFunctionReserved0x6F;
                    case 0x7F:
                        return DibDataType.SpecialFunctionGlobalReadout;
                    default:
                        return DibDataType.Unknown;
                }
            }
            else
            {
                Byte maskedByte = (Byte)(dataTypeByte & 0x0F);

                switch (maskedByte)
                {
                    case 0x00:
                        return DibDataType.NoData;
                    case 0x01:
                        return DibDataType.Data8BitInteger;
                    case 0x02:
                        return DibDataType.Data16BitInteger;
                    case 0x03:
                        return DibDataType.Data24BitInteger;
                    case 0x04:
                        return DibDataType.Data32BitInteger;
                    case 0x05:
                        return DibDataType.Data32BitReal;
                    case 0x06:
                        return DibDataType.Data48BitInteger;
                    case 0x07:
                        return DibDataType.Data64BitInteger;
                    case 0x08:
                        return DibDataType.SelectionForReadout;
                    case 0x09:
                        return DibDataType.Data2DigitBCD;
                    case 0x0A:
                        return DibDataType.Data4DigitBCD;
                    case 0x0B:
                        return DibDataType.Data6DigitBCD;
                    case 0x0C:
                        return DibDataType.Data8DigitBCD;
                    case 0x0D:
                        return DibDataType.DataVariableLength;
                    case 0x0E:
                        return DibDataType.Data12DigitBCD;
                    default:
                        return DibDataType.Unknown;
                }
            }
        }

        public Byte GetDataLength(DibDataType dibDataType)
        {
            switch (dibDataType)
            {
                case DibDataType.NoData:
                    return 0;
                case DibDataType.Data8BitInteger:
                    return 1;
                case DibDataType.Data16BitInteger:
                    return 2;
                case DibDataType.Data24BitInteger:
                    return 3;
                case DibDataType.Data32BitInteger:
                    return 4;
                case DibDataType.Data32BitReal:
                    return 4;
                case DibDataType.Data48BitInteger:
                    return 6;
                case DibDataType.Data64BitInteger:
                    return 8;
                case DibDataType.SelectionForReadout:
                    return 0;
                case DibDataType.Data2DigitBCD:
                    return 1;
                case DibDataType.Data4DigitBCD:
                    return 2;
                case DibDataType.Data6DigitBCD:
                    return 3;
                case DibDataType.Data8DigitBCD:
                    return 4;
                case DibDataType.DataVariableLength:
                    return 1;
                case DibDataType.Data12DigitBCD:
                    return 6;
                case DibDataType.SpecialFunctionManufacturerSpecific:
                    return 0;
                case DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram:
                    return 0;
                case DibDataType.SpecialFunctionIdleFilter:
                    return 0;
                case DibDataType.SpecialFunctionReserved0x3F:
                    return 0;
                case DibDataType.SpecialFunctionReserved0x4F:
                    return 0;
                case DibDataType.SpecialFunctionReserved0x5F:
                    return 0;
                case DibDataType.SpecialFunctionReserved0x6F:
                    return 0;
                case DibDataType.SpecialFunctionGlobalReadout:
                    return 0;
                case DibDataType.Unknown:
                    return 0;
                default:
                    return 0;
            }
        }

        private DibFunctionField GetFunctionField(Byte functionFieldByte)
        {
            Byte maskedByte = (Byte)((functionFieldByte & 0x30) >> 4);

            switch (maskedByte)
            {
                case 0x00:
                    return DibFunctionField.Instantaneous;
                case 0x01:
                    return DibFunctionField.Maximum;
                case 0x02:
                    return DibFunctionField.Minimum;
                case 0x03:
                    return DibFunctionField.ValueDuringError;
                default:
                    return DibFunctionField.Unknown;
            }
        }
    }
}