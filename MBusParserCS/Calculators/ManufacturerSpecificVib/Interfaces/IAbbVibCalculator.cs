using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators.ManufacturerSpecificVib.Interfaces
{
    internal interface IAbbVibCalculator
    {
        Message CalculateManufacturerSpecificVifeAfterPrimaryVif(ref Queue<Byte> data, ref Vib vib);
        Message CalculateManufacturerSpecificVifeAfterCombinableVife(ref Queue<Byte> data, ref Vib vib);
    }
}