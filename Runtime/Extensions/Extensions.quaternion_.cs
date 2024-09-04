using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNaN(this quaternion value)
        {
            return float.IsNaN(value.value.x) || float.IsNaN(value.value.y) || float.IsNaN(value.value.z) || float.IsNaN(value.value.w);
        }

        public static quaternion MinusOne(this quaternion value)
        {
            return new quaternion(value.value.x * -1, value.value.y * -1, value.value.z * -1, value.value.w * -1);
        }
    }
}
