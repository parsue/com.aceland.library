using AceLand.Library.Utils;
using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNan(this float3 value)
        {
            return float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z);
        }  
        
        public static float3 Multiply(this float3 vector, double scalar)
        {
            return new float3((float)(vector.x * scalar), (float)(vector.y * scalar), (float)(vector.z * scalar));
        }
        
        public static float3 x(this float3 value, float x)
        {
            var v3 = value;
            v3.x = x;
            return v3;
        }

        public static float3 y(this float3 value, float y)
        {
            var v3 = value;
            v3.y = y;
            return v3;
        }

        public static float3 z(this float3 value, float z)
        {
            var v3 = value;
            v3.z = z;
            return v3;
        }

        public static float3 AdjX(this float3 value, float x)
        {
            var v3 = value;
            v3.x += x;
            return v3;
        }

        public static float3 AdjY(this float3 value, float y)
        {
            var v3 = value;
            v3.y += y;
            return v3;
        }

        public static float3 AdjZ(this float3 value, float z)
        {
            var v3 = value;
            v3.z += z;
            return v3;
        }

        public static float3 AdjXY(this float3 value, float x, float y)
        {
            var v3 = value;
            v3.x += x;
            v3.y += y;
            return v3;
        }

        public static float3 AdjXZ(this float3 value, float x, float z)
        {
            var v3 = value;
            v3.x += x;
            v3.z += z;
            return v3;
        }

        public static float3 AdjYZ(this float3 value, float y, float z)
        {
            var v3 = value;
            v3.y += y;
            v3.z += z;
            return v3;
        }

        public static float3 Adj(this float3 value, float x, float y, float z)
        {
            var v3 = value;
            v3.x += x;
            v3.y += y;
            v3.z += z;
            return v3;
        }

        public static float3 Adj(this float3 value, float all)
        {
            var v3 = value;
            v3.x += all;
            v3.y += all;
            v3.z += all;
            return v3;
        }
    }
}