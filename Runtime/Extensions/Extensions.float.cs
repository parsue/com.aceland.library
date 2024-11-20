using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {    
        public static bool IsBetween(this float value, float min, float max, bool includingMax = false)
        {
            return includingMax
                ? value >= min && value <= max
                : value >= min && value < max;
        }
        
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            var normalizedValue = Mathf.InverseLerp(from1, to1, value);
            var remappedValue = Mathf.Lerp(from2, to2, normalizedValue);
            return remappedValue;
        }

        public static float Remap01(this float value, float from1, float to1)
        {
            return Mathf.Approximately(to1, from1) 
                ? value 
                : Mathf.Clamp((value - from1) / (to1 - from1), 0, 1);
        }
        
        public static float RemapUnclamped(this float value, float from1, float to1, float from2, float to2)
        {
            if (to1 - from1 == 0) return from2;
            
            var scale = (to2 - from2) / (to1 - from1);
            return from2 + (value - from1) * scale;
        }
    }
}