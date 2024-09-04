using System;
using System.Runtime.InteropServices;

namespace AceLand.Library.DataTools
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DataUnion
    {
        [FieldOffset(0)]    // 8-byte
        public long Long;

        [FieldOffset(0)]    // 8-byte
        public ulong ULong;

        [FieldOffset(0)]    // 4-byte
        public int Int;

        [FieldOffset(0)]    // 4-byte
        public uint UInt;

        [FieldOffset(0)]    // 2-byte
        public short Short;

        [FieldOffset(0)]    // 2-byte
        public ushort UShort;

        [FieldOffset(0)]    // 1-byte
        public byte Byte;
        [FieldOffset(1)]
        private byte Byte1;
        [FieldOffset(2)]
        private byte Byte2;
        [FieldOffset(3)]
        private byte Byte3;
        [FieldOffset(4)]
        private byte Byte4;
        [FieldOffset(5)]
        private byte Byte5;
        [FieldOffset(6)]
        private byte Byte6;
        [FieldOffset(7)]
        private byte Byte7;
        [FieldOffset(8)]
        private byte Byte8;
        [FieldOffset(9)]
        private byte Byte9;
        [FieldOffset(10)]
        private byte Byte10;
        [FieldOffset(11)]
        private byte Byte11;
        [FieldOffset(12)]
        private byte Byte12;
        [FieldOffset(13)]
        private byte Byte13;
        [FieldOffset(14)]
        private byte Byte14;
        [FieldOffset(15)]
        private byte Byte15;
        [FieldOffset(16)]
        private byte Byte16;
        [FieldOffset(17)]
        private byte Byte17;
        [FieldOffset(18)]
        private byte Byte18;
        [FieldOffset(19)]
        private byte Byte19;
        [FieldOffset(20)]
        private byte Byte20;
        [FieldOffset(21)]
        private byte Byte21;
        [FieldOffset(22)]
        private byte Byte22;
        [FieldOffset(23)]
        private byte Byte23;

        [FieldOffset(0)]    // 1-byte
        public sbyte SByte;

        [FieldOffset(0)]    // 4-byte
        public float Float;

        [FieldOffset(0)]    // 8-byte
        public double Double;

        [FieldOffset(0)]    // 24-byte
        public decimal Decimal;

        [FieldOffset(0)]    // 8-byte
        public DateTime Datetime;

        public void Input8Bit(byte[] data)
        {
            if (data.Length == 0) return;
            Byte = data[0];
        }

        public void Input16Bit(byte[] data)
        {
            if (data.Length < 2) return;
            Byte = data[0];
            Byte1 = data[1];
        }

        public void Input32Bit(byte[] data)
        {
            if (data.Length < 4) return;
            Byte = data[0];
            Byte1 = data[1];
            Byte2 = data[2];
            Byte3 = data[3];
        }

        public void Input64Bit(byte[] data)
        {
            if (data.Length < 8) return;
            Byte = data[0];
            Byte1 = data[1];
            Byte2 = data[2];
            Byte3 = data[3];
            Byte4 = data[4];
            Byte5 = data[5];
            Byte6 = data[6];
            Byte7 = data[7];
        }

        public void Input192Bit(byte[] data)
        {
            if (data.Length < 24) return;
            Byte = data[0];
            Byte1 = data[1];
            Byte2 = data[2];
            Byte3 = data[3];
            Byte4 = data[4];
            Byte5 = data[5];
            Byte6 = data[6];
            Byte7 = data[7];
            Byte8 = data[8];
            Byte9 = data[9];
            Byte10 = data[10];
            Byte11 = data[11];
            Byte12 = data[12];
            Byte13 = data[13];
            Byte14 = data[14];
            Byte15 = data[15];
            Byte16 = data[16];
            Byte17 = data[17];
            Byte18 = data[18];
            Byte19 = data[19];
            Byte20 = data[20];
            Byte21 = data[21];
            Byte22 = data[22];
            Byte23 = data[23];
        }

        public readonly void Output8Bit(ref byte data)
        {
            data = Byte;
        }

        public readonly void Output16Bit(ref byte[] data)
        {
            data = new byte[]
            {
                Byte, Byte1
            };
        }

        public readonly void Output32Bit(ref byte[] data)
        {
            data = new byte[]
            {
                Byte, Byte1, Byte2, Byte3
            };
        }

        public readonly void Output64Bit(ref byte[] data)
        {
            data = new byte[]
            {
                Byte, Byte1, Byte2, Byte3, Byte4, Byte5, Byte6, Byte7
            };
        }

        public readonly void Output192Bit(ref byte[] data)
        {
            data = new byte[]
            {
                Byte, Byte1, Byte2, Byte3, Byte4, Byte5, Byte6, Byte7,
                Byte8, Byte9, Byte10, Byte11, Byte12, Byte13, Byte14, Byte15,
                Byte16, Byte17, Byte18, Byte19, Byte20, Byte21, Byte22, Byte23
            };
        }
    }
}
