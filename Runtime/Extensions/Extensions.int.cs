using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsBetween(this int value, int min, int max, bool includingMax = false)
        {
            return includingMax switch
            {
                true => value >= min && value <= max,
                false => value >= min && value < max,
            };
        }

        public static int SnapToCeil(this int value, int snapValue)
        {
            return Mathf.CeilToInt((float)value / snapValue) * snapValue;
        }

        public static int SnapToFloor(this int value, int snapValue)
        {
            return Mathf.FloorToInt((float)value / snapValue) * snapValue;
        }

        public static int RemapInt(this int value, float from1, float to1, float from2, float to2)
        {
            return (int)Remap(value, from1, to1, from2, to2);
        }

        public static float Remap(this int value, float from1, float to1, float from2, float to2)
        {
            var normalizedValue = Mathf.InverseLerp(from1, to1, value);
            var remappedValue = Mathf.Lerp(from2, to2, normalizedValue);
            return remappedValue;
        }

        public static float Remap01(this int value, float from1, float to1)
        {
            return Mathf.Approximately(to1, from1) 
                ? value 
                : Mathf.Clamp((value - from1) / (to1 - from1), 0, 1);
        }
        
        public static int RemapIntUnclamped(this int value, float from1, float to1, float from2, float to2)
        {
            return (int)RemapUnclamped(value, from1, to1, from2, to2);
        }
        
        public static float RemapUnclamped(this int value, float from1, float to1, float from2, float to2)
        {
            if (to1 - from1 == 0) return from2;
            var scale = (to2 - from2) / (to1 - from1);
            return from2 + (value - from1) * scale;
        }

        public static string SizeSuffix(this int value, int decimalPlaces = 2)
        {
            long v = value;
            return v.SizeSuffix(decimalPlaces);
        }

        public static string CurrencySuffix(this int value, int decimalPlaces = 0)
        {
            long v = value;
            return v.CurrencySuffix(decimalPlaces);
        }
    }
}
