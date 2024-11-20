using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool Contains(this LayerMask layerMask, int layer) =>
            layerMask == (layerMask | (1 << layer));
    }
}
