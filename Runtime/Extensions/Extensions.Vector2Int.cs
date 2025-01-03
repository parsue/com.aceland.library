using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static int CompareTo(this Vector2Int value, Vector2Int valueB)
        {
            if (value.x < valueB.x) return -1;
            if (value.x > valueB.x) return 1;
            if (value.x == valueB.x)
            {
                if (value.y < valueB.y) return -1;
                if (value.y > valueB.y) return 1;
                return 0;
            }
            return 0;
        }

        public static Vector2Int YX(this Vector2Int value) =>
            new(value.y, value.x);
        
        public static Vector2Int X(this Vector2Int value, int x) =>
            new(x, value.y);

        public static Vector2Int Y(this Vector2Int value, int y) =>
            new(value.x, y);

        public static Vector2Int AdjX(this Vector2Int value, int x) =>
            new(value.x + x, value.y);

        public static Vector2Int AdjY(this Vector2Int value, int y) =>
            new(value.x, value.y + y);

        public static Vector2Int AdjXY(this Vector2Int value, int x, int y) =>
            new(value.x + x, value.y + y);

        public static Vector2Int AdjAll(this Vector2Int value, int all) =>
            new(value.x + all, value.y + all);
    }
}
