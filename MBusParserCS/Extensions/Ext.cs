using System.Text.RegularExpressions;

namespace MBusParserCS.Extensions
{
    internal static class Ext
    {
        public static IEnumerable<Byte> ToBytes(this String hexString)
        {
            List<Byte> bytes = new();

            if (!String.IsNullOrEmpty(hexString))
            {
                String hex = hexString.Replace("-", String.Empty).Replace(" ", String.Empty);
                if (hex.Length % 2 == 0)
                {
                    Boolean isHexString = Regex.IsMatch(hex, @"\A\b[0-9a-fA-F]+\b\Z");
                    if (isHexString)
                    {
                        Int32 hexBytesInString = hex.Length;

                        for (Int32 i = 0; i < hexBytesInString; i += 2)
                        {
                            Byte hexByte = Convert.ToByte($"0x{hex.Substring(i, 2)}", 16);
                            bytes.Add(hexByte);
                        }
                    }
                }
            }

            return bytes;
        }

        public static String ToHexString(this Byte dataByte)
        {
            return String.Format("0x{0:X2}", dataByte);
        }

        public static String ToHexString(this IEnumerable<Byte> data)
        {
            if (data != null && data.Any())
            {
                Byte[] dataBytes = data.ToArray();
                String result = BitConverter.ToString(dataBytes).Replace("-", " ");
                return "0x" + result.Replace(" ", " 0x");
            }

            return String.Empty;
        }

        public static IEnumerable<T> DequeueChunk<T>(this Queue<T> queue, Int32 chunkSize)
        {
            List<T> result = new();

            if (queue != null)
            {
                for (Int32 i = 0; i < chunkSize && queue.Count > 0; i++)
                {
                    result.Add(queue.Dequeue());
                }
            }

            return result;
        }

        public static void EnqueueChunk<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            if (queue != null && items != null)
            {
                foreach (T obj in items)
                {
                    queue.Enqueue(obj);
                }
            }
        }

        public static void RemoveBack<T>(this Queue<T> queue, Int32 chunkSize)
        {
            if (queue != null)
            {
                Queue<T> tempQueue = new();

                while (queue.Count > chunkSize)
                {
                    tempQueue.Enqueue(queue.Dequeue());
                }

                queue.Clear();

                while (tempQueue.Count > 0)
                {
                    queue.Enqueue(tempQueue.Dequeue());
                }
            }
        }

        public static UInt64 BCDToUIt64(this IEnumerable<Byte> data)
        {
            if (data != null && data.Any())
            {
                UInt64 val = 0;
                Byte[] dataBytes = data.ToArray();

                for (Int32 i = data.Count(); i > 0; i--)
                {
                    val = (val * 10) + (UInt64)((dataBytes[i - 1] >> 4) & 0xF);
                    val = (val * 10) + (UInt64)(dataBytes[i - 1] & 0xF);
                }

                return val;
            }

            throw new ArgumentException("Array must contain at least one element");
        }

        public static Int32 Bit24ToInt32(this IEnumerable<Byte> data)
        {
            if (data != null && data.Count() == 3)
            {
                Int32 result = 0;

                Byte[] dataBytes = data.ToArray();

                if (((dataBytes[2] & 0x80) >> 7) == 1)
                {
                    result = (0xFF << 24) | (dataBytes[2] << 16) | (dataBytes[1] << 8) | dataBytes[0];
                }
                else
                {
                    result = (dataBytes[2] << 16) | (dataBytes[1] << 8) | dataBytes[0];
                }

                return result;
            }

            throw new ArgumentException("Array must have exactly 3 elements");
        }

        public static Int64 Bit48ToInt64(this IEnumerable<Byte> data)
        {
            if (data != null && data.Count() == 6)
            {
                Int64 result = 0;
                Byte[] dataBytes = data.ToArray();

                if (((dataBytes[5] & 0x80) >> 7) == 1)
                {
                    result = (Int64)(((UInt64)0xFF << 56) | ((UInt64)0xFF << 48) | ((UInt64)dataBytes[5] << 40) | ((UInt64)dataBytes[4] << 32) | ((UInt64)dataBytes[3] << 24) | ((UInt64)dataBytes[2] << 16) | ((UInt64)dataBytes[1] << 8) | (UInt64)dataBytes[0]);
                }
                else
                {
                    result = (Int64)(((UInt64)dataBytes[5] << 40) | ((UInt64)dataBytes[4] << 32) | ((UInt64)dataBytes[3] << 24) | ((UInt64)dataBytes[2] << 16) | ((UInt64)dataBytes[1] << 8) | (UInt64)dataBytes[0]);
                }

                return result;
            }

            throw new ArgumentException("Array must have exactly 6 elements");
        }
    }
}