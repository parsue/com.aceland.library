using UnityEngine;

namespace AceLand.Library.Utils
{
    public partial class Helper
    {      
        public Color RandomColor(float alpha = 1) =>
            new Color(Random.value, Random.value, Random.value, alpha);
    }
}