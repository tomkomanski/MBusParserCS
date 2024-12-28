using MBusParserCS.Models;

namespace MBusParserCS.Matrices
{
    internal static partial class VifVifeMatrix
    {
        public static VifVife GetVifeCombinable(Byte vifVifeByte)
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
                /* error */
                case 0x00:
                    vifVife.Unit = "";
                    vifVife.Description = "No error";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x01:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: too many DIFEs";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x02:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: storage number not implemented";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x03:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: Unit number not implemented";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x04:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: tariff number not implemented";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x05:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: function not implemented";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x06:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: data class not implemented";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x07:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: data size not implemented";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x08:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x09:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0A:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0B:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: too many VIFEs";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0C:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: illegal VIF group";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0D:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: illegal VIF exponent";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0E:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: VIF/DIF mismatch";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0F:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: unimplemented action";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                /* reserved */
                case 0x10:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x11:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x12:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x13:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x14:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                /* error */
                case 0x15:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: no data available";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x16:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: data overflow";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x17:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: data underflow";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x18:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: data error";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x19:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1A:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1B:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1C:
                    vifVife.Unit = "";
                    vifVife.Description = "Error: premature end of record";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                /* Others */
                case 0x1D:
                    vifVife.Unit = "";
                    vifVife.Description = "Standard conform data content";
                    vifVife.Magnitude = null;
                    vifVife.DataType = VibDataType.StandardConformData;
                    break;

                case 0x1E:
                    vifVife.Unit = "";
                    vifVife.Description = "Compact profile with register";
                    vifVife.Magnitude = null;
                    vifVife.DataType = VibDataType.CompactProfileWithRegister;
                    break;

                case 0x1F:
                    vifVife.Unit = "";
                    vifVife.Description = "Compact profile";
                    vifVife.Magnitude = null;
                    vifVife.DataType = VibDataType.CompactProfile;
                    break;

                case 0x20:
                    vifVife.Unit = "";
                    vifVife.Description = "Per second";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x21:
                    vifVife.Unit = "";
                    vifVife.Description = "Per minute";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x22:
                    vifVife.Unit = "";
                    vifVife.Description = "Per hour";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x23:
                    vifVife.Unit = "";
                    vifVife.Description = "Per day";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x24:
                    vifVife.Unit = "";
                    vifVife.Description = "Per week";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x25:
                    vifVife.Unit = "";
                    vifVife.Description = "Per month";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x26:
                    vifVife.Unit = "";
                    vifVife.Description = "Per year";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x27:
                    vifVife.Unit = "";
                    vifVife.Description = "Per revolution/measurement";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x28:
                    vifVife.Unit = "";
                    vifVife.Description = "Increment per input pulse on imput channel number 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x29:
                    vifVife.Unit = "";
                    vifVife.Description = "Increment per input pulse on imput channel number 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2A:
                    vifVife.Unit = "";
                    vifVife.Description = "Increment per output pulse on output channel number 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2B:
                    vifVife.Unit = "";
                    vifVife.Description = "Increment per output pulse on output channel number 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2C:
                    vifVife.Unit = "";
                    vifVife.Description = "Per litre";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2D:
                    vifVife.Unit = "";
                    vifVife.Description = "Per \u00B3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2E:
                    vifVife.Unit = "";
                    vifVife.Description = "Per kg";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2F:
                    vifVife.Unit = "";
                    vifVife.Description = "Per K";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x30:
                    vifVife.Unit = "";
                    vifVife.Description = "Per kWh";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x31:
                    vifVife.Unit = "";
                    vifVife.Description = "Per GJ";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x32:
                    vifVife.Unit = "";
                    vifVife.Description = "Per kW";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x33:
                    vifVife.Unit = "";
                    vifVife.Description = "Per (K*l";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x34:
                    vifVife.Unit = "";
                    vifVife.Description = "Per V";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x35:
                    vifVife.Unit = "";
                    vifVife.Description = "Per A";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x36:
                    vifVife.Unit = "";
                    vifVife.Description = "Multiplied by s";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x37:
                    vifVife.Unit = "";
                    vifVife.Description = "Multiplied by s/V";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x38:
                    vifVife.Unit = "";
                    vifVife.Description = "Multiplied by s/A";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x39:
                    vifVife.Unit = "";
                    vifVife.Description = "Start date/time";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3A:
                    vifVife.Unit = "";
                    vifVife.Description = "VIF contains uncorrected Unit or value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3B:
                    vifVife.Unit = "";
                    vifVife.Description = "Accumulation only if positive contributions";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3C:
                    vifVife.Unit = "";
                    vifVife.Description = "Accumulation of abs value only if negative contributions";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved for alternative non-metric Unit system";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3E:
                    vifVife.Unit = "";
                    vifVife.Description = "Value at base conditions";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3F:
                    vifVife.Unit = "";
                    vifVife.Description = "OBIS-declaration";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x40:
                    vifVife.Unit = "";
                    vifVife.Description = "Lower limit value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x41:
                    vifVife.Unit = "";
                    vifVife.Description = "Number of exceeds of lower";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x42:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of begin/first/lower";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x43:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of end/first/lower";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x44:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x45:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x46:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of begin/last/lower";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x47:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of end/last/lower";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x48:
                    vifVife.Unit = "";
                    vifVife.Description = "Upper limit value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x49:
                    vifVife.Unit = "";
                    vifVife.Description = "Number of exceeds of upper";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4A:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of begin/first/upper";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4B:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of end/first/upper";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4C:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4E:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of begin/last/upper";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4F:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of end/last/upper";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x50:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 0, 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x51:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 0, 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x52:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 0, 2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x53:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 0, 3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x54:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 1, 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x55:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 1, 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x56:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 1, 2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x57:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 0, 1, 3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x58:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 0, 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x59:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 0, 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5A:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 0, 2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5B:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 0, 3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5C:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 1, 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5D:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 1, 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5E:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 1, 2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5F:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of limit exceed 1, 1, 3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x60:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 0, 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x61:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 0, 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x62:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 0, 2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x63:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 0, 3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x64:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 1, 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x65:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 1, 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x66:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 1, 2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x67:
                    vifVife.Unit = "";
                    vifVife.Description = "Duration of 1, 3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x68:
                    vifVife.Unit = "";
                    vifVife.Description = "Value during lower limit exceed";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x69:
                    vifVife.Unit = "";
                    vifVife.Description = "Leakage values";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6A:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of 0 above 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6B:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of 0 above 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6C:
                    vifVife.Unit = "";
                    vifVife.Description = "Value during upper limit exceed";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6D:
                    vifVife.Unit = "";
                    vifVife.Description = "Overflow values";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6E:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of 1 above 0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6F:
                    vifVife.Unit = "";
                    vifVife.Description = "Date/time of 1 above 1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x70:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 0 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x71:
                    vifVife.Description = "";
                    vifVife.Magnitude = 1 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x72:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 2 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x73:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 3 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x74:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 4 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x75:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 5 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x76:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 6 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x77:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 7 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x78:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x79:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7A:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7B:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7C:
                    vifVife.Extension = vifVifeByte;
                    vifVife.Unit = "";
                    vifVife.Description = "Extension combinable case 0xFC";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7D:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7E:
                    vifVife.Unit = "";
                    vifVife.Description = "Future value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7F:
                    vifVife.Extension = vifVifeByte;
                    vifVife.Unit = "";
                    vifVife.Description = "VIFEs and data of this block are manufacturer specific";
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