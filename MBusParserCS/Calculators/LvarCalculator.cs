using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Extensions;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using System.Text;


namespace MBusParserCS.Calculators
{
    internal sealed class LvarCalculator : ILvarCalculator
    {
        private static LvarCalculator? instance;

        public static LvarCalculator GetCalculator()
        {
            if (instance == null)
            {
                instance = new LvarCalculator();
            }
            return instance;
        }

        private LvarCalculator()
        {
        }

        public LvarCalculatorMessage CalculateLvar(ref Queue<Byte> data, Byte lvar_first_byte)
        {
            LvarCalculatorMessage lvarCalculatorMessage = new();
            LvarDataTypeAndLength lvarDataTypeAndLength = this.GetLvarDataTypeAndLength(lvar_first_byte);

            if (lvarDataTypeAndLength.DataType == LvarDataType.Unknown)
            {
                lvarCalculatorMessage.AddErrorCode(ErrorCode.LvarError);
                return lvarCalculatorMessage;
            }

            if (data.Count < lvarDataTypeAndLength.DataLength)
            {
                lvarCalculatorMessage.AddErrorCode(ErrorCode.LvarError);
                return lvarCalculatorMessage;
            }

            List<Byte> valueBytes = new(data.DequeueChunk(lvarDataTypeAndLength.DataLength));

            Lvar lvar = new();
            lvar.Data.Add(lvar_first_byte);
            lvar.Data.AddRange(valueBytes);

            if (lvarDataTypeAndLength.DataType == LvarDataType.TextString)
            {
                valueBytes.Reverse();
                String text = Encoding.UTF8.GetString(valueBytes.ToArray());
                lvar.TextValue = text;
            }
            else if (lvarDataTypeAndLength.DataType == LvarDataType.PositiveBCDnumber)
            {
                lvar.NumericValue = valueBytes.BCDToInt64();
            }
            else if (lvarDataTypeAndLength.DataType == LvarDataType.NegativeBCDnumber)
            {
                lvar.NumericValue = valueBytes.BCDToInt64() * - 1 ;
            }
            else if (lvarDataTypeAndLength.DataType == LvarDataType.BinaryNumber)
            {
                valueBytes.Reverse();
                String binary_output = String.Empty;

                foreach (Byte b in valueBytes)
                {
                    binary_output += Convert.ToString(b, 2).PadLeft(8, '0');
                }

                lvar.TextValue = binary_output;
            }


            lvarCalculatorMessage.SetLvar(lvar);
            return lvarCalculatorMessage;
        }

        private LvarDataTypeAndLength GetLvarDataTypeAndLength(Byte lvar_first_byte)
        {
            LvarDataTypeAndLength lvarDataTypeAndLength = new()
            {
                DataType = LvarDataType.Unknown,
                DataLength = 0,
            };

            switch (lvar_first_byte)
            {
                case >= 0x00 and <= 0xBF:
                    lvarDataTypeAndLength.DataType = LvarDataType.TextString;
                    lvarDataTypeAndLength.DataLength = lvar_first_byte;
                    break;

                case >= 0xC0 and <= 0xC9:
                    lvarDataTypeAndLength.DataType = LvarDataType.PositiveBCDnumber;
                    lvarDataTypeAndLength.DataLength = (Byte)(lvar_first_byte - 0xC0);               
                    break;

                case >= 0xD0 and <= 0xD9:
                    lvarDataTypeAndLength.DataType = LvarDataType.NegativeBCDnumber;
                    lvarDataTypeAndLength.DataLength = (Byte)(lvar_first_byte - 0xD0);
                    break;

                case >= 0xE0 and <= 0xEF:
                    lvarDataTypeAndLength.DataType = LvarDataType.BinaryNumber;
                    lvarDataTypeAndLength.DataLength = (Byte)(lvar_first_byte - 0xE0);              
                    break;

                case >= 0xF0 and <= 0xF4:
                    lvarDataTypeAndLength.DataType = LvarDataType.BinaryNumber;
                    lvarDataTypeAndLength.DataLength = (Byte)((lvar_first_byte - 0xEC) * 4);            
                    break;

                case 0xF5:                 
                    lvarDataTypeAndLength.DataType = LvarDataType.BinaryNumber;
                    lvarDataTypeAndLength.DataLength = 6;
                    break;

                case 0xF6:
                    lvarDataTypeAndLength.DataType = LvarDataType.BinaryNumber;
                    lvarDataTypeAndLength.DataLength = 8;
                    break;

                default:
                    break;
            }

            return lvarDataTypeAndLength;
        }
    }
}