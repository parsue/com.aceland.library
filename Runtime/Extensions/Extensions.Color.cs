using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {        
        private static readonly Vector3 DESATUATION_VALUE = new(0.2126f, 0.7152f, 0.0722f);

        public static float Brightness(this Color value)
        {
            return value.r * DESATUATION_VALUE.x + value.g * DESATUATION_VALUE.y + value.b * DESATUATION_VALUE.z;
        }

        public static Color r(this Color value, float r)
        {
            var c1 = value;
            c1.r = r;
            return c1;
        }

        public static Color g(this Color value, float g)
        {
            var c1 = value;
            c1.g = g;
            return c1;
        }

        public static Color b(this Color value, float b)
        {
            var c1 = value;
            c1.b = b;
            return c1;
        }

        public static Color a(this Color value, float a)
        {
            var c1 = value;
            c1.a = a;
            return c1;
        }

        public static Color all(this Color value, float all)
        {
            var c1 = value;
            c1.r = all;
            c1.g = all;
            c1.b = all;
            return c1;
        }

        public static Color all(this Color value, float all, float a)
        {
            var c1 = value;
            c1.r = all;
            c1.g = all;
            c1.b = all;
            c1.a = a;
            return c1;
        }
    }
}