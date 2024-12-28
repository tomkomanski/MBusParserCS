using MBusParserCS.Messages;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface IManufacturerCalculator
    {
        ManufacturerCalculatorMessage CalculateManufacturer(ref Byte[]? manufacturerBytes);
    }
}