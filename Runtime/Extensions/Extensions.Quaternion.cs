using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Quaternion Negative(this Quaternion value)
        {
            return new Quaternion(value.x * -1, value.y * -1, value.z * -1, value.w * -1);
        }

        public static Quaternion x(this Quaternion value, float x)
        {
            var q1 = value;
            q1.x = x;
            return q1;
        }

        public static Quaternion x(this Quaternion value, float y, float z, float w)
        {
            var q1 = value;
            q1.y = y;
            q1.z = z;
            q1.w = w;
            return q1;
        }

        public static Quaternion y(this Quaternion value, float y)
        {
            var q1 = value;
            q1.y = y;
            return q1;
        }

        public static Quaternion y(this Quaternion value, float x, float z, float w)
        {
            var q1 = value;
            q1.x = x;
            q1.z = z;
            q1.w = w;
            return q1;
        }

        public static Quaternion z(this Quaternion value, float z)
        {
            var q1 = value;
            q1.z = z;
            return q1;
        }

        public static Quaternion z(this Quaternion value, float x, float y, float w)
        {
            var q1 = value;
            q1.x = x;
            q1.y = y;
            q1.w = w;
            return q1;
        }

        public static Quaternion w(this Quaternion value, float w)
        {
            var q1 = value;
            q1.w = w;
            return q1;
        }

        public static Quaternion w(this Quaternion value, float x, float y, float z)
        {
            var q1 = value;
            q1.x = x;
            q1.y = y;
            q1.z = z;
            return q1;
        }

        public static Quaternion AdjX(this Quaternion value, float x)
        {
            var q1 = value;
            q1.x += x;
            return q1;
        }

        public static Quaternion AdjX(this Quaternion value, float y, float z, float w)
        {
            var q1 = value;
            q1.y += y;
            q1.z += z;
            q1.w += w;
            return q1;
        }

        public static Quaternion AdjY(this Quaternion value, float y)
        {
            var q1 = value;
            q1.y += y;
            return q1;
        }

        public static Quaternion AdjY(this Quaternion value, float x, float z, float w)
        {
            var q1 = value;
            q1.x += x;
            q1.z += z;
            q1.w += w;
            return q1;
        }

        public static Quaternion AdjZ(this Quaternion value, float z)
        {
            var q1 = value;
            q1.z += z;
            return q1;
        }

        public static Quaternion AdjZ(this Quaternion value, float x, float y, float w)
        {
            var q1 = value;
            q1.x += x;
            q1.y += y;
            q1.w += w;
            return q1;
        }

        public static Quaternion AdjW(this Quaternion value, float w)
        {
            var q1 = value;
            q1.w += w;
            return q1;
        }

        public static Quaternion AdjW(this Quaternion value, float x, float y, float z)
        {
            var q1 = value;
            q1.x += x;
            q1.y += y;
            q1.z += z;
            return q1;
        }

        public static Quaternion Adj(this Quaternion value, float x, float y, float z, float w)
        {
            var q1 = value;
            q1.x += x;
            q1.y += y;
            q1.z += z;
            q1.w += w;
            return q1;
        }

        public static Quaternion Adj(this Quaternion value, float all)
        {
            var q1 = value;
            q1.x += all;
            q1.y += all;
            q1.z += all;
            q1.w += all;
            return q1;
        }
    }
}
