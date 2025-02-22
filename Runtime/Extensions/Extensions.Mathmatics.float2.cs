using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this float2 value) => 
            float.IsNaN(value.x) || float.IsNaN(value.y);
        
        public static float2 Multiply(this float2 value, double scalar) =>
            new((float)(value.x * scalar), (float)(value.y * scalar));

        public static float2 Average(float2[] vectors)
        {
            if (vectors == null || vectors.Length == 0)
                return float2.zero;
    
            float2 sum = float2.zero;
            foreach (var vector in vectors)
                sum += vector;
    
            return sum / vectors.Length;
        }

        public static float3 Z(this float2 value, float z = 0) =>
            new float3(value.x, value.y, z);

        public static float4 ZW(this float2 value, float z = 0, float w = 0) =>
            new float4(value.x, value.y, z, w);

        public static float3 YXZ(this float2 value, float z = 0) =>
            new float3(value.y, value.x, z);

        public static float4 YXZW(this float2 value, float z = 0, float w = 0) =>
            new float4(value.y, value.x, z, w);
        
        public static float2 X(this float2 value, float x) =>
            new(x, value.y);

        public static float2 Y(this float2 value, float y) =>
            new(value.x, y);

        public static float2 AdjX(this float2 value, float x) =>
            new(value.x + x, value.y);

        public static float2 AdjY(this float2 value, float y) =>
            new(value.x, value.y + y);

        public static float2 AdjXY(this float2 value, float x, float y) =>
            new(value.x + x, value.y + y);

        public static float2 AdjAll(this float2 value, float all) =>
            new(value.x + all, value.y + all);
    }
}
