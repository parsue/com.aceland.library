using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static int CompareTo(this Vector3Int value, Vector3Int valueB)
        {
            if (value.x < valueB.x) return -1;
            if (value.x > valueB.x) return 1;
            if (value.x == valueB.x)
            {
                if (value.y < valueB.y) return -1;
                if (value.y > valueB.y) return 1;
                if (value.y == valueB.y)
                {
                    if (value.z < valueB.z) return -1;
                    if (value.z > valueB.z) return 1;
                    return 0;
                }
            }
            return 0;
        }
        
        public static Vector2Int XY(this Vector3Int value) =>
            new(value.x, value.y);

        public static Vector2Int XZ(this Vector3Int value) =>
            new(value.x, value.z);

        public static Vector2Int YX(this Vector3Int value) =>
            new(value.y, value.x);

        public static Vector2Int ZX(this Vector3Int value) =>
            new(value.z, value.x);

        public static Vector3Int YXZ(this Vector3Int value) =>
            new(value.y, value.x, value.z);
        
        public static Vector3Int X(this Vector3Int value, int x) =>
            new(x, value.y, value.z);

        public static Vector3Int Y(this Vector3Int value, int y) =>
            new(value.x, y, value.z);

        public static Vector3Int Z(this Vector3Int value, int z) =>
            new(value.x, value.y, z);

        public static Vector3Int XY(this Vector3Int value, int x, int y) =>
            new(x, y, value.z);

        public static Vector3Int XZ(this Vector3Int value, int x, int z) =>
            new(x, value.y, z);

        public static Vector3Int YZ(this Vector3Int value, int y, int z) =>
            new(value.x, y, z);

        public static Vector3Int AdjX(this Vector3Int value, int x) =>
            new(value.x + x, value.y, value.z);

        public static Vector3Int AdjY(this Vector3Int value, int y) =>
            new(value.x, value.y + y, value.z);

        public static Vector3Int AdjZ(this Vector3Int value, int z) =>
            new(value.x, value.y, value.z + z);

        public static Vector3Int AdjXY(this Vector3Int value, int x, int y) =>
            new(value.x + x, value.y + y, value.z);

        public static Vector3Int AdjXZ(this Vector3Int value, int x, int z) =>
            new(value.x + x, value.y, value.z + z);

        public static Vector3Int AdjYZ(this Vector3Int value, int y, int z) =>
            new(value.x, value.y + y, value.z + z);

        public static Vector3Int AdjXYZ(this Vector3Int value, int x, int y, int z) =>
            new(value.x + x, value.y + y, value.z + z);

        public static Vector3Int AdjAll(this Vector3Int value, int all) =>
            new(value.x + all, value.y + all, value.z + all);
    }
}
