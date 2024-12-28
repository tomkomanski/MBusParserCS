using MBusParserCS.Models;

namespace MBusParserCS.Matrices
{
    internal static partial class VifVifeMatrix
    {
        // Based on B23 and B24
        public static VifVife GetVifeAbb(Byte vifVifeByte)
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
                case 0x00:
                    vifVife.Unit = "";
                    vifVife.Description = "Total";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x01:
                    vifVife.Unit = "";
                    vifVife.Description = "L1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x02:
                    vifVife.Unit = "";
                    vifVife.Description = "L2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x03:
                    vifVife.Unit = "";
                    vifVife.Description = "L3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x04:
                    vifVife.Unit = "";
                    vifVife.Description = "N";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x05:
                    vifVife.Unit = "";
                    vifVife.Description = "L1-L2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x06:
                    vifVife.Unit = "";
                    vifVife.Description = "L3-L2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x07:
                    vifVife.Unit = "";
                    vifVife.Description = "L1-L3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x08:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x09:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x10:
                    vifVife.Unit = "";
                    vifVife.Description = "Pulse frequency";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x11:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x12:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x13:
                    vifVife.Unit = "";
                    vifVife.Description = "Tariff";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x14:
                    vifVife.Unit = "";
                    vifVife.Description = "Installation check";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x15:
                    vifVife.Unit = "";
                    vifVife.Description = "Status of values";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x16:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x17:
                    vifVife.Unit = "";
                    vifVife.Description = "Current quadrant";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x18:
                    vifVife.Unit = "";
                    vifVife.Description = "Power fail counter";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x19:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x20:
                    vifVife.Unit = "";
                    vifVife.Description = "Current transformer ratio numerator";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x21:
                    vifVife.Unit = "";
                    vifVife.Description = "Voltage transformer ratio numerator";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x22:
                    vifVife.Unit = "";
                    vifVife.Description = "Current transformer ratio denominator";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x23:
                    vifVife.Unit = "";
                    vifVife.Description = "Voltage transformer ratio denominator";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x24:
                    vifVife.Unit = "kg/kWh";
                    vifVife.Description = "CO2 conversion factor";
                    vifVife.Magnitude = -3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x25:
                    vifVife.Unit = "curr/kWh";
                    vifVife.Description = "Currency conversion factor";
                    vifVife.Magnitude = -3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x26:
                    vifVife.Unit = "";
                    vifVife.Description = "Error flags";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x27:
                    vifVife.Unit = "";
                    vifVife.Description = "Warning flags";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x28:
                    vifVife.Unit = "";
                    vifVife.Description = "Information flags";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x29:
                    vifVife.Unit = "";
                    vifVife.Description = "Alarm flags";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2A:
                    vifVife.Unit = "";
                    vifVife.Description = "Type designation";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2D:
                    vifVife.Unit = "";
                    vifVife.Description = "Number of elements";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x30:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x31:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x32:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x33:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x34:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x35:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x36:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x37:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x38:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x39:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                /* E100 0nnn     Phase angle voltage ° */
                case 0x40:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = -3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x41:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = -2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x42:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = -1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x43:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x44:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x45:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x46:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x47:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle voltage";
                    vifVife.Magnitude = 4;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E100 1nnn     Phase angle current ° */
                case 0x48:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = -3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x49:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = -2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4A:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = -1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4B:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4C:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4D:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4E:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4F:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle current";
                    vifVife.Magnitude = 4;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E101 0nnn     Phase angle power ° */
                case 0x50:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = -3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x51:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = -2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x52:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = -1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x53:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x54:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x55:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x56:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x57:
                    vifVife.Unit = "\u00B0";
                    vifVife.Description = "Phase angle power";
                    vifVife.Magnitude = 4;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E101 1nnn     Frequency */
                case 0x58:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = -3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x59:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = -2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5A:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = -1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5B:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5C:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5D:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5E:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5F:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 4;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E110 0nnn     Power factor */
                case 0x60:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = -3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x61:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = -2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x62:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = -1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x63:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x64:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x65:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x66:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x67:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = 4;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x68:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x69:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6A:
                    vifVife.Unit = "";
                    vifVife.Description = "Change communication write access level";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6F:
                    vifVife.Unit = "";
                    vifVife.Description = "Event type";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x70:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x71:
                    vifVife.Unit = "";
                    vifVife.Description = "Reset counter for energy";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x72:
                    vifVife.Unit = "";
                    vifVife.Description = "Resettable register";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x73:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x74:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x75:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x76:
                    vifVife.Unit = "";
                    vifVife.Description = "Sequence number (audit log)";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x77:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x78:
                    vifVife.Unit = "";
                    vifVife.Description = "Extension of manufacturer specific VIFE's, next VIFE(s) used for numbering";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x79:
                    vifVife.Unit = "";
                    vifVife.Description = "Extension of manufacturer specific VIFE's, next VIFE(s) specifies actual meaning";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7E:
                    vifVife.Unit = "";
                    vifVife.Description = "Extension of manufacturer specific VIFE's, next VIFE(s) used for manufacturer specific record errors/status";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
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