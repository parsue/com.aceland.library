using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static void SwapElements<T>(this T[] array, int index1, int index2)
        {
            var lastIndex = array.Length - 1;
            if (index1 < 0 || index1 > lastIndex)
                index1 = Mathf.Clamp(index1, 0, array.Length - 1);
            if (index2 < 0 || index2 > lastIndex)
                index2 = Mathf.Clamp(index2, 0, array.Length - 1);
            
            if (index1 == index2) return;
            (array[index1], array[index2]) = (array[index2], array[index1]);
        }
    }
}