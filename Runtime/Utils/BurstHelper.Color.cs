using UnityEngine;

namespace AceLand.Library.Utils
{
    public partial class BurstHelper
    {      
        public Color RandomColor(float alpha = 1) =>
            new Color(Random.value, Random.value, Random.value, alpha);
    }
}