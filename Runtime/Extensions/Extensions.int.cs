using System;
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

        public static int SnapToCeil(this int value, snapValue)
        {
            var i = value / snapValue;
            Mathf.CeilToInt(i) * snapValue;
        }

        public static int SnapToFloor(this int value, snapValue)
        {
            var i = value / snapValue;
            Mathf.FloorToInt(i) * snapValue;
        }

        public static int RemapInt(this int value, float from1, float to1, float from2, float to2)
        {
            if (Mathf.Approximately(to2, from2)) return (int)to2;
            if (Mathf.Approximately(to1, from1)) return value;
            return (int)Math.Clamp((value - from1) / (to1 - from1) * (to2 - from2) + from2, from2, to2);
        }

        public static float Remap(this int value, float from1, float to1, float from2, float to2)
        {
            if (Mathf.Approximately(to2, from2)) return (int)to2;
            if (Mathf.Approximately(to1, from1)) return value;
            return Math.Clamp((value - from1) / (to1 - from1) * (to2 - from2) + from2, from2, to2);
        }

        public static float Remap01(this int value, float from1, float to1)
        {
            if (Mathf.Approximately(to1, from1)) return value;
            return Math.Clamp((value - from1) / (to1 - from1), 0, 1);
        }
        
        public static int RemapIntUnclamped(this int value, float from1, float to1, float from2, float to2)
        {
            if (to1 - from1 == 0) return (int)from2;
            
            var scale = (to2 - from2) / (to1 - from1);
            return (int)(from2 + (value - from1) * scale);
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
