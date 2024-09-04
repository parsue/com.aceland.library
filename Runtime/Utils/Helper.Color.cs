using UnityEngine;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {      
        
        public static Color RandomColor(float alpha = 1)
        {
            return new Color(
                Random.value,
                Random.value,
                Random.value,
                alpha
            );
        }
    }
}