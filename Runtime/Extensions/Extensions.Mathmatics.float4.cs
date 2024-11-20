using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this float4 value) =>
            float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z) || float.IsNaN(value.w);

        public static float4 X(this float4 value, float x) =>
            new(x, value.y, value.z, value.w);

        public static float4 Y(this float4 value, float y) =>
            new(value.x, y, value.z, value.w);

        public static float4 Z(this float4 value, float z) =>
            new(value.x, value.y, z, value.w);

        public static float4 W(this float4 value, float w) =>
            new(value.x, value.y, value.z, w);

        public static float4 XY(this float4 value, float x, float y) =>
            new(x, y, value.z, value.w);

        public static float4 XZ(this float4 value, float x, float z) =>
            new(x, value.y, z, value.w);

        public static float4 XW(this float4 value, float x, float w) =>
            new(x, value.y, value.z, w);

        public static float4 YZ(this float4 value, float y, float z) =>
            new(value.x, y, z, value.w);

        public static float4 YW(this float4 value, float y, float w) =>
            new(value.x, y, value.z, w);

        public static float4 ZW(this float4 value, float z, float w) =>
            new(value.x, value.y, z, w);

        public static float4 XYZ(this float4 value, float x, float y, float z) =>
            new(x, y, z, value.w);

        public static float4 XYW(this float4 value, float x, float y, float w) =>
            new(x, y, value.z, w);

        public static float4 XZW(this float4 value, float x, float z, float w) =>
            new(x, value.y, z, w);

        public static float4 YZW(this float4 value, float y, float z, float w) =>
            new(value.x, y, z, w);

        public static float4 AdjX(this float4 value, float x) =>
            new(value.x + x, value.y, value.z, value.w);

        public static float4 AdjY(this float4 value, float y) =>
            new(value.x, value.y + y, value.z, value.w);

        public static float4 AdjZ(this float4 value, float z) =>
            new(value.x, value.y, value.z + z, value.w);

        public static float4 AdjW(this float4 value, float w) =>
            new(value.x, value.y, value.z, value.w + w);

        public static float4 AdjXY(this float4 value, float x, float y) =>
            new(value.x + x, value.y + y, value.z, value.w);

        public static float4 AdjXZ(this float4 value, float x, float z) =>
            new(value.x + x, value.y, value.z + z, value.w);

        public static float4 AdjXW(this float4 value, float x, float w) =>
            new(value.x + x, value.y, value.z, value.w + w);

        public static float4 AdjYZ(this float4 value, float y, float z) =>
            new(value.x, value.y + y, value.z + z, value.w);

        public static float4 AdjYW(this float4 value, float y, float w) =>
            new(value.x, value.y + y, value.z, value.w + w);

        public static float4 AdjZW(this float4 value, float z, float w) =>
            new(value.x, value.y, value.z + z, value.w + w);

        public static float4 AdjXYZ(this float4 value, float x, float y, float z) =>
            new(value.x + x, value.y + y, value.z + z, value.w);

        public static float4 AdjXYW(this float4 value, float x, float y, float w) =>
            new(value.x + x, value.y + y, value.z, value.w + w);

        public static float4 AdjXZW(this float4 value, float x, float z, float w) =>
            new(value.x + x, value.y, value.z + z, value.w + w);

        public static float4 AdjYZW(this float4 value, float y, float z, float w) =>
            new(value.x, value.y + y, value.z + z, value.w + w);
        
        public static float4 AdjXXZW(this float4 value, float x, float y, float z, float w) =>
            new(value.x + x, value.y + y, value.z + z, value.w + w);

        public static float4 AdjAll(this float4 value, float all) =>
            new(value.x + all, value.y + all, value.z + all, value.w + all);
    }
}
