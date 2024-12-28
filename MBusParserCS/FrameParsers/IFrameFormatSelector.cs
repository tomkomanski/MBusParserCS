using MBusParserCS.Messages;

namespace MBusParserCS.FrameParsers
{
    internal interface IFrameFormatSelector
    {
        ParserMessage Process(ref Queue<Byte> data, ref List<Byte> key);
        ParserMessage LongFrameMbus(ref Queue<Byte> data, ref List<Byte> key);
        ParserMessage LongFrameWMBusFormatA(ref Queue<Byte> data, ref List<Byte> key);
        ParserMessage LongFrameWMBusFormatB(ref Queue<Byte> data, ref List<Byte> key);
    }
}