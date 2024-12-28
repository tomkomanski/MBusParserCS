using MBusParserCS.Models;

namespace MBusParserCS.Matrices
{
    internal static partial class VifVifeMatrix
    {
        public static VifVife GetVifPrimary(Byte vifVifeByte)
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
                /* E000 0nnn    Energy Wh (0.001Wh to 10000Wh) */
                case 0x00:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x01:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x02:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x03:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x04:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 4 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x05:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 5 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x06:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 6 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x07:
                    vifVife.Unit = "Wh";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 7 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E000 1nnn    Energy  J (0.001kJ to 10000kJ) */
                case 0x08:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x09:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0A:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0B:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0C:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 4;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0D:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 5;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0E:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0F:
                    vifVife.Unit = "J";
                    vifVife.Description = "Energy";
                    vifVife.Magnitude = 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E001 0nnn    Volume m3 (0.001l to 10000l) */
                case 0x10:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 0 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x11:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 1 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x12:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 2 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x13:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 3 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x14:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 4 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x15:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 5 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x16:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 6 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x17:
                    vifVife.Unit = "m\u00B3";
                    vifVife.Description = "Volume";
                    vifVife.Magnitude = 7 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E001 1nnn    Mass kg (0.001kg to 10000kg) */
                case 0x18:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x19:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1A:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1B:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1C:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 4 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1D:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 5 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1E:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 6 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1F:
                    vifVife.Unit = "kg";
                    vifVife.Description = "Mass";
                    vifVife.Magnitude = 7 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E010 00nn    On Time s */
                case 0x20:
                    vifVife.Unit = "second";
                    vifVife.Description = "On time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x21:
                    vifVife.Unit = "minute";
                    vifVife.Description = "On time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x22:
                    vifVife.Unit = "hour";
                    vifVife.Description = "On time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x23:
                    vifVife.Unit = "day";
                    vifVife.Description = "On time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E010 01nn    Operating Time s */
                case 0x24:
                    vifVife.Unit = "second";
                    vifVife.Description = "Operating time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x25:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Operating time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x26:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Operating time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x27:
                    vifVife.Unit = "day";
                    vifVife.Description = "Operating time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E010 1nnn    Power W (0.001W to 10000W) */
                case 0x28:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x29:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2A:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2B:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2C:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 4 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2D:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 5 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2E:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 6 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2F:
                    vifVife.Unit = "W";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 7 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E011 0nnn    Power J/h (0.001kJ/h to 10000kJ/h) */
                case 0x30:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x31:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 1;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x32:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 2;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x33:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x34:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 4;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x35:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 5;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x36:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x37:
                    vifVife.Unit = "J/h";
                    vifVife.Description = "Power";
                    vifVife.Magnitude = 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E011 1nnn    Volume Flow m3/h (0.001l/h to 10000l/h) */
                case 0x38:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 0 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x39:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 1 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3A:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 2 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3B:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 3 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3C:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 4 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3D:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 5 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3E:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 6 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3F:
                    vifVife.Unit = "m\u00B3/h";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 7 - 6;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E100 0nnn     Volume Flow ext.  m3/min (0.0001l/min to 1000l/min) */
                case 0x40:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 0 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x41:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 1 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x42:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 2 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x43:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 3 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x44:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 4 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x45:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 5 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x46:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 6 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x47:
                    vifVife.Unit = "m\u00B3/min";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 7 - 7;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E100 1nnn     Volume Flow ext.  m3/s (0.001ml/s to 10000ml/s) */
                case 0x48:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 0 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x49:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 1 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4A:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 2 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4B:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 3 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4C:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 4 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4D:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 5 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4E:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 6 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4F:
                    vifVife.Unit = "m\u00B3/s";
                    vifVife.Description = "Volume flow";
                    vifVife.Magnitude = 7 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E101 0nnn     Mass flow kg/h (0.001kg/h to 10000kg/h) */
                case 0x50:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x51:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x52:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x53:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x54:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 4 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x55:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 5 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x56:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 6 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x57:
                    vifVife.Unit = "kg/h";
                    vifVife.Description = "Mass flow";
                    vifVife.Magnitude = 7 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E101 10nn     Flow Temperature °C (0.001°C to 1°C) */
                case 0x58:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Flow temperature";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x59:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Flow temperature";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5A:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Flow temperature";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5B:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Flow temperature";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E101 11nn     Return Temperature °C (0.001°C to 1°C) */
                case 0x5C:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Return temperature";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5D:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Return temperature";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5E:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Return temperature";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5F:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "Return temperature";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E110 00nn    Temperature Difference  K   (mK to  K) */
                case 0x60:
                    vifVife.Unit = "K";
                    vifVife.Description = "Temperature difference";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x61:
                    vifVife.Unit = "K";
                    vifVife.Description = "Temperature difference";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x62:
                    vifVife.Unit = "K";
                    vifVife.Description = "Temperature difference";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x63:
                    vifVife.Unit = "K";
                    vifVife.Description = "Temperature difference";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E110 01nn     External Temperature °C (0.001°C to 1°C) */
                case 0x64:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "External temperature";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x65:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "External temperature";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x66:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "External temperature";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x67:
                    vifVife.Unit = "\u00B0C";
                    vifVife.Description = "External temperature";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E110 10nn     Pressure bar (1mbar to 1000mbar) */
                case 0x68:
                    vifVife.Unit = "bar";
                    vifVife.Description = "Pressure";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x69:
                    vifVife.Unit = "bar";
                    vifVife.Description = "Pressure";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6A:
                    vifVife.Unit = "bar";
                    vifVife.Description = "Pressure";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6B:
                    vifVife.Unit = "bar";
                    vifVife.Description = "Pressure";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E110 110n     Time Point */
                case 0x6C:
                    vifVife.Unit = "";
                    vifVife.Description = "Time point (date)";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.DataTypeG;
                    break;

