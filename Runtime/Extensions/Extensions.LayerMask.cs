using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool Contains(this LayerMask layermask, int layer)
        {
            return layermask == (layermask | (1 << layer));
        }
    }
}
