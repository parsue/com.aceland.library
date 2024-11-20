using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Vector4 X(this Vector4 value, float x) =>
            new(x, value.y, value.z, value.w);

        public static Vector4 Y(this Vector4 value, float y) =>
            new(value.x, y, value.z, value.w);

        public static Vector4 Z(this Vector4 value, float z) =>
            new(value.x, value.y, z, value.w);

        public static Vector4 W(this Vector4 value, float w) =>
            new(value.x, value.y, value.z, w);

        public static Vector4 XY(this Vector4 value, float x, float y) =>
            new(x, y, value.z, value.w);

        public static Vector4 XZ(this Vector4 value, float x, float z) =>
            new(x, value.y, z, value.w);

        public static Vector4 XW(this Vector4 value, float x, float w) =>
            new(x, value.y, value.z, w);

        public static Vector4 YZ(this Vector4 value, float y, float z) =>
            new(value.x, y, z, value.w);

        public static Vector4 YW(this Vector4 value, float y, float w) =>
            new(value.x, y, value.z, w);

        public static Vector4 ZW(this Vector4 value, float z, float w) =>
            new(value.x, value.y, z, w);

        public static Vector4 XYZ(this Vector4 value, float x, float y, float z) =>
            new(x, y, z, value.w);

        public static Vector4 XYW(this Vector4 value, float x, float y, float w) =>
            new(x, y, value.z, w);

        public static Vector4 XZW(this Vector4 value, float x, float z, float w) =>
            new(x, value.y, z, w);

        public static Vector4 YZW(this Vector4 value, float y, float z, float w) =>
            new(value.x, y, z, w);

        public static Vector4 AdjX(this Vector4 value, float x) =>
            new(value.x + x, value.y, value.z, value.w);

        public static Vector4 AdjY(this Vector4 value, float y) =>
            new(value.x, value.y + y, value.z, value.w);

        public static Vector4 AdjZ(this Vector4 value, float z) =>
            new(value.x, value.y, value.z + z, value.w);

        public static Vector4 AdjW(this Vector4 value, float w) =>
            new(value.x, value.y, value.z, value.w + w);

        public static Vector4 AdjXY(this Vector4 value, float x, float y) =>
            new(value.x + x, value.y + y, value.z, value.w);

        public static Vector4 AdjXZ(this Vector4 value, float x, float z) =>
            new(value.x + x, value.y, value.z + z, value.w);

        public static Vector4 AdjXW(this Vector4 value, float x, float w) =>
            new(value.x + x, value.y, value.z, value.w + w);

        public static Vector4 AdjYZ(this Vector4 value, float y, float z) =>
            new(value.x, value.y + y, value.z + z, value.w);

        public static Vector4 AdjYW(this Vector4 value, float y, float w) =>
            new(value.x, value.y + y, value.z, value.w + w);

        public static Vector4 AdjZW(this Vector4 value, float z, float w) =>
            new(value.x, value.y, value.z + z, value.w + w);

        public static Vector4 AdjXYZ(this Vector4 value, float x, float y, float z) =>
            new(value.x + x, value.y + y, value.z + z, value.w);

        public static Vector4 AdjXYW(this Vector4 value, float x, float y, float w) =>
            new(value.x + x, value.y + y, value.z, value.w + w);

        public static Vector4 AdjXZW(this Vector4 value, float x, float z, float w) =>
            new(value.x + x, value.y, value.z + z, value.w + w);

        public static Vector4 AdjYZW(this Vector4 value, float y, float z, float w) =>
            new(value.x, value.y + y, value.z + z, value.w + w);
        
        public static Vector4 AdjXYZW(this Vector4 value, float x, float y, float z, float w) =>
            new(value.x + x, value.y + y, value.z + z, value.w + w);

        public static Vector4 AdjAll(this Vector4 value, float all) =>
            new(value.x + all, value.y + all, value.z + all, value.w + all);
    }
}
