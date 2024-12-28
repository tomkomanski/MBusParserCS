﻿using MBusParserCS.Calculators.ManufacturerSpecificVib.Interfaces;
using MBusParserCS.Matrices;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators.ManufacturerSpecificVib
{
    internal sealed class SchneiderVibCalculator : ISchneiderVibCalculator
    {
        private static SchneiderVibCalculator? instance;

        public static SchneiderVibCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new SchneiderVibCalculator();
            }
            return instance;
        }

        private SchneiderVibCalculator()
        {
        }

        public Message CalculateManufacturerSpecificVifeAfterPrimaryVif(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            VifVife vife = VifVifeMatrix.GetVifeSchneider(data.Dequeue());

            vib.VifeBytes.Add(vife.VifVifeByte);
            vib.Extension = vife.Extension;
            vib.DataType = vife.DataType;
            vib.Unit = vife.Unit;
            vib.Description = vife.Description;
            vib.Magnitude = vife.Magnitude;

            while (vib.Extension != null)
            {
                if (data.Count < 1)
                {
                    message.AddErrorCode(ErrorCode.VibCalculatorError);
                    return message;
                }

                Nullable<Byte> extension = null;
                Byte vifeByte = data.Dequeue();

                if ((vifeByte & 0x80) >> 7 == 1)
                {
                    extension = vifeByte;
                }

                vib.VifeBytes.Add(vifeByte);
                vib.Extension = extension;
            }

            return message;
        }

        public Message CalculateManufacturerSpecificVifeAfterCombinableVife(ref Queue<Byte> data, ref Vib vib)
        {
            Message message = new();

            if (data.Count < 1)
            {
                message.AddErrorCode(ErrorCode.VibCalculatorError);
                return message;
            }

            VifVife vife = VifVifeMatrix.GetVifeSchneider(data.Dequeue());

            vib.VifeBytes.Add(vife.VifVifeByte);
            vib.Extension = vife.Extension;
            vib.Description = (vib.Description + " " + vife.Description).Trim();

            while (vib.Extension != null)
            {
                if (data.Count < 1)
                {
                    message.AddErrorCode(ErrorCode.VibCalculatorError);
                    return message;
                }

                Nullable<Byte> extension = null;
                Byte vifeByte = data.Dequeue();

                if ((vifeByte & 0x80) >> 7 == 1)
                {
                    extension = vifeByte;
                }

                vib.VifeBytes.Add(vifeByte);
                vib.Extension = extension;
            }

            return message;
        }
    }
}