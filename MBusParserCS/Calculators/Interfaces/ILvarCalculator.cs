using MBusParserCS.Messages;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface ILvarCalculator
    {
        LvarCalculatorMessage CalculateLvar(ref Queue<Byte> data, Byte lvar_first_byte);
    }
}