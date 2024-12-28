using MBusParserCS.Calculators;
using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.FrameParsers;
using MBusParserCS.PostProcessing.Interfaces;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.PostProcessing
{
    internal sealed class NGPpostprocess : INGPpostprocess
    {
        private static NGPpostprocess? instance;

        public static NGPpostprocess GetCalculator()
        {
            if (instance == null)
            {
                instance = new NGPpostprocess();
            }
            return instance;
        }

        private NGPpostprocess()
        {
        }

        public void Process(ref ParserMessage parserMessage, ref List<Byte> key)
        {
            if (parserMessage.IsError || !parserMessage.Datagram.DataRecords.Any())
            {
                return;
            }

            // Humidity
            parserMessage.Datagram.DataRecords.ForEach(x =>
            {
                if (x.Vib?.Description == "H")
                {
                    x.Vib.Unit = "%";
                    x.Vib.Description = "Humidity";
                }
            });

            Byte lastRecordNumber = parserMessage.Datagram.DataRecords.Max(x => x.RecordNumber);

            DataRecord? manufacturerSpecificDataRecord =
                parserMessage.Datagram.DataRecords.Find(x => x.Dib.DataType == DibDataType.SpecialFunctionManufacturerSpecific ||
                                                        x.Dib.DataType == DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram);

            if (manufacturerSpecificDataRecord == null || !manufacturerSpecificDataRecord.Data.Any())
            {
                return;
            }

            Queue<Byte> buffer = new(manufacturerSpecificDataRecord.Data);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();

            while (buffer.Count > 0)
            {
                DataRecordCalculatorMessage dataRecordCalculatorMessage = dataRecordCalculator.CalculateDataRecord(ref buffer, parserMessage.Datagram.Header.Manufacturer);
                if (dataRecordCalculatorMessage.IsError)
                {
                    return;
                }

                //Rssi record
                if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x01 &&
                    dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                    dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                    dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x7B)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    newRecord.Vib.Unit = "dBm";
                    newRecord.Vib.Description = "Rssi";
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Control signal record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x01 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x62)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Storage interval record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x02 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x25)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Storage interval record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x03 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x25)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Operationg time record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x04 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0x24)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Datetime record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x04 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0x6D)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Customer location record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x04 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x10)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Volts record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x03 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x48)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Error flags record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x04 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x17)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Control signal record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x03 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0xFD &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes.Count == 1 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifeBytes[0] == 0x62)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Temperature difference record
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x01 &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0x62)
                {
                    DataRecord newRecord = dataRecordCalculatorMessage.DataRecord;
                    lastRecordNumber++;
                    newRecord.RecordNumber = lastRecordNumber;
                    parserMessage.Datagram.DataRecords.Add(newRecord);
                }
                // Manufacturer specific lvar
                else if (dataRecordCalculatorMessage.DataRecord.Dib.DifByte == 0x0D &&
                        dataRecordCalculatorMessage.DataRecord.Vib?.VifByte == 0x7F &&
                        dataRecordCalculatorMessage.DataRecord.Data.Count >= 13)
                {
                    Queue<Byte> lvarWithoutLength = new(dataRecordCalculatorMessage.DataRecord.Data.Skip(1));
                    IFrameFormatSelector frameFormatSelector = FrameFormatSelector.GetFrameSelector();
                    ParserMessage parserMessageLvar = frameFormatSelector.LongFrameWMBusFormatA(ref lvarWithoutLength, ref key);

                    if (parserMessageLvar.IsError)
                    {
                        continue;
                    }

                    foreach (DataRecord dataRecord in parserMessageLvar.Datagram.DataRecords)
                    {
                        lastRecordNumber++;
                        dataRecord.RecordNumber = lastRecordNumber;
                        parserMessage.Datagram.DataRecords.Add(dataRecord);
                    }

                    parserMessage.Datagram.Information.DecryptionStatus = parserMessageLvar.Datagram.Information.DecryptionStatus;
                    parserMessage.Datagram.Header = parserMessageLvar.Datagram.Header;
                }
            }
        }
    }
}