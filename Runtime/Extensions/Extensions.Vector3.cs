using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {        
        public static Vector3 Remap(this Vector3 value, Vector3 from1, Vector3 to1, Vector3 from2, Vector3 to2)
        {
            var normalizedValueX = Mathf.InverseLerp(from1.x, to1.x, value.x);
            var normalizedValueY = Mathf.InverseLerp(from1.y, to1.y, value.y);
            var normalizedValueZ = Mathf.InverseLerp(from1.z, to1.z, value.z);

            var remappedValueX = Mathf.Lerp(from2.x, to2.x, normalizedValueX);
            var remappedValueY = Mathf.Lerp(from2.y, to2.y, normalizedValueY);
            var remappedValueZ = Mathf.Lerp(from2.z, to2.z, normalizedValueZ);

            return new Vector3(remappedValueX, remappedValueY, remappedValueZ);
        }
        
        public static Vector3 Multiply(this Vector3 vector, double scalar)
        {
            return new Vector3((float)(vector.x * scalar), (float)(vector.y * scalar), (float)(vector.z * scalar));
        }
        
        public static Vector2 xy(this Vector3 value)
        {
            return new Vector2(value.x, value.y);
        }
        
        public static Vector2 xz(this Vector3 value)
        {
            return new Vector2(value.x, value.z);
        }
        
        public static Vector3 x(this Vector3 value, float x)
        {
            var v3 = value;
            v3.x = x;
            return v3;
        }

        public static Vector3 yz(this Vector3 value, float y, float z)
        {
            var v3 = value;
            v3.y = y;
            v3.z = z;
            return v3;
        }

        public static Vector3 y(this Vector3 value, float y)
        {
            var v3 = value;
            v3.y = y;
            return v3;
        }

        public static Vector3 xz(this Vector3 value, float x, float z)
        {
            var v3 = value;
            v3.x = x;
            v3.z = z;
            return v3;
        }

        public static Vector3 z(this Vector3 value, float z)
        {
            var v3 = value;
            v3.z = z;
            return v3;
        }

        public static Vector3 xy(this Vector3 value, float x, float y)
        {
            var v3 = value;
            v3.x = x;
            v3.y = y;
            return v3;
        }

        public static Vector3 AdjX(this Vector3 value, float x)
        {
            var v3 = value;
            v3.x += x;
            return v3;
        }

        public static Vector3 AdjYZ(this Vector3 value, float y, float z)
        {
            var v3 = value;
            v3.y += y;
            v3.z += z;
            return v3;
        }

        public static Vector3 AdjY(this Vector3 value, float y)
        {
            var v3 = value;
            v3.y += y;
            return v3;
        }

        public static Vector3 AdjXZ(this Vector3 value, float x, float z)
        {
            var v3 = value;
            v3.x += x;
            v3.z += z;
            return v3;
        }

        public static Vector3 AdjZ(this Vector3 value, float z)
        {
            var v3 = value;
            v3.z += z;
            return v3;
        }

        public static Vector3 AdjXY(this Vector3 value, float x, float y)
        {
            var v3 = value;
            v3.x += x;
            v3.y += y;
            return v3;
        }

        public static Vector3 Adj(this Vector3 value, float x, float y, float z)
        {
            var v3 = value;
            v3.x += x;
            v3.y += y;
            v3.z += z;
            return v3;
        }

        public static Vector3 Adj(this Vector3 value, float all)
        {
            var v3 = value;
            v3.x += all;
            v3.y += all;
            v3.z += all;
            return v3;
        }
    }
}