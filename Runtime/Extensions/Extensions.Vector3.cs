using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Vector3 Remap(this Vector3 value, Vector3 from1, Vector3 to1, Vector3 from2, Vector3 to2) =>
            new(
                value.x.Remap(from1.x, to1.x, from2.x, to2.x),
                value.y.Remap(from1.y, to1.y, from2.y, to2.y),
                value.z.Remap(from1.z, to1.z, from2.z, to2.z)
            );
          
        public static Vector3 Remap01(this Vector3 value, Vector3 from1, Vector3 to1) =>
            new(
                value.x.Remap01(from1.x, to1.x),
                value.y.Remap01(from1.y, to1.y),
                value.z.Remap01(from1.z, to1.z)
            );
          
        public static Vector3 RemapUnclamped(this Vector3 value, Vector3 from1, Vector3 to1, Vector3 from2, Vector3 to2) =>
            new(
                value.x.RemapUnclamped(from1.x, to1.x, from2.x, to2.x),
                value.y.RemapUnclamped(from1.y, to1.y, from2.y, to2.y),
                value.z.RemapUnclamped(from1.z, to1.z, from2.z, to2.z)
            );
        
        public static Vector3 Multiply(this Vector3 value, double scalar) => 
            new Vector3((float)(value.x * scalar), (float)(value.y * scalar), (float)(value.z * scalar));

        public static Vector2 XY(this Vector3 value) =>
            new(value.x, value.y);

        public static Vector2 XZ(this Vector3 value) =>
            new(value.x, value.z);

        public static Vector2 YX(this Vector3 value) =>
            new(value.y, value.x);

        public static Vector2 ZX(this Vector3 value) =>
            new(value.z, value.x);

        public static Vector3 YXZ(this Vector3 value) =>
            new(value.y, value.x, value.z);
        
        public static Vector3 X(this Vector3 value, float x) =>
            new(x, value.y, value.z);

        public static Vector3 Y(this Vector3 value, float y) =>
            new(value.x, y, value.z);

        public static Vector3 Z(this Vector3 value, float z) =>
            new(value.x, value.y, z);

        public static Vector3 XY(this Vector3 value, float x, float y) =>
            new(x, y, value.z);

        public static Vector3 XZ(this Vector3 value, float x, float z) =>
            new(x, value.y, z);

        public static Vector3 YZ(this Vector3 value, float y, float z) =>
            new(value.x, y, z);

        public static Vector3 AdjX(this Vector3 value, float x) =>
            new(value.x + x, value.y, value.z);

        public static Vector3 AdjY(this Vector3 value, float y) =>
            new(value.x, value.y + y, value.z);

        public static Vector3 AdjZ(this Vector3 value, float z) =>
            new(value.x, value.y, value.z + z);

        public static Vector3 AdjXY(this Vector3 value, float x, float y) =>
            new(value.x + x, value.y + y, value.z);

        public static Vector3 AdjXZ(this Vector3 value, float x, float z) =>
            new(value.x + x, value.y, value.z + z);

        public static Vector3 AdjYZ(this Vector3 value, float y, float z) =>
            new(value.x, value.y + y, value.z + z);

        public static Vector3 AdjXYZ(this Vector3 value, float x, float y, float z) =>
            new(value.x + x, value.y + y, value.z + z);

        public static Vector3 AdjAll(this Vector3 value, float all) =>
            new(value.x + all, value.y + all, value.z + all);
    }
}