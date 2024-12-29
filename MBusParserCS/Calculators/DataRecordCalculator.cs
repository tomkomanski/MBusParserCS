using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators
{
    internal sealed class DataRecordCalculator : IDataRecordCalculator
    {
        private static DataRecordCalculator? instance;

        public static DataRecordCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new DataRecordCalculator();
            }
            return instance;
        }

        private DataRecordCalculator()
        {
        }

        public DataRecordCalculatorMessage CalculateDataRecord (ref Queue<Byte> data, Byte[]? manufacturer)
        {
            DataRecordCalculatorMessage dataRecordCalculatorMessage = new();

            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage dibCalculatorMessage = dibCalculator.CalculateDib(ref data);

            if (dibCalculatorMessage.IsError)
            {
                dataRecordCalculatorMessage.AddErrors(dibCalculatorMessage.Errors);
                return dataRecordCalculatorMessage;
            }

            DataRecord dataRecord = new()
            {
                RecordNumber = 0,
                Dib = dibCalculatorMessage.Dib,
                Vib = null,
                NumericValue = null,
                TextValue = null,
                Comment = null,
            };

            if (dataRecord.Dib.DataType == DibDataType.SpecialFunctionIdleFilter)
            {
                dataRecordCalculatorMessage.ShouldProcess = false;
                return dataRecordCalculatorMessage;
            }

            if (dataRecord.Dib.DataType == DibDataType.SpecialFunctionManufacturerSpecific ||
                dataRecord.Dib.DataType == DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram ||
                dataRecord.Dib.DataType == DibDataType.SpecialFunctionReserved0x3F ||
                dataRecord.Dib.DataType == DibDataType.SpecialFunctionReserved0x4F ||
                dataRecord.Dib.DataType == DibDataType.SpecialFunctionReserved0x5F ||
                dataRecord.Dib.DataType == DibDataType.SpecialFunctionReserved0x6F ||
                dataRecord.Dib.DataType == DibDataType.SpecialFunctionGlobalReadout)
            {
                List<Byte> bytes = new(data.DequeueChunk(data.Count));
                String dataHex = bytes.ToHexString();

                dataRecord.Data = bytes;
                dataRecord.TextValue = dataHex;

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref data, ref manufacturer);

            if (vibCalculatorMessage.IsError)
            {
                dataRecordCalculatorMessage.AddErrors(vibCalculatorMessage.Errors);
                return dataRecordCalculatorMessage;
            }

            dataRecord.Vib = vibCalculatorMessage.Vib;

            if (data.Count < dataRecord.Dib.DataLength)
            {
                dataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                return dataRecordCalculatorMessage;
            }

            if (dataRecord.Dib.DataType == DibDataType.NoData || dataRecord.Dib.DataType == DibDataType.SelectionForReadout)
            {
                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            dataRecord.Data = new(data.DequeueChunk(dataRecord.Dib.DataLength));

            if (dataRecord.Vib.DataType == VibDataType.DataTypeG && dataRecord.Dib.DataType == DibDataType.Data16BitInteger)
            {
                if (dataRecord.Data[0] == 0xFF && dataRecord.Data[1] == 0xFF)
                {
                    dataRecord.Comment = (dataRecord.Comment + " " + "Invalid date value").Trim();
                }
                else
                {
                    Byte day = (Byte)(dataRecord.Data[0] & 0x1F);
                    Byte month = (Byte)(dataRecord.Data[1] & 0x0F);
                    UInt16 year = (UInt16)(((dataRecord.Data[0] & 0xE0) >> 5) | ((dataRecord.Data[1] & 0xF0) >> 1));
                    if  (year <= 80)
                    {
                        year += 2000;
                    }
                    else
                    {
                        year += 1900;
                    }

                    dataRecord.TextValue = $"{year}-{month:D2}-{day:D2}";
                }

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            if (dataRecord.Vib.DataType == VibDataType.DataTypeFJIM && dataRecord.Dib.DataType == DibDataType.Data24BitInteger)
            {
                //PN-EN 13757-3 2018
                if (dataRecord.Data[0] == 0xFF && dataRecord.Data[1] == 0xFF && dataRecord.Data[2] == 0xFF)
                {
                    dataRecord.Comment = (dataRecord.Comment + " " + "Invalid date value").Trim();
                }
                //PN-EN 13757-3 2013
                else if (dataRecord.Data[0] == 0x00 && dataRecord.Data[1] == 0x00 && dataRecord.Data[2] == 0x00)
                {
                    dataRecord.Comment = (dataRecord.Comment + " " + "Invalid date value").Trim();
                }
                else
                {
                    Byte second = (Byte)(dataRecord.Data[0] & 0x3F);
                    Byte minute = (Byte)(dataRecord.Data[1] & 0x3F);
                    Byte hour = (Byte)(dataRecord.Data[3] & 0x1F);

                    dataRecord.TextValue = $"{hour}:{minute:D2}-{second:D2}";
                }

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            if (dataRecord.Vib.DataType == VibDataType.DataTypeFJIM && dataRecord.Dib.DataType == DibDataType.Data32BitInteger)
            {
                Byte iv = (Byte)((dataRecord.Data[0] & 0x80) >> 7);

                if (iv == 1)
                {
                    dataRecord.Comment = (dataRecord.Comment + " " + "Invalid date value").Trim();
                }
                else
                {
                    Byte summerTimeTag = (Byte)((dataRecord.Data[1] & 0x80) >> 7);

                    if (summerTimeTag == 1)
                    {
                        dataRecord.Comment = (dataRecord.Comment + " " + "Summer time").Trim();
                    }

                    Byte minute = (Byte)(dataRecord.Data[0] & 0x3F);
                    Byte hour = (Byte)(dataRecord.Data[1] & 0x1F);
                    Byte day = (Byte)(dataRecord.Data[2] & 0x1F);
                    Byte month = (Byte)(dataRecord.Data[3] & 0x0F);
                    UInt16 year = (UInt16)(((dataRecord.Data[2] & 0xE0) >> 5) | ((dataRecord.Data[3] & 0xF0) >> 1));

                    if (year <= 80)
                    {
                        year += 2000;
                    }
                    else
                    {
                        UInt16 hundredYear = (UInt16)((dataRecord.Data[1] & 0x3F) >> 5);
                        year += (UInt16)(1900 + (100 * hundredYear));
                    }

                    dataRecord.TextValue = $"{year}-{month:D2}-{day:D2} {hour:D2}:{minute:D2}:{0:D2}";
                }

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            if (dataRecord.Vib.DataType == VibDataType.DataTypeFJIM && dataRecord.Dib.DataType == DibDataType.Data48BitInteger)
            {
                Byte iv = (Byte)((dataRecord.Data[0] & 0x80) >> 7);

                if (iv == 1)
                {
                    dataRecord.Comment = (dataRecord.Comment + " " + "Invalid date value").Trim();
                }
                else
                {
                    Byte summerTimeTag = (Byte)((dataRecord.Data[0] & 0x40) >> 6);

                    if (summerTimeTag == 1)
                    {
                        dataRecord.Comment = (dataRecord.Comment + " " + "Summer time").Trim();
                    }

                    Byte second = (Byte)(dataRecord.Data[0] & 0x3F);
                    Byte minute = (Byte)(dataRecord.Data[1] & 0x3F);
                    Byte hour = (Byte)(dataRecord.Data[2] & 0x1F);
                    Byte day = (Byte)(dataRecord.Data[3] & 0x1F);
                    Byte month = (Byte)(dataRecord.Data[4] & 0x0F);
                    UInt16 year = (UInt16)((((dataRecord.Data[3] & 0xE0) >> 5) | ((dataRecord.Data[4] & 0xF0) >> 1)) + 2000);

                    dataRecord.TextValue = $"{year}-{month:D2}-{day:D2} {hour:D2}:{minute:D2}:{second:D2}";
                }

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            if (dataRecord.Vib.DataType == VibDataType.DataTypeFJIM && dataRecord.Dib.DataType == DibDataType.DataVariableLength)
            {
                ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
                LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref data, dataRecord.Data[0]);

                if (lvarCalculatorMessage.IsError)
                {
                    dataRecordCalculatorMessage.AddErrors(lvarCalculatorMessage.Errors);
                    return dataRecordCalculatorMessage;
                }

                dataRecord.Data = lvarCalculatorMessage.Lvar.Data;
                dataRecord.NumericValue = lvarCalculatorMessage.Lvar.NumericValue;
                dataRecord.TextValue = lvarCalculatorMessage.Lvar.TextValue;

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            if ((dataRecord.Vib.DataType == null || dataRecord.Vib.DataType != VibDataType.DataTypeFJIM) && 
                dataRecord.Dib.DataType == DibDataType.DataVariableLength)
            {
                ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
                LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref data, dataRecord.Data[0]);

                if (lvarCalculatorMessage.IsError)
                {
                    dataRecordCalculatorMessage.AddErrors(lvarCalculatorMessage.Errors);
                    return dataRecordCalculatorMessage;
                }

                dataRecord.Data = lvarCalculatorMessage.Lvar.Data;
                dataRecord.NumericValue = lvarCalculatorMessage.Lvar.NumericValue;
                dataRecord.TextValue = lvarCalculatorMessage.Lvar.TextValue;

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            if (dataRecord.Vib.DataType == VibDataType.StandardConformData)
            {
                // -----
                // To Do
                //------
            }

            if (dataRecord.Vib.DataType == VibDataType.CompactProfileWithRegister)
            {
                // -----
                // To Do
                //------
            }

            if (dataRecord.Vib.DataType == VibDataType.CompactProfile)
            {
                // Do nothing, processed with a separate calculator call (compact profiles calculator)
            }

            if (dataRecord.Vib.DataType == VibDataType.WirelessMbusDataContainer)
            {
                // Do nothing, processed with a separate calculator call (wireless mbus data container post processing)
            }

            if (dataRecord.Vib.DataType == VibDataType.ManufacturerSpecificDataContainer)
            {
                // Do nothing, processed with a separate calculator call (manufacturer data container post processing)
            }

            if (dataRecord.Vib.DataType == VibDataType.Numeric)
            {
                ValueDataRecordCalculatorMessage valueDataRecordCalculatorMessage = this.CalculateDataValue(dataRecord.Dib.DataType, dataRecord.Data);
                if (valueDataRecordCalculatorMessage.IsError)
                {
                    dataRecordCalculatorMessage.AddErrors(valueDataRecordCalculatorMessage.Errors);
                    return dataRecordCalculatorMessage;
                }

                if (valueDataRecordCalculatorMessage.Value == null)
                {
                    dataRecordCalculatorMessage.AddErrors(valueDataRecordCalculatorMessage.Errors);
                    return dataRecordCalculatorMessage;
                }

                Double rawVal = (Double)valueDataRecordCalculatorMessage.Value;

                if (dataRecord.Vib.Magnitude == null)
                {
                    dataRecordCalculatorMessage.AddErrors(valueDataRecordCalculatorMessage.Errors);
                    return dataRecordCalculatorMessage;
                }

                Int32 baseV = 10;
                Double value = rawVal * Math.Pow(baseV, (Int32)dataRecord.Vib.Magnitude);

                // round if multiplier <= 1 and multiplier >= 0.001
                if (dataRecord.Vib.Magnitude <= 0 && dataRecord.Vib.Magnitude >= -3)
                {
                    value = Math.Round(value, 3);
                }

                if (Double.IsNaN(value))
                {
                    dataRecord.Comment = (dataRecord.Comment + " " + "Numeric value is NaN").Trim();
                }
                else
                {
                    dataRecord.NumericValue = value;
                }

                dataRecordCalculatorMessage.SetDataRecord(dataRecord);
                return dataRecordCalculatorMessage;
            }

            dataRecord.TextValue = dataRecord.Data.ToHexString();
            dataRecordCalculatorMessage.SetDataRecord(dataRecord);
            return dataRecordCalculatorMessage;
        }

        public ValueDataRecordCalculatorMessage CalculateDataValue (DibDataType dibDataType, IEnumerable<Byte> data)
        {
            ValueDataRecordCalculatorMessage valueDataRecordCalculatorMessage = new();
            
            switch (dibDataType)
            {
                case DibDataType.NoData:
                    if (data != null && data.Any())
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    break;

                case DibDataType.Data8BitInteger:
                    if (data == null || data.Count() != 1)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue((SByte)data.ToArray()[0]);
                    }
                    break;

                case DibDataType.Data16BitInteger:
                    if (data == null || data.Count() != 2)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(BitConverter.ToInt16(data.ToArray(), 0));
                    }
                    break;

                case DibDataType.Data24BitInteger:
                    if (data == null || data.Count() != 3)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.Bit24ToInt32());
                    }
                    break;

                case DibDataType.Data32BitInteger:
                    if (data == null || data.Count() != 4)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(BitConverter.ToInt32(data.ToArray(), 0));
                    }
                    break;

                case DibDataType.Data32BitReal:
                    if (data == null || data.Count() != 4)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(BitConverter.ToSingle(data.ToArray(), 0));
                    }
                    break;

                case DibDataType.Data48BitInteger:
                    if (data == null || data.Count() != 6)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.Bit48ToInt64());
                    }
                    break;

                case DibDataType.Data64BitInteger:
                    if (data == null || data.Count() != 8)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(BitConverter.ToInt64(data.ToArray(), 0));
                    }
                    break;

                case DibDataType.SelectionForReadout:
                    if (data != null && data.Any())
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    break;

                case DibDataType.Data2DigitBCD:
                    if (data == null || data.Count() != 1)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.BCDToUIt64());
                    }
                    break;

                case DibDataType.Data4DigitBCD:
                    if (data == null || data.Count() != 2)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.BCDToUIt64());
                    }
                    break;

                case DibDataType.Data6DigitBCD:
                    if (data == null || data.Count() != 3)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.BCDToUIt64());
                    }
                    break;

                case DibDataType.Data8DigitBCD:
                    if (data == null || data.Count() != 4)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.BCDToUIt64());
                    }
                    break;

                case DibDataType.DataVariableLength:
                    if (data == null || data.Count() != 1)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.ToArray()[0]);
                    }
                    break;

                case DibDataType.Data12DigitBCD:
                    if (data == null || data.Count() != 6)
                    {
                        valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    }
                    else
                    {
                        valueDataRecordCalculatorMessage.SetValue(data.BCDToUIt64());
                    }
                    break;

                case DibDataType.SpecialFunctionManufacturerSpecific:
                    break;

                case DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram:
                    break;

                case DibDataType.SpecialFunctionIdleFilter:
                    break;

                case DibDataType.SpecialFunctionReserved0x3F:
                    break;

                case DibDataType.SpecialFunctionReserved0x4F:
                    break;

                case DibDataType.SpecialFunctionReserved0x5F:
                    break;

                case DibDataType.SpecialFunctionReserved0x6F:
                    break;

                case DibDataType.SpecialFunctionGlobalReadout:
                    break;

                default:
                    valueDataRecordCalculatorMessage.AddErrorCode(ErrorCode.DataRecordCalculatorError);
                    break;
            }

            return valueDataRecordCalculatorMessage;
        }
    }
}