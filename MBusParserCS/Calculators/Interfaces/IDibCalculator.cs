using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface IDibCalculator
    {
        DibCalculatorMessage CalculateDib(ref Queue<Byte> data);
        DibDataType GetDibDataType(Byte dataTypeByte);
        Byte GetDataLength(DibDataType dibDataType);
    }
}