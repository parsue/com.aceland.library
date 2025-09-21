using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Texture2D CropAndResizeToSquare(this Texture2D originalTexture, int squareSize)
        {
            // Get the original width and height
            var originalWidth = originalTexture.width;
            var originalHeight = originalTexture.height;

            // Calculate the size of the square (use the smaller dimension)
            var cropSize = Mathf.Min(originalWidth, originalHeight);

            // Calculate the starting point to crop the center
            var startX = (originalWidth - cropSize) / 2;
            var startY = (originalHeight - cropSize) / 2;

            // Get the pixel data of the cropped region
            var croppedPixels = originalTexture.GetPixels(startX, startY, cropSize, cropSize);

            // Create a new texture for the cropped square
            var croppedTexture = new Texture2D(cropSize, cropSize);
            croppedTexture.SetPixels(croppedPixels);
            croppedTexture.Apply();

            // Resize the cropped square texture to the desired size
            var resizedTexture = Resize(croppedTexture, squareSize, squareSize);

            return resizedTexture;
        }

        public static Texture2D Resize(this Texture2D originalTexture, int targetWidth, int targetHeight)
        {
            // Create a new Texture2D with the target dimensions
            var resizedTexture = new Texture2D(targetWidth, targetHeight, originalTexture.format, false);

            // Scale the pixels using bilinear filtering
            var originalPixels = originalTexture.GetPixels();
            var resizedPixels = new Color[targetWidth * targetHeight];

            var xRatio = (float)originalTexture.width / targetWidth;
            var yRatio = (float)originalTexture.height / targetHeight;

            for (var y = 0; y < targetHeight; y++)
            {
                for (var x = 0; x < targetWidth; x++)
                {
                    // Sample the original texture at the scaled positions
                    var originalX = x * xRatio;
                    var originalY = y * yRatio;

                    var xFloor = Mathf.FloorToInt(originalX);
                    var yFloor = Mathf.FloorToInt(originalY);

                    var xCeil = Mathf.Min(xFloor + 1, originalTexture.width - 1);
                    var yCeil = Mathf.Min(yFloor + 1, originalTexture.height - 1);

                    // Perform bilinear interpolation
                    var topLeft = originalPixels[yFloor * originalTexture.width + xFloor];
                    var topRight = originalPixels[yFloor * originalTexture.width + xCeil];
                    var bottomLeft = originalPixels[yCeil * originalTexture.width + xFloor];
                    var bottomRight = originalPixels[yCeil * originalTexture.width + xCeil];

                    var xLerp = originalX - xFloor;
                    var yLerp = originalY - yFloor;

                    var top = Color.Lerp(topLeft, topRight, xLerp);
                    var bottom = Color.Lerp(bottomLeft, bottomRight, xLerp);
                    var pixel = Color.Lerp(top, bottom, yLerp);

                    resizedPixels[y * targetWidth + x] = pixel;
                }
            }

            // Set the resized pixels and apply changes
            resizedTexture.SetPixels(resizedPixels);
            resizedTexture.Apply();

            return resizedTexture;
        }

        public static Texture2D Resize(this Texture2D originalTexture, int maxSize)
        {
            // Get the original width and height
            var originalWidth = originalTexture.width;
            var originalHeight = originalTexture.height;

            if (originalWidth <= maxSize && originalHeight <= maxSize)
                return originalTexture;

            // Calculate the aspect ratio
            var aspectRatio = (float)originalWidth / originalHeight;

            // Determine the new width and height while keeping the aspect ratio
            var newWidth = originalWidth;
            var newHeight = originalHeight;

            if (originalWidth > maxSize || originalHeight > maxSize)
            {
                if (originalWidth > originalHeight)
                {
                    newWidth = maxSize;
                    newHeight = Mathf.RoundToInt(maxSize / aspectRatio);
                }
                else
                {
                    newHeight = maxSize;
                    newWidth = Mathf.RoundToInt(maxSize * aspectRatio);
                }
            }

            // Create a new texture with the new dimensions
            var resizedTexture = new Texture2D(newWidth, newHeight, originalTexture.format, false);

            // Scale the pixels using bilinear filtering
            var pixels = originalTexture.GetPixels(0, 0, originalWidth, originalHeight);
            var resizedPixels = pixels.ResizePixels(originalWidth, originalHeight, newWidth, newHeight);
            resizedTexture.SetPixels(resizedPixels);
            resizedTexture.Apply();

            return resizedTexture;
        }
    }
}
