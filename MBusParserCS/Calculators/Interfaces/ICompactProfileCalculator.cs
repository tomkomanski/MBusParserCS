using MBusParserCS.Models;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface ICompactProfileCalculator
    {
        void CalculateCompactProfile(ref List<DataRecord> dataRecords);
    }
}