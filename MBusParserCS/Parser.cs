using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using MBusParserCS.Extensions;
using MBusParserCS.FrameParsers;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using MBusParserCS.PostProcessing;
using MBusParserCS.PostProcessing.Interfaces;

[assembly: InternalsVisibleTo("MBusParserCS.Tests")]

namespace MBusParserCS
{
    public class Parser : IParser
    {        
        public String Parse(String? stringFrame, String? stringKey)
        {
            Queue<Byte> frame = new();
            if (!String.IsNullOrEmpty(stringFrame))
            {
                frame.EnqueueChunk(stringFrame.ToBytes());
            }

            List<Byte> key = new();
            if (!String.IsNullOrEmpty(stringKey))
            {
                key.AddRange(stringKey.ToBytes());
            }

            IFrameFormatSelector frameFormatSelector = FrameFormatSelector.GetFrameSelector();
            ParserMessage parserMessage = new();
            try
            {
                parserMessage = frameFormatSelector.Process(ref frame, ref key);

                // Post-processing wireless M-Bus data container
                IWirelessMbusDataConteiner wirelessMbusDataConteiner = WirelessMbusDataConteiner.GetCalculator();
                wirelessMbusDataConteiner.Process(ref parserMessage, ref key);

                // Post-processing manufacturer specific data NGP
                INGPpostprocess ngpPostprocess = NGPpostprocess.GetCalculator();
                ngpPostprocess.Process(ref parserMessage, ref key);

            }
            catch (Exception)
            {
                parserMessage.AddErrorCode(ErrorCode.ParserFatalError);
            }

            IResultGenerator resultGenerator = ResultGenerator.GetGenerator();
            Result result = resultGenerator.GenerateResult(ref parserMessage);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new DoubleConverter() },
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };

            return JsonSerializer.Serialize(result, options);
        }
    }
}