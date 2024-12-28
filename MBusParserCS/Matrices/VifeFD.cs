using MBusParserCS.Models;

namespace MBusParserCS.Matrices
{
    internal static partial class VifVifeMatrix
    {
        public static VifVife GetVifeFD(Byte vifVifeByte)
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
                /* Credit */
                case 0x00:
                    vifVife.Unit = "";
                    vifVife.Description = "Credit";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x01:
                    vifVife.Unit = "";
                    vifVife.Description = "Credit";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x02:
                    vifVife.Unit = "";
                    vifVife.Description = "Credit";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x03:
                    vifVife.Unit = "";
                    vifVife.Description = "Credit";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Debit */
                case 0x04:
                    vifVife.Unit = "";
                    vifVife.Description = "Debit";
                    vifVife.Magnitude = 0 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x05:
                    vifVife.Unit = "";
                    vifVife.Description = "Debit";
                    vifVife.Magnitude = 1 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x06:
                    vifVife.Unit = "";
                    vifVife.Description = "Debit";
                    vifVife.Magnitude = 2 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x07:
                    vifVife.Unit = "";
                    vifVife.Description = "Debit";
                    vifVife.Magnitude = 3 - 3;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Others */
                case 0x08:
                    vifVife.Unit = "";
                    vifVife.Description = "Access number";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x09:
                    vifVife.Unit = "";
                    vifVife.Description = "Device type";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0A:
                    vifVife.Unit = "";
                    vifVife.Description = "Manufacturer";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0B:
                    vifVife.Unit = "";
                    vifVife.Description = "Parameter set identification";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0C:
                    vifVife.Unit = "";
                    vifVife.Description = "Model version";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0D:
                    vifVife.Unit = "";
                    vifVife.Description = "Hardware version number";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0E:
                    vifVife.Unit = "";
                    vifVife.Description = "Metrology (firmware) version";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x0F:
                    vifVife.Unit = "";
                    vifVife.Description = "Other software version number";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x10:
                    vifVife.Unit = "";
                    vifVife.Description = "Customer location";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x11:
                    vifVife.Unit = "";
                    vifVife.Description = "Customer";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x12:
                    vifVife.Unit = "";
                    vifVife.Description = "Access code user";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x13:
                    vifVife.Unit = "";
                    vifVife.Description = "Access code operator";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x14:
                    vifVife.Unit = "";
                    vifVife.Description = "Access code system operato";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x15:
                    vifVife.Unit = "";
                    vifVife.Description = "Access code developer";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x16:
                    vifVife.Unit = "";
                    vifVife.Description = "Password";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x17:
                    vifVife.Unit = "";
                    vifVife.Description = "Error flags";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x18:
                    vifVife.Unit = "";
                    vifVife.Description = "Error mask";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x19:
                    vifVife.Unit = "";
                    vifVife.Description = "Security key";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1A:
                    vifVife.Unit = "";
                    vifVife.Description = "Digital output";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1B:
                    vifVife.Unit = "";
                    vifVife.Description = "Digital input";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1C:
                    vifVife.Unit = "";
                    vifVife.Description = "Baudrate";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1D:
                    vifVife.Unit = "";
                    vifVife.Description = "Response delay time";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1E:
                    vifVife.Unit = "";
                    vifVife.Description = "Retry";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x1F:
                    vifVife.Unit = "";
                    vifVife.Description = "Remote control";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x20:
                    vifVife.Unit = "";
                    vifVife.Description = "First storage number";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x21:
                    vifVife.Unit = "";
                    vifVife.Description = "Last storage nr";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x22:
                    vifVife.Unit = "";
                    vifVife.Description = "Size of storage block";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x23:
                    vifVife.Unit = "";
                    vifVife.Description = "Descriptor for tariff and subUnit";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Storage intervals */
                case 0x24:
                    vifVife.Unit = "second";
                    vifVife.Description = "Storage interval";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x25:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Storage interval";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x26:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Storage interval";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x27:
                    vifVife.Unit = "day";
                    vifVife.Description = "Storage interval";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x28:
                    vifVife.Unit = "month";
                    vifVife.Description = "Storage interval";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x29:
                    vifVife.Unit = "year";
                    vifVife.Description = "Storage interval";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Others */
                case 0x2A:
                    vifVife.Unit = "";
                    vifVife.Description = "Operator specific data";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2B:
                    vifVife.Unit = "";
                    vifVife.Description = "Time point second";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Duration since last readout */
                case 0x2C:
                    vifVife.Unit = "second";
                    vifVife.Description = "Duration since last readout";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2D:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Duration since last readout";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2E:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Duration since last readout";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x2F:
                    vifVife.Unit = "day";
                    vifVife.Description = "Duration since last readout";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Others */
                case 0x30:
                    vifVife.Unit = "";
                    vifVife.Description = "Start date/time of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Duration of tariff */
                case 0x31:
                    vifVife.Unit = "second";
                    vifVife.Description = "Duration of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x32:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Duration of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x33:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Duration of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Period of tariff */
                case 0x34:
                    vifVife.Unit = "second";
                    vifVife.Description = "Period of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x35:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Period of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x36:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Period of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x37:
                    vifVife.Unit = "day";
                    vifVife.Description = "Period of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x38:
                    vifVife.Unit = "month";
                    vifVife.Description = "Period of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x39:
                    vifVife.Unit = "year";
                    vifVife.Description = "Period of tariff";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Others */
                case 0x3A:
                    vifVife.Unit = "";
                    vifVife.Description = "Dimensionless";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3B:
                    vifVife.Unit = "";
                    vifVife.Description = "Data container for wireless M-Bus protocol";
                    vifVife.Magnitude = null;
                    vifVife.DataType = VibDataType.WirelessMbusDataContainer;
                    break;

