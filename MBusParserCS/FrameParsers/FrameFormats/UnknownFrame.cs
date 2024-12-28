using MBusParserCS.Messages;

namespace MBusParserCS.FrameParsers
{
    internal sealed partial class FrameFormatSelector
    {
        private ParserMessage UnknownFrame()
        {
            ParserMessage parserMessage = new();
            parserMessage.AddErrorCode(ErrorCode.TelegramFormatNotSupported);
            return parserMessage;
        }
    }
}