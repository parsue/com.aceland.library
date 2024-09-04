using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Vector3Int x(this Vector3Int value, int x)
        {
            var v3 = value;
            v3.x = x;
            return v3;
        }

        public static Vector3Int x(this Vector3Int value, int y, int z)
        {
            var v3 = value;
            v3.y = y;
            v3.z = z;
            return v3;
        }

        public static Vector3Int y(this Vector3Int value, int y)
        {
            var v3 = value;
            v3.y = y;
            return v3;
        }

        public static Vector3Int y(this Vector3Int value, int x, int z)
        {
            var v3 = value;
            v3.x = x;
            v3.z = z;
            return v3;
        }

        public static Vector3Int z(this Vector3Int value, int z)
        {
            var v3 = value;
            v3.z = z;
            return v3;
        }

        public static Vector3Int z(this Vector3Int value, int x, int y)
        {
            var v3 = value;
            v3.x = x;
            v3.y = y;
            return v3;
        }

        public static Vector3Int AdjX(this Vector3Int value, int x)
        {
            var v3 = value;
            v3.x += x;
            return v3;
        }

        public static Vector3Int AdjX(this Vector3Int value, int y, int z)
        {
            var v3 = value;
            v3.y += y;
            v3.z += z;
            return v3;
        }

        public static Vector3Int AdjY(this Vector3Int value, int y)
        {
            var v3 = value;
            v3.y += y;
            return v3;
        }

        public static Vector3Int AdjY(this Vector3Int value, int x, int z)
        {
            var v3 = value;
            v3.x += x;
            v3.z += z;
            return v3;
        }

        public static Vector3Int AdjZ(this Vector3Int value, int z)
        {
            var v3 = value;
            v3.z += z;
            return v3;
        }

        public static Vector3Int AdjZ(this Vector3Int value, int x, int y)
        {
            var v3 = value;
            v3.x += x;
            v3.y += y;
            return v3;
        }

        public static Vector3Int Adj(this Vector3Int value, int x, int y, int z)
        {
            var v3 = value;
            v3.x += x;
            v3.y += y;
            v3.z += z;
            return v3;
        }

        public static Vector3Int Adj(this Vector3Int value, int all)
        {
            var v3 = value;
            v3.x += all;
            v3.y += all;
            v3.z += all;
            return v3;
        }
    }
}
