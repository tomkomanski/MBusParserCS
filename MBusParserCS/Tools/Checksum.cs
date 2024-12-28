namespace MBusParserCS.Tools
{
    internal static class Checksum
    {
        public static Byte CalculateMbusCs(IEnumerable<Byte> bytes)
        {
            Byte cs = 0;

            foreach(Byte b in bytes)
            {
                cs += b;
            }

            return cs;
        }

        public static Byte[] CalculateWmbusCrc(IEnumerable<Byte> bytes)
        {
            Byte[] crc = new Byte[2];

            Int32 poly = 0x3D65;
            Int32 crcVal = 0x0000;
            Int32 xorValue = 0xFFFF;
            Int32 i;

            foreach (Byte b in bytes)
            {
                for (i = 0x80; i != 0; i >>= 1)
                {
                    if ((crcVal & 0x8000) != 0)
                    {
                        crcVal = (crcVal << 1) ^ poly;
                    }
                    else
                    {
                        crcVal = crcVal << 1;
                    }
                    if ((b & i) != 0)
                    {
                        crcVal ^= poly;
                    }
                }
            }

            Byte[] tmpCrc = BitConverter.GetBytes(crcVal & 0xffff ^ xorValue);

            crc[0] = tmpCrc[1];
            crc[1] = tmpCrc[0];

            return crc;
        }
    }
}