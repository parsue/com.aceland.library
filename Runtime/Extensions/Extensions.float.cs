using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {    
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            var normalizedValue = Mathf.InverseLerp(from1, to1, value);
            var remappedValue = Mathf.Lerp(from2, to2, normalizedValue);
            return remappedValue;
        }

        public static float Remap01(this float value, float from1, float to1)
        {
            if (Mathf.Approximately(to1, from1)) return value;
            return Mathf.Clamp((value - from1) / (to1 - from1), 0, 1);
        }

        public static bool IsBetween(this float value, float min, float max, bool includingMax = false)
        {
            return includingMax switch
            {
                true => value >= min && value <= max,
                false => value >= min && value < max,
            };
        }
    }
}