namespace MBusParserCS.Messages
{
    internal enum ErrorCode
    {
        DataRecordCalculatorError,
        DibCalculatorError,
        ExtendedLinkLayerCalculatorError,
        HeaderCalculatorError,
        LongFrameParserError,
        LongFrameWmbusAError,
        LongFrameWmbusBError,
        LvarError,
        ManufacturerError,
        MbusInvalidChecksum,
        MbusInvalidDatagramLength,
        ParserFatalError,
        TelegramFormatCalculatorError,
        TelegramFormatNotSupported,
        WmbusInvalidCrc,
        WmbusInvalidDatagramLength,
        VibCalculatorError,
    }

    internal static class ErrorDescriptions
    {
        public static String GetDescription(this ErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ErrorCode.DataRecordCalculatorError:
                    return "Data record calculator error";
                case ErrorCode.DibCalculatorError:
                    return "Dib calculator error";
                case ErrorCode.ExtendedLinkLayerCalculatorError:
                    return "Extended link layer calculator error";
                case ErrorCode.HeaderCalculatorError:
                    return "Header calculator error";
                case ErrorCode.LongFrameParserError:
                    return "M-Bus long frame parser error";
                case ErrorCode.LongFrameWmbusAError:
                    return "wM-Bus format A long frame parser error";
                case ErrorCode.LongFrameWmbusBError:
                    return "wM-Bus format B long frame parser error";
                case ErrorCode.LvarError:
                    return "Lvar error";
                case ErrorCode.ManufacturerError:
                    return "Manufacturer calculator error";
                case ErrorCode.MbusInvalidChecksum:
                    return "M-Bus invalid checksum";
                case ErrorCode.MbusInvalidDatagramLength:
                    return "M-Bus invalid datagram length";
                case ErrorCode.ParserFatalError:
                    return "Parser fatal error";
                case ErrorCode.TelegramFormatCalculatorError:
                    return "Telegram format calculator error";
                case ErrorCode.TelegramFormatNotSupported:
                    return "Telegram format not supported";
                case ErrorCode.WmbusInvalidCrc:
                    return "wM-Bus invalid crc";
                case ErrorCode.WmbusInvalidDatagramLength:
                    return "wM-Bus invalid datagram length";
                case ErrorCode.VibCalculatorError:
                    return "Vib calculator error";
                default:
                    return "Unknown error";
            }  
        }
    }

    internal abstract class ErrorsContainer
    {
        public class Error
        {
            public ErrorCode ErrorCode { get; }
            public String Message { get; }

            public Error(ErrorCode errorCode, String message = "")
            {
                this.ErrorCode = errorCode;
                this.Message = message;
            }
        }

        private readonly List<Error> errors = new();

        public Boolean IsError
        {
            get
            {
                return this.errors.Any();
            }
        }

        public IEnumerable<Error> Errors
        {
            get
            {
                return this.errors;
            }
        }

        public void AddErrorCode(ErrorCode errorCode, String message = "")
        {
            this.errors.Add(new Error(errorCode, message));
        }

        public void AddErrors(IEnumerable<Error> errors)
        {
            this.errors.AddRange(errors);
        }

        public String GetErrorDescriptions()
        {
            List<String> errors = new();

            foreach (Error error in this.errors)
            {
                if (String.IsNullOrEmpty(error.Message))
                {
                    errors.Add(error.ErrorCode.GetDescription());
                }
                else
                {
                    errors.Add($"{error.ErrorCode.GetDescription()}: {error.Message}");
                }
            }

            return String.Join(", ", errors);
        }
    }
}