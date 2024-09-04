using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Vector4 x(this Vector4 value, float x)
        {
            var v4 = value;
            v4.x = x;
            return v4;
        }

        public static Vector4 x(this Vector4 value, float y, float z, float w)
        {
            var v4 = value;
            v4.y = y;
            v4.z = z;
            v4.w = w;
            return v4;
        }

        public static Vector4 y(this Vector4 value, float y)
        {
            var v4 = value;
            v4.y = y;
            return v4;
        }

        public static Vector4 y(this Vector4 value, float x, float z, float w)
        {
            var v4 = value;
            v4.x = x;
            v4.z = z;
            v4.w = w;
            return v4;
        }

        public static Vector4 z(this Vector4 value, float z)
        {
            var v4 = value;
            v4.z = z;
            return v4;
        }

        public static Vector4 z(this Vector4 value, float x, float y, float w)
        {
            var v4 = value;
            v4.x = x;
            v4.y = y;
            v4.w = w;
            return v4;
        }

        public static Vector4 w(this Vector4 value, float w)
        {
            var v4 = value;
            v4.w = w;
            return v4;
        }

        public static Vector4 w(this Vector4 value, float x, float y, float z)
        {
            var v4 = value;
            v4.x = x;
            v4.y = y;
            v4.z = z;
            return v4;
        }

        public static Vector4 AdjX(this Vector4 value, float x)
        {
            var v4 = value;
            v4.x += x;
            return v4;
        }

        public static Vector4 AdjX(this Vector4 value, float y, float z, float w)
        {
            var v4 = value;
            v4.y += y;
            v4.z += z;
            v4.w += w;
            return v4;
        }

        public static Vector4 AdjY(this Vector4 value, float y)
        {
            var v4 = value;
            v4.y += y;
            return v4;
        }

        public static Vector4 AdjY(this Vector4 value, float x, float z, float w)
        {
            var v4 = value;
            v4.x += x;
            v4.z += z;
            v4.w += w;
            return v4;
        }

        public static Vector4 AdjZ(this Vector4 value, float z)
        {
            var v4 = value;
            v4.z += z;
            return v4;
        }

        public static Vector4 AdjZ(this Vector4 value, float x, float y, float w)
        {
            var v4 = value;
            v4.x += x;
            v4.y += y;
            v4.w += w;
            return v4;
        }

        public static Vector4 AdjW(this Vector4 value, float w)
        {
            var v4 = value;
            v4.w += w;
            return v4;
        }

        public static Vector4 AdjW(this Vector4 value, float x, float y, float z)
        {
            var v4 = value;
            v4.x += x;
            v4.y += y;
            v4.z += z;
            return v4;
        }

        public static Vector4 Adj(this Vector4 value, float x, float y, float z, float w)
        {
            var v4 = value;
            v4.x += x;
            v4.y += y;
            v4.z += z;
            v4.w += w;
            return v4;
        }

        public static Vector4 Adj(this Vector4 value, float all)
        {
            var v4 = value;
            v4.x += all;
            v4.y += all;
            v4.z += all;
            v4.w += all;
            return v4;
        }
    }
}
