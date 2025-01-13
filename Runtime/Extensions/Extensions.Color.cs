using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly Vector3 DesatuationValue = new(0.2126f, 0.7152f, 0.0722f);

        public static float Brightness(this Color value) =>
            value.r * DesatuationValue.x + value.g * DesatuationValue.y + value.b * DesatuationValue.z;

        public static Color Mono(this Color value) =>
            new(value.r * DesatuationValue.x, value.g * DesatuationValue.y, value.b * DesatuationValue.z);

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

        public static Color[] ResizePixels(this Color[] originalPixels,
            int originalWidth, int originalHeight, int newWidth, int newHeight)
        {
            var resizedPixels = new Color[newWidth * newHeight];

            var xRatio = (float)originalWidth / newWidth;
            var yRatio = (float)originalHeight / newHeight;

            for (var y = 0; y < newHeight; y++)
            {
                for (var x = 0; x < newWidth; x++)
                {
                    var originalX = x * xRatio;
                    var originalY = y * yRatio;

                    var xFloor = Mathf.FloorToInt(originalX);
                    var yFloor = Mathf.FloorToInt(originalY);

                    var xCeil = Mathf.Min(xFloor + 1, originalWidth - 1);
                    var yCeil = Mathf.Min(yFloor + 1, originalHeight - 1);

                    var topLeft = originalPixels[yFloor * originalWidth + xFloor];
                    var topRight = originalPixels[yFloor * originalWidth + xCeil];
                    var bottomLeft = originalPixels[yCeil * originalWidth + xFloor];
                    var bottomRight = originalPixels[yCeil * originalWidth + xCeil];

                    var xLerp = originalX - xFloor;
                    var yLerp = originalY - yFloor;

                    var top = Color.Lerp(topLeft, topRight, xLerp);
                    var bottom = Color.Lerp(bottomLeft, bottomRight, xLerp);
                    var pixel = Color.Lerp(top, bottom, yLerp);

                    resizedPixels[y * newWidth + x] = pixel;
                }
            }

            return resizedPixels;
        }
    }
}
