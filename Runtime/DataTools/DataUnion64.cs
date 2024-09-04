using System;
using System.Runtime.InteropServices;

namespace AceLand.Library.DataTools
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DataUnion64
    {
        [FieldOffset(0)]    // 8-byte
        public long Long;

        [FieldOffset(0)]    // 8-byte
        public ulong ULong;

        [FieldOffset(0)]    // 4-byte
        public int Int;
        [FieldOffset(4)]
        public int Int1;

        [FieldOffset(0)]    // 4-byte
        public uint UInt;
        [FieldOffset(4)]
        public uint UInt1;

        [FieldOffset(0)]    // 2-byte
        public short Short;
        [FieldOffset(2)]
        public short Short1;
        [FieldOffset(4)]
        public short Short2;
        [FieldOffset(6)]
        public short Short3;

        [FieldOffset(0)]    // 2-byte
        public ushort UShort;
        [FieldOffset(2)]
        public ushort UShort1;
        [FieldOffset(4)]
        public ushort UShort2;
        [FieldOffset(6)]
        public ushort UShort3;

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

        [FieldOffset(0)]    // 1-byte
        public sbyte SByte;
        [FieldOffset(1)]
        public sbyte SByte1;
        [FieldOffset(2)]
        public sbyte SByte2;
        [FieldOffset(3)]
        public sbyte SByte3;
        [FieldOffset(4)]
        public sbyte SByte4;
        [FieldOffset(5)]
        public sbyte SByte5;
        [FieldOffset(6)]
        public sbyte SByte6;
        [FieldOffset(7)]
        public sbyte SByte7;

        [FieldOffset(0)]    // 4-byte
        public float Float;
        [FieldOffset(4)]
        public float Float1;

        [FieldOffset(0)]    // 8-byte
        public double Double;

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

        public readonly void Output8Bit(out byte data)
        {
            data = Byte;
        }

        public readonly void Output16Bit(out byte[] data)
        {
            data = new byte[]
            {
                Byte, Byte1
            };
        }

        public readonly void Output32Bit(out byte[] data)
        {
            data = new byte[]
            {
                Byte, Byte1, Byte2, Byte3
            };
        }

        public readonly void Output64Bit(out byte[] data)
        {
            data = new byte[]
            {
                Byte, Byte1, Byte2, Byte3, Byte4, Byte5, Byte6, Byte7
            };
        }
    }
}
