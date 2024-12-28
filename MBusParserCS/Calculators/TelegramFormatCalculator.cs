using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using MBusParserCS.Tools;

namespace MBusParserCS.Calculators
{
    internal sealed class TelegramFormatCalculator : ITelegramFormatCalculator
    {
        private static TelegramFormatCalculator? instance;

        public static TelegramFormatCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new TelegramFormatCalculator();
            }
            return instance;
        }

        private TelegramFormatCalculator() 
        { 
        }

        public TelegramFormatMessage CalculateTelegramFormat(ref Queue<Byte> data)
        {
            TelegramFormatMessage telegramFormatMessage = new();

            if (!data.Any())
            {
                telegramFormatMessage.AddErrorCode(ErrorCode.TelegramFormatCalculatorError);
                return telegramFormatMessage;
            }

            if (data.Count == 1 && data.ElementAt(0) == 0x05)
            {
                telegramFormatMessage.AddErrorCode(ErrorCode.TelegramFormatNotSupported);
                return telegramFormatMessage;
            }

            if (data.Count == 5 && data.ElementAt(0) == 0x10 && data.ElementAt(4) == 0x16)
            {
                Message message = this.ValidateCs(data.Skip(1).SkipLast(1));
                if (message.IsError)
                {
                    telegramFormatMessage.AddErrors(message.Errors);
                    return telegramFormatMessage;
                }

                telegramFormatMessage.AddErrorCode(ErrorCode.TelegramFormatNotSupported);
                return telegramFormatMessage;
            }

            if (data.Count > 5 && data.Count < 262 && data.ElementAt(0) == 0x68 && data.ElementAt(1) == data.ElementAt(2) && data.Last() == 0x16)
            {
                Message message = this.ValidateLengthMbus(data);
                if (message.IsError)
                {
                    telegramFormatMessage.AddErrors(message.Errors);
                    return telegramFormatMessage;
                }

                message = this.ValidateCs(data.Skip(4).SkipLast(1));
                if (message.IsError)
                {
                    telegramFormatMessage.AddErrors(message.Errors);
                    return telegramFormatMessage;
                }

                if (data.ElementAt(1) == 0x03)
                {
                    telegramFormatMessage.AddErrorCode(ErrorCode.TelegramFormatNotSupported);
                    return telegramFormatMessage;
                }
                if (data.ElementAt(1) != 0x03)
                {
                    telegramFormatMessage.SetTelegramFormat(TelegramFormat.LongFrameMBus);
                    return telegramFormatMessage;
                }

                telegramFormatMessage.AddErrorCode(ErrorCode.TelegramFormatCalculatorError);
                return telegramFormatMessage;
            }

            if (data.Count > 5 && data.ElementAt(1) == 0x44)
            {
                Message validateLengthWmbusFormatA = this.ValidateLengthWmbusFormatA(data);
                Message validateLengthWmbusFormatB = this.ValidateLengthWmbusFormatB(data);
                Message validateCrcWmbusFormatA = this.ValidateCrcWmbusFormatA(data);
                Message validateCrcWmbusFormatB = this.ValidateCrcWmbusFormatB(data);

                if (data.Count < 291 && !validateLengthWmbusFormatA.IsError && !validateCrcWmbusFormatA.IsError)
                {
                    telegramFormatMessage.SetTelegramFormat(TelegramFormat.LongFrameWMBusFormatA);
                    return telegramFormatMessage;
                }

                if (data.Count < 257 && !validateLengthWmbusFormatB.IsError && !validateCrcWmbusFormatB.IsError)
                {
                    telegramFormatMessage.SetTelegramFormat(TelegramFormat.LongFrameWMBusFormatB);
                    return telegramFormatMessage;
                }

                if (validateLengthWmbusFormatA.IsError && validateLengthWmbusFormatB.IsError)
                {
                    telegramFormatMessage.AddErrorCode(ErrorCode.WmbusInvalidDatagramLength);
                    return telegramFormatMessage;
                }

                if (!validateLengthWmbusFormatA.IsError && validateCrcWmbusFormatA.IsError)
                {
                    telegramFormatMessage.AddErrors(validateCrcWmbusFormatA.Errors);
                    return telegramFormatMessage;
                }

                if (!validateLengthWmbusFormatB.IsError && validateCrcWmbusFormatB.IsError)
                {
                    telegramFormatMessage.AddErrors(validateCrcWmbusFormatB.Errors);
                    return telegramFormatMessage;
                }
            }

            telegramFormatMessage.AddErrorCode(ErrorCode.TelegramFormatCalculatorError);
            return telegramFormatMessage;
        }

        private Message ValidateLengthMbus(IEnumerable<Byte> data)
        {
            Message message = new();
            Int32 length = data.Count();

            if (length - 6 == data.ElementAt(1))
            {
                return message;
            }

            message.AddErrorCode(ErrorCode.MbusInvalidDatagramLength);
            return message;
        }

        private Message ValidateLengthWmbusFormatA(IEnumerable<Byte> data)
        {
            Message message = new();
            Int32 intermediateLength = data.ElementAt(0);
            intermediateLength -= 9;
            Int32 remainingBlocks = (Int32)Math.Ceiling((Double)intermediateLength / 16);
            Int32 numberOfCrcBytes = (remainingBlocks * 2) + 2;
            Int32 length = data.Count() - numberOfCrcBytes - 1;

            if (length == data.ElementAt(0))
            {
                return message;
            }

            message.AddErrorCode(ErrorCode.WmbusInvalidDatagramLength);
            return message;
        }

        private Message ValidateLengthWmbusFormatB(IEnumerable<Byte> data)
        {
            Message message = new();
            Int32 length = data.Count() -1;

            if (length == data.ElementAt(0))
            {
                return message;
            }

            message.AddErrorCode(ErrorCode.WmbusInvalidDatagramLength);
            return message;
        }

        private Message ValidateCs(IEnumerable<Byte> data)
        {
            Message message = new();
            Byte givenCs = data.ElementAt(data.Count() - 1);
            Byte calculatedCs = Checksum.CalculateMbusCs(data.SkipLast(1));

            if (givenCs == calculatedCs)
            {
                return message;
            }

            message.AddErrorCode(ErrorCode.MbusInvalidChecksum, $"{givenCs.ToHexString()} vs {calculatedCs.ToHexString()}");
            return message;
        }

        private Message ValidateCrcWmbusFormatA(IEnumerable<Byte> data)
        {
            Message message = new();
            Queue<Byte> buffer = new(data);

            if (buffer.Count < 12)
            {
                message.AddErrorCode(ErrorCode.WmbusInvalidCrc, "Insufficient data for calculate crc");
                return message;
            }

            List<Byte> dataBlock = new(buffer.DequeueChunk(10));
            Byte[] givenCrc = buffer.DequeueChunk(2).ToArray();
            Byte[] calculatedCrc = Checksum.CalculateWmbusCrc(dataBlock);

            if (givenCrc[0] != calculatedCrc[0] || givenCrc[1] != calculatedCrc[1])
            {
                message.AddErrorCode(ErrorCode.WmbusInvalidCrc, $"{givenCrc.ToHexString()} vs {calculatedCrc.ToHexString()}");
                return message;
            }

            while (buffer.Count >= 18)
            {
                dataBlock = new(buffer.DequeueChunk(16));
                givenCrc = buffer.DequeueChunk(2).ToArray();
                calculatedCrc = Checksum.CalculateWmbusCrc(dataBlock);

                if (givenCrc[0] != calculatedCrc[0] || givenCrc[1] != calculatedCrc[1])
                {
                    message.AddErrorCode(ErrorCode.WmbusInvalidCrc, $"{givenCrc.ToHexString()} vs {calculatedCrc.ToHexString()}");
                    return message;
                }
            }

            Int32 remainingNumberOfBytes = buffer.Count;

            if (remainingNumberOfBytes == 0)
            {
                return message;
            }

            if (remainingNumberOfBytes < 3)
            {
                message.AddErrorCode(ErrorCode.WmbusInvalidCrc, "Insufficient data for calculate crc");
                return message;
            }

            dataBlock = new(buffer.DequeueChunk(remainingNumberOfBytes - 2));
            givenCrc = buffer.DequeueChunk(2).ToArray();
            calculatedCrc = Checksum.CalculateWmbusCrc(dataBlock);

            if (givenCrc[0] != calculatedCrc[0] || givenCrc[1] != calculatedCrc[1])
            {
                message.AddErrorCode(ErrorCode.WmbusInvalidCrc, $"{givenCrc.ToHexString()} vs {calculatedCrc.ToHexString()}");
                return message;
            }

            return message;
        }

        private Message ValidateCrcWmbusFormatB(IEnumerable<Byte> data)
        {
            Message message = new();
            Queue<Byte> buffer = new(data);

            if (buffer.Count < 10)
            {
                message.AddErrorCode(ErrorCode.WmbusInvalidCrc, "Insufficient data for calculate crc");
                return message;
            }

            List<Byte> dataBlock = new(buffer.DequeueChunk(10));
            Byte[] givenCrc;
            Byte[] calculatedCrc;

            if (buffer.Count >= 118)
            {
                dataBlock = new(buffer.DequeueChunk(116));
                givenCrc = buffer.DequeueChunk(2).ToArray();
                calculatedCrc = Checksum.CalculateWmbusCrc(dataBlock);

                if (givenCrc[0] != calculatedCrc[0] || givenCrc[1] != calculatedCrc[1])
                {
                    message.AddErrorCode(ErrorCode.WmbusInvalidCrc, $"{givenCrc.ToHexString()} vs {calculatedCrc.ToHexString()}");
                    return message;
                }
            }

            Int32 remainingNumberOfBytes = buffer.Count;

            if (remainingNumberOfBytes == 0)
            {
                return message;
            }

            if (remainingNumberOfBytes < 3)
            {
                message.AddErrorCode(ErrorCode.WmbusInvalidCrc, "Insufficient data for calculate crc");
                return message;
            }

            dataBlock = new(buffer.DequeueChunk(remainingNumberOfBytes - 2));
            givenCrc = buffer.DequeueChunk(2).ToArray();
            calculatedCrc = Checksum.CalculateWmbusCrc(dataBlock);

            if (givenCrc[0] != calculatedCrc[0] || givenCrc[1] != calculatedCrc[1])
            {
                message.AddErrorCode(ErrorCode.WmbusInvalidCrc, $"{givenCrc.ToHexString()} vs {calculatedCrc.ToHexString()}");
                return message;
            }

            return message;
        }
    }
}