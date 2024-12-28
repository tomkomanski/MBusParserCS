using MBusParserCS.Messages;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface IVibCalculator
    {
        public VibCalculatorMessage CalculateVib(ref Queue<Byte> data, ref Byte[]? manufacturer);
    }
}