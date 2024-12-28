using MBusParserCS.Messages;

namespace MBusParserCS.Calculators.Interfaces
{
    internal interface ITelegramFormatCalculator
    {
        TelegramFormatMessage CalculateTelegramFormat(ref Queue<Byte> data);
    }
}