using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS
{
    internal interface IResultGenerator
    {
        Result GenerateResult(ref ParserMessage parserMessage);
    }
}