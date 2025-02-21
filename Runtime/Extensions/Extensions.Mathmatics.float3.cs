using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNan(this float3 value) =>
            float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z);
        
        public static float3 Multiply(this float3 value, double scalar) =>
            new((float)(value.x * scalar), (float)(value.y * scalar), (float)(value.z * scalar));

        public static float3 Average(float3[] vectors)
        {
            if (vectors == null || vectors.Length == 0)
                return float3.zero;
    
            float3 sum = float3.zero;
            foreach (var vector in vectors)
                sum += vector;
    
            return sum / vectors.Length;
        }

        public static float3 X(this float3 value, float x) =>
            new(x, value.y, value.z);

        public static float3 Y(this float3 value, float y) =>
            new(value.x, y, value.z);

        public static float3 Z(this float3 value, float z) =>
            new(value.x, value.y, z);

        public static float3 XY(this float3 value, float x, float y) =>
            new(x, y, value.z);

        public static float3 XZ(this float3 value, float x, float z) =>
            new(x, value.y, z);

        public static float3 YZ(this float3 value, float y, float z) =>
            new(value.x, y, z);

        public static float3 AdjX(this float3 value, float x) =>
            new(value.x + x, value.y, value.z);

        public static float3 AdjY(this float3 value, float y) =>
            new(value.x, value.y + y, value.z);

        public static float3 AdjZ(this float3 value, float z) =>
            new(value.x, value.y, value.z + z);

        public static float3 AdjXY(this float3 value, float x, float y) =>
            new(value.x + x, value.y + y, value.z);

        public static float3 AdjXZ(this float3 value, float x, float z) =>
            new(value.x + x, value.y, value.z + z);

        public static float3 AdjYZ(this float3 value, float y, float z) =>
            new(value.x, value.y + y, value.z + z);
        
        public static float3 AdjXYZ(this float3 value, float x, float y, float z) =>
            new(value.x + x, value.y + y, value.z + z);

        public static float3 AdjAll(this float3 value, float all) =>
            new(value.x + all, value.y + all, value.z + all);
    }
}
