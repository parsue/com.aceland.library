using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {        
        public static Vector2 Remap(this Vector2 value, Vector2 from1, Vector2 to1, Vector2 from2, Vector2 to2)
        {
            var normalizedValueX = Mathf.InverseLerp(from1.x, to1.x, value.x);
            var normalizedValueY = Mathf.InverseLerp(from1.y, to1.y, value.y);

            var remappedValueX = Mathf.Lerp(from2.x, to2.x, normalizedValueX);
            var remappedValueY = Mathf.Lerp(from2.y, to2.y, normalizedValueY);

            return new Vector2(remappedValueX, remappedValueY);
        }
        
        public static Vector2 yx(this Vector2 value)
        {
            return new Vector2(value.y, value.x);
        }
        
        public static Vector2 x(this Vector2 value, float x)
        {
            var v = value;
            v.x = x;
            return v;
        }

        public static Vector2 y(this Vector2 value, float y)
        {
            var v = value;
            v.y = y;
            return v;
        }

        public static Vector2 AdjX(this Vector2 value, float x)
        {
            var v = value;
            v.x += x;
            return v;
        }

        public static Vector2 AdjY(this Vector2 value, float y)
        {
            var v = value;
            v.y += y;
            return v;
        }

        public static Vector2 Adj(this Vector2 value, float x, float y)
        {
            var v = value;
            v.x += x;
            v.y += y;
            return v;
        }

        public static Vector2 Adj(this Vector2 value, float all)
        {
            var v = value;
            v.x += all;
            v.y += all;
            return v;
        }
    }
}