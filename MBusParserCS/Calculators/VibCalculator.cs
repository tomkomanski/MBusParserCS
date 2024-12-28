using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Calculators.ManufacturerSpecificVib;
using MBusParserCS.Calculators.ManufacturerSpecificVib.Interfaces;
using MBusParserCS.Extensions;
using MBusParserCS.Matrices;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using System.Text;

namespace MBusParserCS.Calculators
{
    internal sealed class VibCalculator : IVibCalculator
    {
        private static VibCalculator? instance;

        public static VibCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new VibCalculator();
            }
            return instance;
        }

        private VibCalculator()
        {
        }

        public VibCalculatorMessage CalculateVib(ref Queue<Byte> data, ref Byte[]? manufacturer)
        {
            VibCalculatorMessage vibCalculatorMessage = new();

            if (data.Count < 1)
            {
                vibCalculatorMessage.AddErrorCode(ErrorCode.VibCalculatorError);
                return vibCalculatorMessage;
            }

            VifVife primaryVif = VifVifeMatrix.GetVifPrimary(data.Dequeue());

            Vib vib = new()
            {
                VifByte = primaryVif.VifVifeByte,
                Extension = primaryVif.Extension,
                DataType = primaryVif.DataType,
                Unit = primaryVif.Unit,
                Description = primaryVif.Description,
                Magnitude = primaryVif.Magnitude,
            };

            // Manufacturer specific block VIFE 0x7F after primary VIF
            if (vib.Extension == 0x7F)
            {
                vibCalculatorMessage.SetVib(vib);
                return vibCalculatorMessage;
            }
            // Manufacturer specific block VIFE 0xFF after primary VIF
            else if (vib.Extension == 0xFF)
            {
                Message message = this.GetManufacturerSpecificVifeAfterPrimaryVif(ref data, ref vib, ref manufacturer);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }
                vibCalculatorMessage.SetVib(vib);
                return vibCalculatorMessage;
            }
            // VIFE extension table 0xEF after primary VIF
            else if (vib.Extension == 0xEF)
            {
                Message message = this.GetExtensionEfAfterPrimaryVif(ref data, ref vib);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }
            }
            // VIFE extension table 0xFB after primary VIF
            else if (vib.Extension == 0xFB)
            {
                Message message = this.GetExtensionFbAfterPrimaryVif(ref data, ref vib);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }
            }
            // VIFE extension table 0xFD after primary VIF
            else if (vib.Extension == 0xFD)
            {
                Message message = this.GetExtensionFdAfterPrimaryVif(ref data, ref vib);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }
            }

            // VIFE combinable
            if (vib.Extension != null)
            {
                Message message = this.GetCombinableVife(ref data, ref vib);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }

                while (vib.Extension != null && vib.Extension != 0x7F && vib.Extension != 0xFF && vib.Extension != 0xFC)
                {
                    message = this.GetCombinableVife(ref data, ref vib);
                    if (message.IsError)
                    {
                        vibCalculatorMessage.AddErrors(message.Errors);
                        return vibCalculatorMessage;
                    }
                }
            }

            // Manufacturer specific block VIFE 0x7F after VIFE combinable
            if (vib.Extension == 0x7F)
            {
                vibCalculatorMessage.SetVib(vib);
                return vibCalculatorMessage;
            }
            // Manufacturer specific block VIFE 0xFF after VIFE combinable
            else if (vib.Extension == 0xFF)
            {
                Message message = this.GetManufacturerSpecificVifeAfterCombinableyVife(ref data, ref vib, ref manufacturer);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }
                vibCalculatorMessage.SetVib(vib);
                return vibCalculatorMessage;
            }

            // VIFE combinable extension table 0xFC after VIFE combinable 
            if (vib.Extension == 0xFC)
            {
                Message message = this.GetCombinableVifeExtensionFc(ref data, ref vib);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }
            }

            // Vif custom string
            if ((vib.VifByte == 0xFC || vib.VifByte == 0x7C) && vib.Extension == null)
            {
                Message message = this.GetCustomString(ref data, ref vib);
                if (message.IsError)
                {
                    vibCalculatorMessage.AddErrors(message.Errors);
                    return vibCalculatorMessage;
                }
            }

            vibCalculatorMessage.SetVib(vib);
            return vibCalculatorMessage;
        }

        private Message GetManufacturerSpecificVifeAfterPrimaryVif(ref Queue<Byte> data, ref Vib vib, ref Byte[]? manufacturer)
        {
            Message message = new();

            IManufacturerCalculator manufacturerCalculator = ManufacturerCalculator.GetCalculator();
            ManufacturerCalculatorMessage manufacturerCalculatorMessage = manufacturerCalculator.CalculateManufacturer(ref manufacturer);
            if (manufacturerCalculatorMessage.IsError)
            {
                message = new();
                message.AddErrors(manufacturerCalculatorMessage.Errors);
                return message;
            }

            switch (manufacturerCalculatorMessage.Manufacturer)
            {
                case Manufacturer.Abb:
                    IAbbVibCalculator abbVibCalculator = AbbVibCalculator.GetCalculator();
                    message = abbVibCalculator.CalculateManufacturerSpecificVifeAfterPrimaryVif(ref data, ref vib);
                    if (message.IsError)
                    {
                        message.AddErrors(message.Errors);
                    }
                    break;

                case Manufacturer.Schneider:
                    ISchneiderVibCalculator schneiderVibCalculator = SchneiderVibCalculator.GetCalculator();
                    message = schneiderVibCalculator.CalculateManufacturerSpecificVifeAfterPrimaryVif(ref data, ref vib);
                    if (message.IsError)
                    {
                        message.AddErrors(message.Errors);
                    }
                    break;

                case Manufacturer.Unknown:
                    IUnknownVibCalculator unknownVibCalculator = UnknownVibCalculator.GetCalculator();
                    message = unknownVibCalculator.CalculateManufacturerSpecificVifeAfterPrimaryVif(ref data, ref vib);
                    if (message.IsError)
                    {
                        message.AddErrors(message.Errors);
                    }
                    break;
            }

            return message;
        }

        private Message GetExtensionEfAfterPrimaryVif(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            VifVife vife = VifVifeMatrix.GetVifeEF(data.Dequeue());

            vib.VifeBytes.Add(vife.VifVifeByte);
            vib.Extension = vife.Extension;
            vib.DataType = vife.DataType;
            vib.Unit = vife.Unit;
            vib.Description = vife.Description;
            vib.Magnitude = vife.Magnitude;

            return message;
        }

        private Message GetExtensionFbAfterPrimaryVif(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            VifVife vife = VifVifeMatrix.GetVifeFB(data.Dequeue());

            vib.VifeBytes.Add(vife.VifVifeByte);
            vib.Extension = vife.Extension;
            vib.DataType = vife.DataType;
            vib.Unit = vife.Unit;
            vib.Description = vife.Description;
            vib.Magnitude = vife.Magnitude;

            return message;
        }

        private Message GetExtensionFdAfterPrimaryVif(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            VifVife vife = VifVifeMatrix.GetVifeFD(data.Dequeue());

            vib.VifeBytes.Add(vife.VifVifeByte);
            vib.Extension = vife.Extension;
            vib.DataType = vife.DataType;
            vib.Unit = vife.Unit;
            vib.Description = vife.Description;
            vib.Magnitude = vife.Magnitude;

            return message;
        }

        private Message GetCombinableVife(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            VifVife vife = VifVifeMatrix.GetVifeCombinable(data.Dequeue());

            vib.VifeBytes.Add(vife.VifVifeByte);
            vib.Extension = vife.Extension;

            if (vib.Extension == 0x7F || vib.Extension == 0xFF || vib.Extension == 0xFC)
            {
                return message;
            }

            vib.Description = (vib.Description + " " + vife.Description).Trim();

            if (vife.Magnitude != null)
            {
                vib.Magnitude = vife.Magnitude;
            }

            if (vife.DataType != null)
            {
                vib.DataType = vife.DataType;
            }

            return message;
        }

        private Message GetManufacturerSpecificVifeAfterCombinableyVife(ref Queue<Byte> data, ref Vib vib, ref Byte[]? manufacturer)
        {
            Message message = new();

            IManufacturerCalculator manufacturerCalculator = ManufacturerCalculator.GetCalculator();
            ManufacturerCalculatorMessage manufacturerCalculatorMessage = manufacturerCalculator.CalculateManufacturer(ref manufacturer);
            if (manufacturerCalculatorMessage.IsError)
            {
                message = new();
                message.AddErrors(manufacturerCalculatorMessage.Errors);
                return message;
            }

            switch (manufacturerCalculatorMessage.Manufacturer)
            {
                case Manufacturer.Abb:
                    IAbbVibCalculator abbVibCalculator = AbbVibCalculator.GetCalculator();
                    message = abbVibCalculator.CalculateManufacturerSpecificVifeAfterCombinableVife(ref data, ref vib);
                    if (message.IsError)
                    {
                        message.AddErrors(message.Errors);
                    }
                    break;

                case Manufacturer.Schneider:
                    ISchneiderVibCalculator schneiderVibCalculator = SchneiderVibCalculator.GetCalculator();
                    message = schneiderVibCalculator.CalculateManufacturerSpecificVifeAfterCombinableVife(ref data, ref vib);
                    if (message.IsError)
                    {
                        message.AddErrors(message.Errors);
                    }
                    break;

                case Manufacturer.Unknown:
                    IUnknownVibCalculator unknownVibCalculator = UnknownVibCalculator.GetCalculator();
                    message = unknownVibCalculator.CalculateManufacturerSpecificVifeAfterCombinableVife(ref data, ref vib);
                    if (message.IsError)
                    {
                        message.AddErrors(message.Errors);
                    }
                    break;
            }

            return message;
        }

        private Message GetCombinableVifeExtensionFc(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            VifVife vife = VifVifeMatrix.GetVifeCombinableFC(data.Dequeue());

            vib.VifeBytes.Add(vife.VifVifeByte);
            vib.Extension = vife.Extension;
            vib.Description = (vib.Description + " " + vife.Description).Trim();

            return message;
        }

        private Message GetCustomString(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            Byte stringLength = data.Dequeue();
            vib.VifeBytes.Add(stringLength);

            if (data.Count < stringLength)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            List<Byte> textBytes = new(data.DequeueChunk(stringLength));
            vib.VifeBytes.AddRange(textBytes);
            textBytes.Reverse();
            String text = Encoding.UTF8.GetString(textBytes.ToArray());

            vib.DataType = VibDataType.Numeric;
            vib.Description = (text + " " + vib.Description).Trim();

            return message;
        }
    }
}