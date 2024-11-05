using System.Collections.Generic;
using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this float4 value)
        {
            return float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z) || float.IsNaN(value.w);
        }
        
        public static float4 x(this float4 value, float x)
        {
            var v4 = value;
            v4.x = x;
            return v4;
        }

        public static float4 x(this float4 value, float y, float z, float w)
        {
            var v4 = value;
            v4.y = y;
            v4.z = z;
            v4.w = w;
            return v4;
        }

        public static float4 y(this float4 value, float y)
        {
            var v4 = value;
            v4.y = y;
            return v4;
        }

        public static float4 y(this float4 value, float x, float z, float w)
        {
            var v4 = value;
            v4.x = x;
            v4.z = z;
            v4.w = w;
            return v4;
        }

        public static float4 z(this float4 value, float z)
        {
            var v4 = value;
            v4.z = z;
            return v4;
        }

        public static float4 z(this float4 value, float x, float y, float w)
        {
            var v4 = value;
            v4.x = x;
            v4.y = y;
            v4.w = w;
            return v4;
        }

        public static float4 w(this float4 value, float w)
        {
            var v4 = value;
            v4.w = w;
            return v4;
        }

        public static float4 w(this float4 value, float x, float y, float z)
        {
            var v4 = value;
            v4.x = x;
            v4.y = y;
            v4.z = z;
            return v4;
        }

        public static float4 AdjX(this float4 value, float x)
        {
            var v4 = value;
            v4.x += x;
            return v4;
        }

        public static float4 AdjX(this float4 value, float y, float z, float w)
        {
            var v4 = value;
            v4.y += y;
            v4.z += z;
            v4.w += w;
            return v4;
        }

        public static float4 AdjY(this float4 value, float y)
        {
            var v4 = value;
            v4.y += y;
            return v4;
        }

        public static float4 AdjY(this float4 value, float x, float z, float w)
        {
            var v4 = value;
            v4.x += x;
            v4.z += z;
            v4.w += w;
            return v4;
        }

        public static float4 AdjZ(this float4 value, float z)
        {
            var v4 = value;
            v4.z += z;
            return v4;
        }

        public static float4 AdjZ(this float4 value, float x, float y, float w)
        {
            var v4 = value;
            v4.x += x;
            v4.y += y;
            v4.w += w;
            return v4;
        }

        public static float4 AdjW(this float4 value, float w)
        {
            var v4 = value;
            v4.w += w;
            return v4;
        }

        public static float4 AdjW(this float4 value, float x, float y, float z)
        {
            var v4 = value;
            v4.x += x;
            v4.y += y;
            v4.z += z;
            return v4;
        }

        public static float4 Adj(this float4 value, float x, float y, float z, float w)
        {
            var v4 = value;
            v4.x += x;
            v4.y += y;
            v4.z += z;
            v4.w += w;
            return v4;
        }

        public static float4 Adj(this float4 value, float all)
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
