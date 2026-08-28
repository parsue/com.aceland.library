using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static float Brightness(this Color value) =>
            value.r * DesaturationValue.x + value.g * DesaturationValue.y + value.b * DesaturationValue.z;

        public static Color Mono(this Color value)
        {
            var brightness = value.Brightness();
            return new Color(brightness, brightness, brightness);
        }

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
