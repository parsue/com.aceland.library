using System.Collections.Generic;
using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static void DestroyAllChildren(this Transform transform)
        {
            while (transform.childCount > 0)
            {
                var child = transform.GetChild(0).gameObject;
                if (Application.isPlaying) Object.DestroyImmediate(child);
                else Object.Destroy(child);
            }
        }
        
        public static void DestroyAllChildren(this MonoBehaviour mono)
        {
            DestroyAllChildren(mono.transform);
        }

        public static void DestroyAllChildren<T>(this Transform transform) where T : MonoBehaviour
        {
            var list = new List<T>();
            foreach (var child in transform)
                if (child is T t) list.Add(t);

            foreach (var item in list)
            {
                if (Application.isPlaying) Object.DestroyImmediate(item);
                else Object.Destroy(item);
            }
        }
        
        public static void DestroyAllChildren<T>(this MonoBehaviour mono) where T : MonoBehaviour
        {
            DestroyAllChildren<T>(mono.transform);
        }

        public static void CopyDataFrom(this Transform transform, Transform source, bool copyScale = false)
        {
            transform.SetPositionAndRotation(source.position, source.rotation);
            if (copyScale) transform.localScale = source.localScale;
        }
    }
}
