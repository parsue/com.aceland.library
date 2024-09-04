using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this float4 value)
        {
            return float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z) || float.IsNaN(value.w);
        }
    }
}
