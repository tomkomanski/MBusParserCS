using MBusParserCS.Models;

namespace MBusParserCS.Matrices
{
    internal static partial class VifVifeMatrix
    {
        public static VifVife GetVifeFB(Byte vifVifeByte)
        {
            Byte vifByteWithoutExtension = (Byte)(vifVifeByte & 0x7F);
            Byte? extension = null;
            if ((vifVifeByte & 0x80) >> 7 == 1)
            {
                extension = vifVifeByte;
            }

            VifVife vifVife = new()
            {
                VifVifeByte = vifVifeByte,
                Extension = extension,
                Unit = "",
                Description = "",
                Magnitude = null,
                DataType = null,
            };

            switch (vifByteWithoutExtension)
            {
                /* Energy */
                case 0x00:
                    vifVife.Unit = "MWh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 0 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x01:
                    vifVife.Unit = "MWh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 1 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reactive energy */
                case 0x02:
                    vifVife.Unit = "kVARh";
                    vifVife.Description = "Reactive energy";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x03:
                    vifVife.Unit = "kVARh";
                    vifVife.Description = "Reactive energy";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Apparent energy */
                case 0x04:
                    vifVife.Unit = "kVAh";
                    vifVife.Description = "Apparent energy";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x05:
                    vifVife.Unit = "kVAh";
                    vifVife.Description = "Apparent energy";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reserved */
                case 0x06:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x07:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Energy */
                case 0x08:
                    vifVife.Unit = "GJ";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 0 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x09:
                    vifVife.Unit = "GJ";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 1 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reserved */
                case 0x0A:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0B:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Energy */
                case 0x0C:
                    vifVife.Unit = "MCal";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 0 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0D:
                    vifVife.Unit = "MCal";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 1 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0E:
                    vifVife.Unit = "MCal";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 2 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0F:
                    vifVife.Unit = "MCal";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 3 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Volume */
                case 0x10:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 0 + 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x11:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 1 + 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reserved */
                case 0x12:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x13:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reactive power */
                case 0x14:
                    vifVife.Unit = "kVAR";
                    vifVife.Description = "Reactive power";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x15:
                    vifVife.Unit = "kVAR";
                    vifVife.Description = "Reactive power";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x16:
                    vifVife.Unit = "kVAR";
                    vifVife.Description = "Reactive power";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x17:
                    vifVife.Unit = "kVAR";
                    vifVife.Description = "Reactive power";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Mass */
                case 0x18:
                    vifVife.Unit = "t";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 0 + 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x19:
                    vifVife.Unit = "t";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 1 + 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Relative humidity */
                case 0x1A:
                    vifVife.Unit = "%";
                    vifVife.Description = "Relative humidity";
                    vifVife.Magnitude = 0 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1B:
                    vifVife.Unit = "%";
                    vifVife.Description = "Relative humidity";
                    vifVife.Magnitude = 1 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reserved */
                case 0x1C:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1E:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1F:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Volume */
                case 0x20:
                    vifVife.Unit = "feet\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x21:
                    vifVife.Unit = "0,1 feet\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reserved */
                case 0x22:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x23:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x24:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x25:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x26:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x27:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Power */
                case 0x28:
                    vifVife.Unit = "MW";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 0 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x29:
                    vifVife.Unit = "MW";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 1 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Phase */
                case 0x2A:
                    vifVife.Unit = "";
                    vifVife.Description = "Phase U-U";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2B:
                    vifVife.Unit = "";
                    vifVife.Description = "Phase U-I";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Frequency */
                case 0x2C:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2D:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2E:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2F:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Power */
                case 0x30:
                    vifVife.Unit = "GJ/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 0 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x31:
                    vifVife.Unit = "GJ/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 1 - 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reserved */
                case 0x32:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x33:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Apparent power */
                case 0x34:
                    vifVife.Unit = "kVA";
                    vifVife.Description = "Apparent power";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x35:
                    vifVife.Unit = "kVA";
                    vifVife.Description = "Apparent power";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x36:
                    vifVife.Unit = "kVA";
                    vifVife.Description = "Apparent power";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x37:
                    vifVife.Unit = "kVA";
                    vifVife.Description = "Apparent power";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Reserved */
                case 0x38:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x39:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3A:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3B:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3C:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3E:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3F:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x40:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x41:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x42:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x43:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x44:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x45:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x46:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x47:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x48:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x49:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4A:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4B:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4C:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4E:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4F:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x50:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x51:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x52:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x53:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x54:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x55:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x56:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x57:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x58:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x59:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5A:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5B:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5C:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5E:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5F:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x60:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x61:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x62:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x63:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x64:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x65:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x66:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x67:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x68:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x69:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6A:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6B:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6C:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6E:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6F:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x70:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x71:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x72:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x73:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Cold/warm temperature limit */
                case 0x74:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Cold/warm temperature limit";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x75:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Cold/warm temperature limit";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x76:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Cold/warm temperature limit";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x77:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Cold/warm temperature limit";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Cumulative max of active power */
                case 0x78:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x79:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7A:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7B:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7C:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 4 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7D:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 5 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7E:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 6 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7F:
                    vifVife.Unit = "W";
                    vifVife.Description = "Cumulative max of active power";
                    vifVife.Magnitude = 7 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                default:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;
            }

            return vifVife;
        }
    }
}