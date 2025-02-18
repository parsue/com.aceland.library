using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Vector2 Remap(this Vector2 value, Vector2 from1, Vector2 to1, Vector2 from2, Vector2 to2) =>
            new(
                value.x.Remap(from1.x, to1.x, from2.x, to2.x),
                value.y.Remap(from1.y, to1.y, from2.y, to2.y)
            );
          
        public static Vector2 Remap01(this Vector2 value, Vector2 from1, Vector2 to1) =>
            new(
                value.x.Remap01(from1.x, to1.x),
                value.y.Remap01(from1.y, to1.y)
            );
          
        public static Vector2 RemapUnclamped(this Vector2 value, Vector2 from1, Vector2 to1, Vector2 from2, Vector2 to2) =>
            new(
                value.x.RemapUnclamped(from1.x, to1.x, from2.x, to2.x),
                value.y.RemapUnclamped(from1.y, to1.y, from2.y, to2.y)
            );

        public static Vector2 Multiply(this Vector2 value, double scalar) => 
            new Vector2((float)(value.x * scalar), (float)(value.y * scalar));

        public static Vector3 Z(this Vector2 value, float z = 0) =>
            new Vector3(value.x, value.y, z);

        public static Vector4 ZW(this Vector2 value, float z = 0, float w = 0) =>
            new Vector4(value.x, value.y, z, w);

        public static Vector3 YXZ(this Vector2 value, float z = 0) =>
            new Vector3(value.y, value.x, z);

        public static Vector4 YXZW(this Vector2 value, float z = 0, float w = 0) =>
            new Vector4(value.y, value.x, z, w);

        public static Vector2 YX(this Vector2 value) =>
            new(value.y, value.x);
        
        public static Vector2 X(this Vector2 value, float x) =>
            new(x, value.y);

        public static Vector2 Y(this Vector2 value, float y) =>
            new(value.x, y);

        public static Vector2 AdjX(this Vector2 value, float x) =>
            new(value.x + x, value.y);

        public static Vector2 AdjY(this Vector2 value, float y) =>
            new(value.x, value.y + y);

        public static Vector2 AdjXY(this Vector2 value, float x, float y) =>
            new(value.x + x, value.y + y);

        public static Vector2 AdjAll(this Vector2 value, float all) =>
            new(value.x + all, value.y + all);
    }
}
