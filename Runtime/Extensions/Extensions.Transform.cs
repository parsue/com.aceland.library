using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static void DeleteAllChildren(this Transform transform)
        {
            while (transform.childCount > 0)
                Object.Destroy(transform.GetChild(0).gameObject);
        }

        public static void CopyDataFrom(this Transform transform, Transform source, bool copyScale = false)
        {
            transform.SetPositionAndRotation(source.position, source.rotation);
            if (copyScale) transform.localScale = source.localScale;
        }
    }
}
