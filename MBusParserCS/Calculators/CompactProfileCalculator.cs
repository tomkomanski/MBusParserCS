using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using System.Globalization;

namespace MBusParserCS.Calculators
{
    internal sealed class CompactProfileCalculator : ICompactProfileCalculator
    {
        private static CompactProfileCalculator? instance;

        public static CompactProfileCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new CompactProfileCalculator();
            }
            return instance;
        }

        private CompactProfileCalculator()
        {
        }

        public void CalculateCompactProfile(ref List<DataRecord> dataRecords)
        {            
            if (!dataRecords.Any())
            {
                return;
            }

            List<Byte> compactProfileIndexes = new();
            Byte index = 0;

            while (index < dataRecords.Count)
            {
                if (dataRecords[index]?.Vib?.DataType == VibDataType.CompactProfile)
                {
                    compactProfileIndexes.Add(index);
                }

                index += 1;
            }

            foreach (Byte idx in compactProfileIndexes)
            {
                if (dataRecords[idx].Dib.StorageNumber == null || dataRecords[idx].Dib.StorageNumber == 0)
                {
                    continue;
                }
                UInt32? storageNumber = dataRecords[idx].Dib.StorageNumber;

                if (dataRecords[idx].Dib.Tariff == null)
                {
                    continue;
                }
                UInt32? tariff = dataRecords[idx].Dib.Tariff;

                if (dataRecords[idx].Dib.Subunit == null)
                {
                    continue;
                }
                UInt32? subunit = dataRecords[idx].Dib.Subunit;

                if (!dataRecords[idx].Data.Any())
                {
                    continue;
                }

                SByte? magnitude = dataRecords[idx].Vib?.Magnitude;
                Queue<Byte> buffer = new(dataRecords[idx].Data);
     
                if (buffer.Count < 3) // byte 1 - lvar length, byte 2 - spacing control byte, byte 3 - spacing value
                {
                    continue;
                }

                buffer.Dequeue(); // remove lvar length
                Byte spacingControlByte = buffer.Dequeue();
                Byte spacingValue = buffer.Dequeue();
                Byte incrementMode = (Byte)(spacingControlByte >> 6);
                Byte spacingUnit = (Byte)((spacingControlByte & 0x30) >> 4);

                IDibCalculator dibCalculator = DibCalculator.GetCalculator();
                DibDataType elementDataType = dibCalculator.GetDibDataType((Byte)(spacingControlByte & 0x0F));
                Byte elementLength = dibCalculator.GetDataLength(elementDataType);

                if (buffer.Count % elementLength != 0)
                {
                    continue;
                }

                Byte amountOfElements = (Byte)(buffer.Count / elementLength);
                DataRecord? baseTimeRecord = dataRecords.Find(x => x.Dib.StorageNumber == storageNumber && 
                                                                x.Dib.Tariff == tariff && 
                                                                x.Dib.Subunit == subunit &&
                                                                x.Vib?.DataType == VibDataType.DataTypeFJIM &&
                                                                !String.IsNullOrEmpty(x.TextValue));

                if (baseTimeRecord == null)
                {
                    continue;
                }

                String? baseTimeString = baseTimeRecord.TextValue;
                DateTime baseTime;
                if (!DateTime.TryParseExact(baseTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out baseTime))
                {
                    continue;
                }

                DataRecord? baseValueDaRecord = dataRecords.Find(x => x.Dib.StorageNumber == storageNumber &&
                                                                    x.Dib.Tariff == tariff &&
                                                                    x.Dib.Subunit == subunit &&
                                                                    x.Vib?.DataType == VibDataType.Numeric &&
                                                                    x.NumericValue != null);

                if (baseValueDaRecord == null)
                {
                    continue;
                }

                Double baseValue = baseValueDaRecord.NumericValue ?? 0;
                String text = String.Empty;

                for (Byte n = 1; n <= amountOfElements; n++)
                {
                    if (buffer.Count < elementLength)
                    {
                        break;
                    }

                    IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
                    ValueDataRecordCalculatorMessage valueDataRecordCalculatorMessage = dataRecordCalculator.CalculateDataValue(elementDataType, buffer.DequeueChunk(elementLength));

                    if (valueDataRecordCalculatorMessage.IsError)
                    {
                        break;
                    }

                    Double? elementValueTemp = valueDataRecordCalculatorMessage.Value;

                    if (elementValueTemp == null || magnitude == null)
                    {
                        break;
                    }

                    Int32 baseV = 10;
                    Double elementValue = (Double)elementValueTemp * Math.Pow(baseV, (Int32)magnitude);

                    // round if multiplier <= 1 and multiplier >= 0.001
                    if (magnitude <= 0 && magnitude >= -3)
                    {
                        elementValue = Math.Round(elementValue, 3);
                    }

                    // Calculate element value according to increment mode
                    if (incrementMode == 0)
                    {
                        // Absolute value, do nothing
                    }
                    else if (incrementMode == 1)
                    {
                        elementValue = (Double)baseValue + elementValue;
                    }
                    else if (incrementMode == 2)
                    {
                        elementValue = (Double)baseValue - elementValue;
                    }
                    else if (incrementMode == 3)
                    {
                        baseValue = (Double)baseValue - elementValue;
                        elementValue = (Double)baseValue;
                    }
                    // ---

                    // Calculate element datetime according to spacing unit and spacing value
                    DateTime dateTime = baseTime;

                    if (spacingValue == 0)
                    {
                        // Not spacing in time, do nothing
                    }
                    else if (spacingValue >= 1 && spacingValue <= 250)
                    {
                        if (spacingUnit == 0)
                        {
                            dateTime = baseTime.AddSeconds(n * spacingValue);           
                        }
                        else if (spacingUnit == 1)
                        {
                            dateTime = baseTime.AddMinutes(n * spacingValue);
                        }
                        else if (spacingUnit == 2)
                        {
                            dateTime = baseTime.AddHours(n * spacingValue);
                        }
                        else if (spacingUnit == 3)
                        {
                            dateTime = baseTime.AddDays(n * spacingValue);
                        }
                    }
                    else if (spacingValue == 253)
                    {
                        if (spacingUnit == 3)
                        {
                            dateTime = baseTime.AddDays(15);
                        }
                    }
                    else if (spacingValue == 254)
                    {
                        if (spacingUnit == 1)
                        {
                            dateTime = baseTime.AddMonths(n * 6);
                        }
                        else if (spacingUnit == 2)
                        {
                            dateTime = baseTime.AddMonths(n * 3);
                        }
                        else if(spacingUnit == 3)
                        {
                            dateTime = baseTime.AddMonths(n * 1);
                        }
                    }
                    // ---

                    text = (text + " " + "[" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + " " + elementValue.ToString(CultureInfo.InvariantCulture) + "]").Trim();
                }

                dataRecords[idx].TextValue = text;
            }
            return;
        }
    }
}