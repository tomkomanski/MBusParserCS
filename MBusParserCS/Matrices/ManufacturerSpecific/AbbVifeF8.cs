using MBusParserCS.Models;

namespace MBusParserCS.Matrices
{
    internal static partial class VifVifeMatrix
    {
        // Based on B23 and B24
        public static VifVife GetVifeAbbF8(Byte vifVifeByte)
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
                    vifVife.Description = "0";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x01:
                    vifVife.Unit = "";
                    vifVife.Description = "1";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x02:
                    vifVife.Unit = "";
                    vifVife.Description = "2";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x03:
                    vifVife.Unit = "";
                    vifVife.Description = "3";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x04:
                    vifVife.Unit = "";
                    vifVife.Description = "4";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x05:
                    vifVife.Unit = "";
                    vifVife.Description = "5";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x06:
                    vifVife.Unit = "";
                    vifVife.Description = "6";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x07:
                    vifVife.Unit = "";
                    vifVife.Description = "7";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x08:
                    vifVife.Unit = "";
                    vifVife.Description = "8";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x09:
                    vifVife.Unit = "";
                    vifVife.Description = "9";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0A:
                    vifVife.Unit = "";
                    vifVife.Description = "10";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0B:
                    vifVife.Unit = "";
                    vifVife.Description = "11";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0C:
                    vifVife.Unit = "";
                    vifVife.Description = "12";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0D:
                    vifVife.Unit = "";
                    vifVife.Description = "13";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0E:
                    vifVife.Unit = "";
                    vifVife.Description = "14";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x0F:
                    vifVife.Unit = "";
                    vifVife.Description = "15";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x10:
                    vifVife.Unit = "";
                    vifVife.Description = "16";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x11:
                    vifVife.Unit = "";
                    vifVife.Description = "17";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x12:
                    vifVife.Unit = "";
                    vifVife.Description = "18";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x13:
                    vifVife.Unit = "";
                    vifVife.Description = "19";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x14:
                    vifVife.Unit = "";
                    vifVife.Description = "20";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x15:
                    vifVife.Unit = "";
                    vifVife.Description = "21";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x16:
                    vifVife.Unit = "";
                    vifVife.Description = "22";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x17:
                    vifVife.Unit = "";
                    vifVife.Description = "23";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x18:
                    vifVife.Unit = "";
                    vifVife.Description = "24";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x19:
                    vifVife.Unit = "";
                    vifVife.Description = "25";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1A:
                    vifVife.Unit = "";
                    vifVife.Description = "26";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1B:
                    vifVife.Unit = "";
                    vifVife.Description = "27";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1C:
                    vifVife.Unit = "";
                    vifVife.Description = "28";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1D:
                    vifVife.Unit = "";
                    vifVife.Description = "29";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1E:
                    vifVife.Unit = "";
                    vifVife.Description = "30";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x1F:
                    vifVife.Unit = "";
                    vifVife.Description = "31";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x20:
                    vifVife.Unit = "";
                    vifVife.Description = "32";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x21:
                    vifVife.Unit = "";
                    vifVife.Description = "33";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x22:
                    vifVife.Unit = "";
                    vifVife.Description = "34";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x23:
                    vifVife.Unit = "";
                    vifVife.Description = "35";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x24:
                    vifVife.Unit = "";
                    vifVife.Description = "36";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x25:
                    vifVife.Unit = "";
                    vifVife.Description = "37";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x26:
                    vifVife.Unit = "";
                    vifVife.Description = "38";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x27:
                    vifVife.Unit = "";
                    vifVife.Description = "39";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x28:
                    vifVife.Unit = "";
                    vifVife.Description = "40";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x29:
                    vifVife.Unit = "";
                    vifVife.Description = "41";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2A:
                    vifVife.Unit = "";
                    vifVife.Description = "42";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2B:
                    vifVife.Unit = "";
                    vifVife.Description = "43";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2C:
                    vifVife.Unit = "";
                    vifVife.Description = "44";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2D:
                    vifVife.Unit = "";
                    vifVife.Description = "45";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2E:
                    vifVife.Unit = "";
                    vifVife.Description = "46";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x2F:
                    vifVife.Unit = "";
                    vifVife.Description = "47";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x30:
                    vifVife.Unit = "";
                    vifVife.Description = "48";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x31:
                    vifVife.Unit = "";
                    vifVife.Description = "49";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x32:
                    vifVife.Unit = "";
                    vifVife.Description = "50";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x33:
                    vifVife.Unit = "";
                    vifVife.Description = "51";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x34:
                    vifVife.Unit = "";
                    vifVife.Description = "52";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x35:
                    vifVife.Unit = "";
                    vifVife.Description = "53";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x36:
                    vifVife.Unit = "";
                    vifVife.Description = "54";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x37:
                    vifVife.Unit = "";
                    vifVife.Description = "55";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x38:
                    vifVife.Unit = "";
                    vifVife.Description = "56";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x39:
                    vifVife.Unit = "";
                    vifVife.Description = "57";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3A:
                    vifVife.Unit = "";
                    vifVife.Description = "58";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3B:
                    vifVife.Unit = "";
                    vifVife.Description = "59";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3C:
                    vifVife.Unit = "";
                    vifVife.Description = "60";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3D:
                    vifVife.Unit = "";
                    vifVife.Description = "61";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3E:
                    vifVife.Unit = "";
                    vifVife.Description = "62";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x3F:
                    vifVife.Unit = "";
                    vifVife.Description = "63";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x40:
                    vifVife.Unit = "";
                    vifVife.Description = "64";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x41:
                    vifVife.Unit = "";
                    vifVife.Description = "65";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x42:
                    vifVife.Unit = "";
                    vifVife.Description = "66";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x43:
                    vifVife.Unit = "";
                    vifVife.Description = "67";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x44:
                    vifVife.Unit = "";
                    vifVife.Description = "68";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x45:
                    vifVife.Unit = "";
                    vifVife.Description = "69";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x46:
                    vifVife.Unit = "";
                    vifVife.Description = "70";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x47:
                    vifVife.Unit = "";
                    vifVife.Description = "71";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x48:
                    vifVife.Unit = "";
                    vifVife.Description = "72";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x49:
                    vifVife.Unit = "";
                    vifVife.Description = "73";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4A:
                    vifVife.Unit = "";
                    vifVife.Description = "74";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4B:
                    vifVife.Unit = "";
                    vifVife.Description = "75";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4C:
                    vifVife.Unit = "";
                    vifVife.Description = "76";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4D:
                    vifVife.Unit = "";
                    vifVife.Description = "77";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4E:
                    vifVife.Unit = "";
                    vifVife.Description = "78";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x4F:
                    vifVife.Unit = "";
                    vifVife.Description = "79";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x50:
                    vifVife.Unit = "";
                    vifVife.Description = "80";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x51:
                    vifVife.Unit = "";
                    vifVife.Description = "81";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x52:
                    vifVife.Unit = "";
                    vifVife.Description = "82";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x53:
                    vifVife.Unit = "";
                    vifVife.Description = "83";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x54:
                    vifVife.Unit = "";
                    vifVife.Description = "84";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x55:
                    vifVife.Unit = "";
                    vifVife.Description = "85";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x56:
                    vifVife.Unit = "";
                    vifVife.Description = "86";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x57:
                    vifVife.Unit = "";
                    vifVife.Description = "87";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x58:
                    vifVife.Unit = "";
                    vifVife.Description = "88";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x59:
                    vifVife.Unit = "";
                    vifVife.Description = "89";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5A:
                    vifVife.Unit = "";
                    vifVife.Description = "90";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5B:
                    vifVife.Unit = "";
                    vifVife.Description = "91";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5C:
                    vifVife.Unit = "";
                    vifVife.Description = "92";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5D:
                    vifVife.Unit = "";
                    vifVife.Description = "93";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5E:
                    vifVife.Unit = "";
                    vifVife.Description = "94";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x5F:
                    vifVife.Unit = "";
                    vifVife.Description = "95";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x60:
                    vifVife.Unit = "";
                    vifVife.Description = "96";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x61:
                    vifVife.Unit = "";
                    vifVife.Description = "97";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x62:
                    vifVife.Unit = "";
                    vifVife.Description = "98";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x63:
                    vifVife.Unit = "";
                    vifVife.Description = "99";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x64:
                    vifVife.Unit = "";
                    vifVife.Description = "100";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x65:
                    vifVife.Unit = "";
                    vifVife.Description = "101";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x66:
                    vifVife.Unit = "";
                    vifVife.Description = "102";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x67:
                    vifVife.Unit = "";
                    vifVife.Description = "103";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x68:
                    vifVife.Unit = "";
                    vifVife.Description = "104";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x69:
                    vifVife.Unit = "";
                    vifVife.Description = "105";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6A:
                    vifVife.Unit = "";
                    vifVife.Description = "106";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6B:
                    vifVife.Unit = "";
                    vifVife.Description = "107";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6C:
                    vifVife.Unit = "";
                    vifVife.Description = "108";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6D:
                    vifVife.Unit = "";
                    vifVife.Description = "109";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6E:
                    vifVife.Unit = "";
                    vifVife.Description = "110";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x6F:
                    vifVife.Unit = "";
                    vifVife.Description = "111";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x70:
                    vifVife.Unit = "";
                    vifVife.Description = "112";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x71:
                    vifVife.Unit = "";
                    vifVife.Description = "113";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x72:
                    vifVife.Unit = "";
                    vifVife.Description = "114";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x73:
                    vifVife.Unit = "";
                    vifVife.Description = "115";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x74:
                    vifVife.Unit = "";
                    vifVife.Description = "116";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x75:
                    vifVife.Unit = "";
                    vifVife.Description = "117";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x76:
                    vifVife.Unit = "";
                    vifVife.Description = "118";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x77:
                    vifVife.Unit = "";
                    vifVife.Description = "119";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x78:
                    vifVife.Unit = "";
                    vifVife.Description = "120";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x79:
                    vifVife.Unit = "";
                    vifVife.Description = "121";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7A:
                    vifVife.Unit = "";
                    vifVife.Description = "122";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7B:
                    vifVife.Unit = "";
                    vifVife.Description = "123";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7C:
                    vifVife.Unit = "";
                    vifVife.Description = "124";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7D:
                    vifVife.Unit = "";
                    vifVife.Description = "125";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7E:
                    vifVife.Unit = "";
                    vifVife.Description = "126";
                    vifVife.Magnitude = null;
                    vifVife.DataType = null;
                    break;

                case 0x7F:
                    vifVife.Unit = "";
                    vifVife.Description = "127";
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