using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this float2 value)
        {
            return float.IsNaN(value.x) || float.IsNaN(value.y);
        }
    }
}
