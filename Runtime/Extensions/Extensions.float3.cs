using Unity.Mathematics;
using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNan(this float3 value)
        {
            return float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z);
        }
    }
}