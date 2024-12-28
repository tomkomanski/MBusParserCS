using MBusParserCS.Calculators;
using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.FrameParsers
{
    internal sealed partial class FrameFormatSelector
    {
        public ParserMessage LongFrameMbus(ref Queue<Byte> data, ref List<Byte> key)
        {
            ParserMessage parserMessage = new();

            if (data.Count < 9)
            {
                parserMessage.AddErrorCode(ErrorCode.LongFrameParserError);
                return parserMessage;
            }

            data.DequeueChunk(4); // remove 0x68 0xLL 0xLL 0x68
            data.RemoveBack(2); // remove 0x16 CS

            Information information = new Information()
            {
                CField = data.Dequeue(),
                PrimaryAddress = data.Dequeue(),
                CiField = data.Dequeue(),
                DecryptionStatus = DecryptionStatus.NotEncrypted,
            };

            IHeaderCalculator headerCalculator = HeaderCalculator.GetCalculator();
            HeaderMessage headerMessage = headerCalculator.CalculateHeader(information.CiField, ref data);

            if (headerMessage.IsError)
            {
                parserMessage.AddErrors(headerMessage.Errors);
                return parserMessage;
            }

            List<DataRecord> dataRecords = new();
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