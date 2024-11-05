using System;

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

        public static int RemapInt(this int value, float from1, float to1, float from2, float to2)
        {
            if (to2 == from2) return (int)to2;
            if (to1 == from1) return value;
            return (int)Math.Clamp((value - from1) / (to1 - from1) * (to2 - from2) + from2, from2, to2);
        }

        public static float Remap(this int value, float from1, float to1, float from2, float to2)
        {
            if (to2 == from2) return (int)to2;
            if (to1 == from1) return value;
            return Math.Clamp((value - from1) / (to1 - from1) * (to2 - from2) + from2, from2, to2);
        }

        public static float Remap01(this int value, float from1, float to1)
        {
            if (to1 == from1) return value;
            return Math.Clamp((value - from1) / (to1 - from1), 0, 1);
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
