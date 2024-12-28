using MBusParserCS.Messages;

namespace MBusParserCS.PostProcessing.Interfaces
{
    internal interface INGPpostprocess
    {
        void Process(ref ParserMessage parserMessage, ref List<Byte> key);
    }
}