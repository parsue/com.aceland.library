using UnityEngine;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {      
        public static GameObject CreateEmptyInHierarchy(string name, Transform parent = null)
        {
            return new GameObject()
            {
                name = name,
                transform =
                {
                    parent = parent,
                    position = Vector3.zero,
                    rotation = Quaternion.identity,
                    localScale = Vector3.one,
                }
            };
        }
    }
}