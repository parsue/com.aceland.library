using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Quaternion Negative(this Quaternion value) =>
            new(value.x * -1, value.y * -1, value.z * -1, value.w * -1);
    }
}
