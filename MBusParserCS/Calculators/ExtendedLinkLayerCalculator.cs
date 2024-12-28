using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators
{
    internal sealed class ExtendedLinkLayerCalculator : IExtendedLinkLayerCalculator
    {
        private static ExtendedLinkLayerCalculator? instance;

        public static ExtendedLinkLayerCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new ExtendedLinkLayerCalculator();
            }
            return instance;
        }

        private ExtendedLinkLayerCalculator()
        {
        }

        public ExtendedLinkLayerMessage CalculateExtendedLinkLayer(Byte ciField, ref Queue<Byte> data)
        {
            ExtendedLinkLayerMessage extendedLinkLayerMessage = new();

            ExtendedLinkLayerTypeAndLength extendedLinkLayerTypeAndLength = GetExtendedLinkLayerTypeAndLength(ciField);

            if (data.Count < extendedLinkLayerTypeAndLength.Length)
            {
                extendedLinkLayerMessage.AddErrorCode(ErrorCode.ExtendedLinkLayerCalculatorError);
                return extendedLinkLayerMessage;
            }

            ExtendedLinkLayer extendedLinkLayer = new()
            {
                Type = extendedLinkLayerTypeAndLength.Type,
                Length = extendedLinkLayerTypeAndLength.Length,
            };


            if (extendedLinkLayer.Type == ExtendedLinkLayerType.None)
            {
                extendedLinkLayerMessage.SetExtendedLinkLayer(extendedLinkLayer);
                return extendedLinkLayerMessage;
            }
            else if (extendedLinkLayer.Type == ExtendedLinkLayerType.I)
            {
                extendedLinkLayer.Cc = data.Dequeue();
                extendedLinkLayer.Acc = data.Dequeue();
                extendedLinkLayerMessage.SetExtendedLinkLayer(extendedLinkLayer);
                return extendedLinkLayerMessage;
            }
            else if (extendedLinkLayer.Type == ExtendedLinkLayerType.II)
            {
                extendedLinkLayer.Cc = data.Dequeue();
                extendedLinkLayer.Acc = data.Dequeue();
                extendedLinkLayer.Sn = new Byte[] { data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue() };
                extendedLinkLayer.PayloadCrc = new Byte[] { data.Dequeue(), data.Dequeue() };
                extendedLinkLayerMessage.SetExtendedLinkLayer(extendedLinkLayer);
                return extendedLinkLayerMessage;
            }
            else if (extendedLinkLayer.Type == ExtendedLinkLayerType.III)
            {
                extendedLinkLayer.Cc = data.Dequeue();
                extendedLinkLayer.Acc = data.Dequeue();
                extendedLinkLayer.M2 = new Byte[] { data.Dequeue(), data.Dequeue() };
                extendedLinkLayer.A2 = new Byte[] { data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue() };
                extendedLinkLayerMessage.SetExtendedLinkLayer(extendedLinkLayer);
                return extendedLinkLayerMessage;
            }
            else if (extendedLinkLayer.Type == ExtendedLinkLayerType.IV)
            {
                extendedLinkLayer.Cc = data.Dequeue();
                extendedLinkLayer.Acc = data.Dequeue();
                extendedLinkLayer.M2 = new Byte[] { data.Dequeue(), data.Dequeue() };
                extendedLinkLayer.A2 = new Byte[] { data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue() };
                extendedLinkLayer.Sn = new Byte[] { data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue() };
                extendedLinkLayer.PayloadCrc = new Byte[] { data.Dequeue(), data.Dequeue() };
                extendedLinkLayerMessage.SetExtendedLinkLayer(extendedLinkLayer);
                return extendedLinkLayerMessage;
            }
            else if (extendedLinkLayer.Type == ExtendedLinkLayerType.V)
            {
                extendedLinkLayer.Cc = data.Dequeue();
                extendedLinkLayer.Acc = data.Dequeue();
                extendedLinkLayer.Ecl = data.Dequeue();

                if (((extendedLinkLayer.Ecl & 0x01) >> 0) == 1)
                {
                    if (data.Count < 8)
                    {
                        extendedLinkLayerMessage.AddErrorCode(ErrorCode.ExtendedLinkLayerCalculatorError);
                        return extendedLinkLayerMessage;
                    }

                    extendedLinkLayer.M2 = new Byte[] { data.Dequeue(), data.Dequeue() };
                    extendedLinkLayer.A2 = new Byte[] { data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue() };
                    extendedLinkLayerTypeAndLength.Length += 8;
                }

                if (((extendedLinkLayer.Ecl & 0x02) >> 1) == 1)
                {
                    if (data.Count < 4)
                    {
                        extendedLinkLayerMessage.AddErrorCode(ErrorCode.ExtendedLinkLayerCalculatorError);
                        return extendedLinkLayerMessage;
                    }

                    extendedLinkLayer.Sn = new Byte[] { data.Dequeue(), data.Dequeue(), data.Dequeue(), data.Dequeue() };
                    extendedLinkLayerTypeAndLength.Length += 4;
                }

                if (((extendedLinkLayer.Ecl & 0x08) >> 3) == 1)
                {
                    if (data.Count < 2)
                    {
                        extendedLinkLayerMessage.AddErrorCode(ErrorCode.ExtendedLinkLayerCalculatorError);
                        return extendedLinkLayerMessage;
                    }

                    extendedLinkLayer.Rtd = new Byte[] { data.Dequeue(), data.Dequeue() };
                    extendedLinkLayerTypeAndLength.Length += 2;
                }

                if (((extendedLinkLayer.Ecl & 0x10) >> 4) == 1)
                {
                    if (data.Count < 1)
                    {
                        extendedLinkLayerMessage.AddErrorCode(ErrorCode.ExtendedLinkLayerCalculatorError);
                        return extendedLinkLayerMessage;
                    }

                    extendedLinkLayer.Rxl = data.Dequeue();
                    extendedLinkLayerTypeAndLength.Length += 1;
                }

                if (((extendedLinkLayer.Ecl & 0x80) >> 7) == 1)
                {
                    if (data.Count < 2)
                    {
                        extendedLinkLayerMessage.AddErrorCode(ErrorCode.ExtendedLinkLayerCalculatorError);
                        return extendedLinkLayerMessage;
                    }

                    extendedLinkLayer.PayloadCrc = new Byte[] { data.Dequeue(), data.Dequeue() };
                    extendedLinkLayerTypeAndLength.Length += 2;
                }
            }

            extendedLinkLayerMessage.SetExtendedLinkLayer(extendedLinkLayer);
            return extendedLinkLayerMessage;
        }

        private ExtendedLinkLayerTypeAndLength GetExtendedLinkLayerTypeAndLength(Byte ciField)
        {
            ExtendedLinkLayerTypeAndLength extendedLinkLayerTypeAndLength = new();

            switch (ciField)
            {
                case 0x8C:
                    extendedLinkLayerTypeAndLength.Type = ExtendedLinkLayerType.I;
                    extendedLinkLayerTypeAndLength.Length = 2;
                    break;
                case 0x8D:
                    extendedLinkLayerTypeAndLength.Type = ExtendedLinkLayerType.II;
                    extendedLinkLayerTypeAndLength.Length = 8;
                    break;
                case 0x8E:
                    extendedLinkLayerTypeAndLength.Type = ExtendedLinkLayerType.III;
                    extendedLinkLayerTypeAndLength.Length = 10;
                    break;
                case 0x8F:
                    extendedLinkLayerTypeAndLength.Type = ExtendedLinkLayerType.IV;
                    extendedLinkLayerTypeAndLength.Length = 16;
                    break;
                case 0x86:
                    extendedLinkLayerTypeAndLength.Type = ExtendedLinkLayerType.V;
                    extendedLinkLayerTypeAndLength.Length = 3;
                    break;
                default:
                    extendedLinkLayerTypeAndLength.Type = ExtendedLinkLayerType.None;
                    extendedLinkLayerTypeAndLength.Length = 0;
                    break;
            }

            return extendedLinkLayerTypeAndLength;
        }
    }
}
