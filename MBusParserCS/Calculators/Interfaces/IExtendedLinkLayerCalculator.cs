using MBusParserCS.Messages;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface IExtendedLinkLayerCalculator
    {
        ExtendedLinkLayerMessage CalculateExtendedLinkLayer(Byte ciField, ref Queue<Byte> data);
    }
}