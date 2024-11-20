using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this float2 value) => 
            float.IsNaN(value.x) || float.IsNaN(value.y);
        
        public static float2 Multiply(this float2 value, double scalar) =>
            new((float)(value.x * scalar), (float)(value.y * scalar));
        
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
