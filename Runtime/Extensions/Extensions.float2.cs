using AceLand.Library.Utils;
using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this float2 value)
        {
            return float.IsNaN(value.x) || float.IsNaN(value.y);
        }     
        
        public static float2 x(this float2 value, float x)
        {
            var v = value;
            v.x = x;
            return v;
        }

        public static float2 y(this float2 value, float y)
        {
            var v = value;
            v.y = y;
            return v;
        }

        public static float2 AdjX(this float2 value, float x)
        {
            var v = value;
            v.x += x;
            return v;
        }

        public static float2 AdjY(this float2 value, float y)
        {
            var v = value;
            v.y += y;
            return v;
        }

        public static float2 Adj(this float2 value, float x, float y)
        {
            var v = value;
            v.x += x;
            v.y += y;
            return v;
        }

        public static float2 Adj(this float2 value, float all)
        {
            var v = value;
            v.x += all;
            v.y += all;
            return v;
        }
    }
}
