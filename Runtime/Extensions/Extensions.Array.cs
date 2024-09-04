using System;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static void SwapElements<T>(this T[] array, int index1, int index2)
        {
            if (index1 < 0 || index1 >= array.Length || index2 < 0 || index2 >= array.Length)
            {
                throw new ArgumentOutOfRangeException("Indices must be within the array bounds.");
            }

            (array[index1], array[index2]) = (array[index2], array[index1]);
        }
    }
}