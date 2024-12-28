using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Calculators;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.FrameParsers
{
    internal sealed partial class FrameFormatSelector : IFrameFormatSelector
    {
        private static FrameFormatSelector? instance;

        public static FrameFormatSelector GetFrameSelector()
        {
            if (instance == null)
            {
                instance = new FrameFormatSelector();
            }
            return instance;
        }
        private FrameFormatSelector()
        {
        }

        public ParserMessage Process(ref Queue<Byte> data, ref List<Byte> key)
        {
            ParserMessage parserMessage = new();
            ITelegramFormatCalculator telegramFormatCalculator = TelegramFormatCalculator.GetCalculator();
            TelegramFormatMessage telegramFormatMessage = telegramFormatCalculator.CalculateTelegramFormat(ref data);

            if (telegramFormatMessage.IsError)
            {
                parserMessage.AddErrors(telegramFormatMessage.Errors);
                return parserMessage;
            }

            TelegramFormat telegramFormat = telegramFormatMessage.TelegramFormat;

            parserMessage = telegramFormat switch
            {
                TelegramFormat.LongFrameMBus => this.LongFrameMbus(ref data, ref key),
                TelegramFormat.LongFrameWMBusFormatA => this.LongFrameWMBusFormatA(ref data, ref key),
                TelegramFormat.LongFrameWMBusFormatB => this.LongFrameWMBusFormatB(ref data, ref key),
                _ => this.UnknownFrame(),
            };

            return parserMessage;
        }
    }
}