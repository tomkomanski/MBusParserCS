using MBusParserCS.Messages;

namespace MBusParserCS.PostProcessing.Interfaces
{
    internal interface IWirelessMbusDataConteiner
    {
        void Process(ref ParserMessage parserMessage, ref List<Byte> key);
    }
}