using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly Vector3 DESATUATION_VALUE = new(0.2126f, 0.7152f, 0.0722f);

        public static float Brightness(this Color value) =>
            value.r * DESATUATION_VALUE.x + value.g * DESATUATION_VALUE.y + value.b * DESATUATION_VALUE.z;

        public static Color Mono(this Color value) =>
            new(value.r * DESATUATION_VALUE.x, value.g * DESATUATION_VALUE.y, value.b * DESATUATION_VALUE.z);

        public static Color R(this Color value, float r) =>
            new(r, value.g, value.b, value.a);
        
        public static Color G(this Color value, float g) =>
            new(value.r, g, value.b, value.a);
        
        public static Color B(this Color value, float b) =>
            new(value.r, value.g, b, value.a);
        
        public static Color A(this Color value, float a) =>
            new(value.r, value.g, value.b, a);

        public static Color RG(this Color value, float r, float g) =>
            new(r, g, value.b, value.a);

        public static Color RB(this Color value, float r, float b) =>
            new(r, value.g, b, value.a);

        public static Color GB(this Color value, float g, float b) =>
            new(value.r, g, b, value.a);

        public static Color RGA(this Color value, float r, float g, float a) =>
            new(r, g, value.b, a);

        public static Color RBA(this Color value, float r, float b, float a) =>
            new(r, value.g, b, a);

        public static Color GBA(this Color value, float g, float b, float a) =>
            new(value.r, g, b, a);
    }
}