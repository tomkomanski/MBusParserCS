using MBusParserCS.Messages;

namespace MBusParserCS.FrameParsers
{
    internal sealed partial class FrameFormatSelector
    {
        public ParserMessage LongFrameWMBusFormatB(ref Queue<Byte> data, ref List<Byte> key)
        {
            // -----
            // To Do
            //------

            ParserMessage parserMessage = new();
            parserMessage.AddErrorCode(ErrorCode.LongFrameWmbusBError);
            return parserMessage;
        }
    }
}
