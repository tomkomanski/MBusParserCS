using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface IDataRecordCalculator
    {
        DataRecordCalculatorMessage CalculateDataRecord(ref Queue<Byte> data, Byte[]? manufacturer);
        ValueDataRecordCalculatorMessage CalculateDataValue(DibDataType dibDataType, IEnumerable<Byte> data);
    }
}