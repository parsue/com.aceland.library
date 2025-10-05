using UnityEngine;

namespace AceLand.Library.Utils
{
    public partial class Helper
    {      
        public GameObject CreateEmptyInHierarchy(string name, Transform parent = null) =>
            new()
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