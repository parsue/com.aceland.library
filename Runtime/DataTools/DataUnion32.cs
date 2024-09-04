using System.Runtime.InteropServices;

namespace AceLand.Library.DataTools
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DataUnion32
    {
        [FieldOffset(0)]    // 4-byte
        public int Int;

        [FieldOffset(0)]    // 4-byte
        public uint UInt;

        [FieldOffset(0)]    // 2-byte
        public short Short;
        [FieldOffset(2)]
        public short Short1;

        [FieldOffset(0)]    // 2-byte
        public ushort UShort;
        [FieldOffset(2)]
        public ushort UShort1;

        [FieldOffset(0)]    // 1-byte
        public byte Byte;
        [FieldOffset(1)]
        public byte Byte1;
        [FieldOffset(2)]
        public byte Byte2;
        [FieldOffset(3)]
        public byte Byte3;

        [FieldOffset(0)]    // 1-byte
        public sbyte SByte;
        [FieldOffset(1)]
        public sbyte SByte1;
        [FieldOffset(2)]
        public sbyte SByte2;
        [FieldOffset(3)]
        public sbyte SByte3;

        [FieldOffset(0)]    // 4-byte
        public float Float;

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
    }
}