                case 0x6D:
                    vifVife.Unit = "";
                    vifVife.Description = "Time point (date & time)";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.DataTypeFJIM;
                    break;

                /* E110 1110     Units for H.C.A. dimensionless */
                case 0x6E:
                    vifVife.Unit = "";
                    vifVife.Description = "H.C.A.";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E110 1111     Reserved extension for 0xEF*/
                case 0x6F:
                    vifVife.Unit = "";
                    vifVife.Description = "Extension 0xEF";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                /* E111 00nn     Averaging duration s */
                case 0x70:
                    vifVife.Unit = "second";
                    vifVife.Description = "Averaging duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x71:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Averaging duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x72:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Averaging duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x73:
                    vifVife.Unit = "day";
                    vifVife.Description = "Averaging duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* E111 01nn     Actuality duration s */
                case 0x74:
                    vifVife.Unit = "second";
                    vifVife.Description = "Actuality duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x75:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Actuality duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x76:
                    vifVife.Unit = "hours";
                    vifVife.Description = "Actuality duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x77:
                    vifVife.Unit = "day";
                    vifVife.Description = "Actuality duration";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Other */
                case 0x78:
                    vifVife.Unit = "";
                    vifVife.Description = "Fabrication No";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x79:
                    vifVife.Unit = "";
                    vifVife.Description = "(Enhanced) Identification";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7A:
                    vifVife.Unit = "";
                    vifVife.Description = "Bus Address";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Other */
                case 0x7B:
                    vifVife.Unit = "";
                    vifVife.Description = "Extension 0xFB";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7C:
                    vifVife.Unit = "";
                    vifVife.Description = "";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.CustomString;
                    break;

                case 0x7D:
                    vifVife.Unit = "";
                    vifVife.Description = "Extension 0xFD";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7E:
                    vifVife.Unit = "";
                    vifVife.Description = "Any VIF";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.AnyVif;
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