                /* Period of nominal data transmissions */
                case 0x3C:
                    vifVife.Unit = "second";
                    vifVife.Description = "Period of nominal data transmissions";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3D:
                    vifVife.Unit = "minute";
                    vifVife.Description = "Period of nominal data transmissions";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3E:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Period of nominal data transmissions";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x3F:
                    vifVife.Unit = "day";
                    vifVife.Description = "Period of nominal data transmissions";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Volts */
                case 0x40:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 0 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x41:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 1 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x42:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 2 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x43:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 3 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x44:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 4 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x45:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 5 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x46:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 6 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x47:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 7 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x48:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 8 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x49:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 9 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4A:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 10 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4B:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 11 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4C:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 12 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4D:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 13 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4E:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 14 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x4F:
                    vifVife.Unit = "V";
                    vifVife.Description = "Volts";
                    vifVife.Magnitude = 15 - 9;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Ampers */
                case 0x50:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 0 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x51:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 1 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x52:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 2 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x53:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 3 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x54:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 4 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x55:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 5 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x56:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 6 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x57:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 7 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x58:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 8 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x59:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 9 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5A:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 10 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5B:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 11 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5C:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 12 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5D:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 13 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5E:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 14 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x5F:
                    vifVife.Unit = "A";
                    vifVife.Description = "Ampers";
                    vifVife.Magnitude = 15 - 12;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Others */
                case 0x60:
                    vifVife.Unit = "";
                    vifVife.Description = "Reset counter";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x61:
                    vifVife.Unit = "";
                    vifVife.Description = "Cumulation counter";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x62:
                    vifVife.Unit = "";
                    vifVife.Description = "Control signal";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x63:
                    vifVife.Unit = "";
                    vifVife.Description = "Day of week";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x64:
                    vifVife.Unit = "";
                    vifVife.Description = "Week number";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x65:
                    vifVife.Unit = "";
                    vifVife.Description = "Time point of day change";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x66:
                    vifVife.Unit = "";
                    vifVife.Description = "State of parameter activation";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x67:
                    vifVife.Unit = "";
                    vifVife.Description = "Special supplier information";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Duration since last cumulation */
                case 0x68:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Duration since last cumulation";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x69:
                    vifVife.Unit = "day";
                    vifVife.Description = "Duration since last cumulation";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6A:
                    vifVife.Unit = "month";
                    vifVife.Description = "Duration since last cumulation";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6B:
                    vifVife.Unit = "year";
                    vifVife.Description = "Duration since last cumulation";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Operation time battery */
                case 0x6C:
                    vifVife.Unit = "hour";
                    vifVife.Description = "Operating time battery";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6D:
                    vifVife.Unit = "day";
                    vifVife.Description = "Operating time battery";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6E:
                    vifVife.Unit = "month";
                    vifVife.Description = "Operating time battery";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x6F:
                    vifVife.Unit = "year";
                    vifVife.Description = "Operating time battery";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                /* Others */
                case 0x70:
                    vifVife.Unit = "";
                    vifVife.Description = "Date and time of battery change";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x71:
                    vifVife.Unit = "dBm";
                    vifVife.Description = "RF level unit";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x72:
                    vifVife.Unit = "";
                    vifVife.Description = "Daylight saving";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x73:
                    vifVife.Unit = "";
                    vifVife.Description = "Listening window management";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x74:
                    vifVife.Unit = "";
                    vifVife.Description = "Remaining battery life time (days)";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x75:
                    vifVife.Unit = "";
                    vifVife.Description = "Number times the meter was stopped";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x76:
                    vifVife.Unit = "";
                    vifVife.Description = "Data container for manufacturer specific protocol";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.ManufacturerSpecificDataContainer;
                    break;

                /* Reserved */
                case 0x77:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x78:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x79:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7A:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7B:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7C:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7D:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7E:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
                    vifVife.DataType = VibDataType.Numeric;
                    break;

                case 0x7F:
                    vifVife.Unit = "";
                    vifVife.Description = "Reserved";
                    vifVife.Magnitude = 0;
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