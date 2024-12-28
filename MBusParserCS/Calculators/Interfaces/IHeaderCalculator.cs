using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface IHeaderCalculator
    {
        HeaderMessage CalculateHeader(Byte ciField, ref Queue<Byte> data);
        Byte GetHeaderLength(HeaderType headerType);
    }
}