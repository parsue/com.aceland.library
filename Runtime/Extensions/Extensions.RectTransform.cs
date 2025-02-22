using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static Bounds ToBounds(this RectTransform rectTransform)
        {
            var corners = new Vector3[4];
            rectTransform.GetLocalCorners(corners);
            
            var bounds = new Bounds(corners[0], Vector3.zero);
            for (var i = 1; i < corners.Length; i++)
                bounds.Encapsulate(corners[i]);

            return bounds;
        }

        public static Bounds ToWorldBounds(this RectTransform rectTransform)
        {
            var corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
            
            var bounds = new Bounds(corners[0], Vector3.zero);
            for (var i = 1; i < corners.Length; i++)
                bounds.Encapsulate(corners[i]);

            bounds.center = rectTransform.position;
            return bounds;
        }
    }
}
