using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators
{
    internal sealed class HeaderCalculator : IHeaderCalculator
    {
        private static HeaderCalculator? instance;

        public static HeaderCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new HeaderCalculator();
            }
            return instance;
        }

        private HeaderCalculator()
        {
        }

        public HeaderMessage CalculateHeader(Byte ciField, ref Queue<Byte> data)
        {
            HeaderMessage headerMessage = new();
            Header header = new();
 
            header.HeaderType = this.GetHeaderType(ciField);

            if (data.Count < this.GetHeaderLength(header.HeaderType))
            {
                headerMessage.AddErrorCode(ErrorCode.HeaderCalculatorError);
                return headerMessage;
            }

            if (header.HeaderType == HeaderType.None)
            {
                headerMessage.SetHeader(header);
                return headerMessage;
            }
            else if (header.HeaderType == HeaderType.Short)
            {
                header.AccessNumber = data.Dequeue();
                header.Status = data.Dequeue();
                header.Configuration = [data.Dequeue(), data.Peek()];
                header.Encryption = this.GetEncryptionMethod(data.Dequeue());
                headerMessage.SetHeader(header);
                return headerMessage;
            }
            else if (header.HeaderType == HeaderType.Long)
            {
                header.IdentificationNumber = [data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue()];
                header.Manufacturer = [data.Dequeue(), data.Dequeue()];
                header.Version = data.Dequeue();
                header.DeviceType = data.Dequeue();
                header.AccessNumber = data.Dequeue();
                header.Status = data.Dequeue();
                header.Configuration = [data.Dequeue(), data.Peek()];
                header.Encryption = this.GetEncryptionMethod(data.Dequeue());
                headerMessage.SetHeader(header);
                return headerMessage;
            }

            headerMessage.AddErrorCode(ErrorCode.HeaderCalculatorError);
            return headerMessage;
        }

        private HeaderType GetHeaderType(Byte ciField)
        {
            Byte[] noneH = new Byte[] { 0x50, 0x51, 0x52, 0x69, 0x70, 0x71, 0x78, 0x79 };
            Byte[] shortH = new Byte[] { 0x5A, 0x61, 0x65, 0x6A, 0x6E, 0x74, 0x7A, 0x7B, 0x7D, 0x7F, 0x8A };
            Byte[] longH = new Byte[] { 0x53, 0x5B, 0x60, 0x64, 0x6B, 0x6C, 0x6D, 0x6F, 0x72, 0x73, 0x75, 0x7C, 0x7E, 0x80, 0x84, 0x85, 0x8B };

            switch (ciField)
            {
                case Byte n when Array.Exists(noneH, element => element == n):
                    return HeaderType.None;

                case Byte n when Array.Exists(shortH, element => element == n):
                    return HeaderType.Short;

                case Byte n when Array.Exists(longH, element => element == n):
                    return HeaderType.Long;

                default:
                    return HeaderType.Unknown;
            }
        }

        public Byte GetHeaderLength(HeaderType headerType)
        {
            switch (headerType)
            {
                case HeaderType.None:
                    return 0;

                case HeaderType.Short:
                    return 4;

                case HeaderType.Long:
                    return 12;

                default:
                    return 0;
            }
        }

        private EncryptionMethod GetEncryptionMethod(Byte encryptionMethodByte)
        {
            Byte maskedByte = (Byte)(encryptionMethodByte & 0x0F);

            switch (maskedByte)
            {
                case 0x00:
                    return EncryptionMethod.None;
                case 0x01:
                    return EncryptionMethod.Reserved1;
                case 0x02:
                    return EncryptionMethod.DesCbcIvZero;
                case 0x03:
                    return EncryptionMethod.DesCbcIvNonZero;
                case 0x04:
                    return EncryptionMethod.Reserved0x04;
                case 0x05:
                    return EncryptionMethod.AesCbcIvNonZero;
                case 0x06:
                    return EncryptionMethod.Reserved0x06;
                case 0x07:
                    return EncryptionMethod.Reserved0x07;
                case 0x08:
                    return EncryptionMethod.Reserved0x08;
                case 0x09:
                    return EncryptionMethod.Reserved0x09;
                case 0x0A:
                    return EncryptionMethod.Reserved0x0A;
                case 0x0B:
                    return EncryptionMethod.Reserved0x0B;
                case 0x0C:
                    return EncryptionMethod.Reserved0x0C;
                case 0x0D:
                    return EncryptionMethod.Reserved0x0D;
                case 0x0E:
                    return EncryptionMethod.Reserved0x0E;
                case 0x0F:
                    return EncryptionMethod.Reserved0x0F;
                default:
                    return EncryptionMethod.Unknown;
            }
        }
    }
}