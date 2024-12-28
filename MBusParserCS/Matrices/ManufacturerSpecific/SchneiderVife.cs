using MBusParserCS.Models;

namespace MBusParserCS.Matrices
{
    internal static partial class VifVifeMatrix
    {
        // Based on iEM31, iEM32 and iEM33
        public static VifVife GetVifeSchneider(Byte vifVifeByte)
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
                    vifVife.Description = "Average current";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x01:
                    vifVife.Unit = "";
                    vifVife.Description = "L1 value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x02:
                    vifVife.Unit = "";
                    vifVife.Description = "L2 value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x03:
                    vifVife.Unit = "";
                    vifVife.Description = "L3 value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x04:
                    vifVife.Unit = "";
                    vifVife.Description = "L-N avg";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x05:
                    vifVife.Unit = "";
                    vifVife.Description = "L1-L2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x06:
                    vifVife.Unit = "";
                    vifVife.Description = "L2-L3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x07:
                    vifVife.Unit = "";
                    vifVife.Description = "L3-L1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x08:
                    vifVife.Unit = "";
                    vifVife.Description = "L-L avg";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x09:
                    vifVife.Unit = "";
                    vifVife.Description = "Export energy value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x0A:
                    vifVife.Unit = "";
                    vifVife.Description = "Power factor";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    return vifVife;

                case 0x0B:
                    vifVife.Unit = "Hz";
                    vifVife.Description = "Frequency";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    return vifVife;

                case 0x0C:
                    vifVife.Unit = "";
                    vifVife.Description = "Energy reset date and time";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x0D:
                    vifVife.Unit = "";
                    vifVife.Description = "Partial energy value";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x0E:
                    vifVife.Unit = "";
                    vifVife.Description = "Input metering reset date and time";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x0F:
                    vifVife.Unit = "";
                    vifVife.Description = "Input metering accumulation";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x10:
                    vifVife.Unit = "";
                    vifVife.Description = "Active tariff (Energy active rate)";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x11:
                    vifVife.Unit = "";
                    vifVife.Description = "Tariff control mode";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x12:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x13:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x14:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x15:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x16:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x17:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x18:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x19:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x1A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x1B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x1C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x1D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x1E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x1F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x20:
                    vifVife.Unit = "";
                    vifVife.Description = "Meter operation timer";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x21:
                    vifVife.Unit = "";
                    vifVife.Description = "Number of phases";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x22:
                    vifVife.Unit = "";
                    vifVife.Description = "Number of wires";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x23:
                    vifVife.Unit = "";
                    vifVife.Description = "Power system configuration";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x24:
                    vifVife.Unit = "";
                    vifVife.Description = "Nominal frequency";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x25:
                    vifVife.Unit = "";
                    vifVife.Description = "Number of VTs";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x26:
                    vifVife.Unit = "";
                    vifVife.Description = "VT primary";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x27:
                    vifVife.Unit = "";
                    vifVife.Description = "VT secondary";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x28:
                    vifVife.Unit = "";
                    vifVife.Description = "Number of CTs";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x29:
                    vifVife.Unit = "";
                    vifVife.Description = "CT primary";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x2A:
                    vifVife.Unit = "";
                    vifVife.Description = "CT secondary";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x2B:
                    vifVife.Unit = "";
                    vifVife.Description = "VT connection type";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x2C:
                    vifVife.Unit = "";
                    vifVife.Description = "Energy pulse duration";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x2D:
                    vifVife.Unit = "";
                    vifVife.Description = "Digital output association with active energy pulsing";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x2E:
                    vifVife.Unit = "";
                    vifVife.Description = "Pulse weight";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x2F:
                    vifVife.Unit = "";
                    vifVife.Description = "Pulse constant";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x30:
                    vifVife.Unit = "";
                    vifVife.Description = "Digital input association";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x31:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x32:
                    vifVife.Unit = "";
                    vifVife.Description = "Digital input status";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x33:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x34:
                    vifVife.Unit = "";
                    vifVife.Description = "Overload alarm setup";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x35:
                    vifVife.Unit = "";
                    vifVife.Description = "Pickup setpoint";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x36:
                    vifVife.Unit = "";
                    vifVife.Description = "Digital output association with overload alarm";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x37:
                    vifVife.Unit = "";
                    vifVife.Description = "Activated status";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x38:
                    vifVife.Unit = "";
                    vifVife.Description = "Acknowledgment";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x39:
                    vifVife.Unit = "";
                    vifVife.Description = "Date and time of last alarm";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x3A:
                    vifVife.Unit = "";
                    vifVife.Description = "Value at last alarm";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x3B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x3C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x3D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x3E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x3F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x40:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x41:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x42:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x43:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x44:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x45:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x46:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x47:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x48:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x49:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x4A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x4B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x4C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x4D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x4E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x4F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x50:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x51:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x52:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x53:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x54:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x55:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x56:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x57:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x58:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x59:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x5A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x5B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x5C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x5D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x5E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x5F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x60:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x61:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x62:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x63:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x64:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x65:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x66:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x67:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x68:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x69:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x6A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x6B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x6C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x6D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x6E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x6F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x70:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x71:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x72:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x73:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x74:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x75:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x76:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x77:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x78:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x79:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x7A:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x7B:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x7C:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x7D:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x7E:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

                case 0x7F:
                    vifVife.Unit = "";
                    vifVife.Description = "Not implemented in parser";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    return vifVife;

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