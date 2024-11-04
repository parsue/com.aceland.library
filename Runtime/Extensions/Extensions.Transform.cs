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
                if (Application.isPlaying) Object.Destroy(child);
                else Object.DestroyImmediate(child);
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
            {
                var tr = (Transform)child;
                if (tr.TryGetComponent<T>(out var mono)) list.Add(mono);
            }

            foreach (var item in list)
            {
                if (Application.isPlaying) Object.Destroy(item);
                else Object.DestroyImmediate(item);
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
