using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Calculators
{
    internal sealed class ManufacturerCalculator : IManufacturerCalculator
    {
        private static ManufacturerCalculator? instance;
        public static ManufacturerCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new ManufacturerCalculator();
            }
            return instance;
        }

        private ManufacturerCalculator()
        {
        }

        public ManufacturerCalculatorMessage CalculateManufacturer(ref Byte[]? manufacturerBytes)
        {
            ManufacturerCalculatorMessage manufacturerCalculatorMessage = new();
            manufacturerCalculatorMessage.SetManufacturer(Manufacturer.Unknown);

            if (manufacturerBytes != null)
            {
                if (manufacturerBytes.Length != 2)
                {
                    manufacturerCalculatorMessage.AddErrorCode(ErrorCode.ManufacturerError);
                    return manufacturerCalculatorMessage;
                }

                manufacturerCalculatorMessage.SetManufacturer(this.GetManufacturer(ref manufacturerBytes));
                manufacturerCalculatorMessage.SetManufacturerCode(this.GetManufacturerCode(ref manufacturerBytes));
            }

            return manufacturerCalculatorMessage;
        }

        private Manufacturer GetManufacturer(ref Byte[] manufacturerBytes)
        {
            switch (manufacturerBytes)
            {
                case [0x42, 0x04]:
                    return Manufacturer.Abb;
                case [0xA3, 0x4C]:
                    return Manufacturer.Schneider;
                default:
                    return Manufacturer.Unknown;
            }
        }

        private String GetManufacturerCode(ref Byte[] manufacturerBytes)
        {
            UInt16 manufacturer = BitConverter.ToUInt16(manufacturerBytes, 0);

            Char[] chr = new Char[3];

            for (Int32 i = chr.Length - 1; i >= 0; i--)
            {
                chr[i] = Convert.ToChar((manufacturer % 32) + 64);
                manufacturer = (UInt16)((manufacturer - (manufacturer % 32)) / 32);
            }

            return new String(chr);
        }
    }
}