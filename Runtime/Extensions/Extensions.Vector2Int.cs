using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static int CompareTo(this Vector2Int value, Vector2Int valueB)
        {
            if (value.x < valueB.x) return value.y <= valueB.y ? -1 : 1;
            if (value.x > valueB.x) return value.y < valueB.y ? -1 : 1;
            if (value.x == valueB.x) return value.y < valueB.y ? -1 : value.y > valueB.y ? 1 : 0;
            return 0;
        }

        public static Vector2Int x(this Vector2Int value, int x)
        {
            var v = value;
            v.x = x;
            return v;
        }

        public static Vector2Int y(this Vector2Int value, int y)
        {
            var v = value;
            v.y = y;
            return v;
        }

        public static Vector2Int AdjX(this Vector2Int value, int x)
        {
            var v = value;
            v.x += x;
            return v;
        }

        public static Vector2Int AdjY(this Vector2Int value, int y)
        {
            var v = value;
            v.y += y;
            return v;
        }

        public static Vector2Int Adj(this Vector2Int value, int x, int y)
        {
            var v = value;
            v.x += x;
            v.y += y;
            return v;
        }

        public static Vector2Int Adj(this Vector2Int value, int all)
        {
            var v = value;
            v.x += all;
            v.y += all;
            return v;
        }
    }
}
