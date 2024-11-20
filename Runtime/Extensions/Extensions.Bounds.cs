using UnityEngine;
using Random = System.Random;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly Random Rnd = new();

        public static Vector3 RandomPoint(this Bounds bounds)
        {
            Vector3 point = new(bounds.min.x - 10, bounds.min.y - 10, bounds.min.z -10);
            while (!bounds.Contains(point))
            {
                point.x = ((float)Rnd.NextDouble()).Remap(0f, 1f, bounds.min.x, bounds.max.x);
                point.y = ((float)Rnd.NextDouble()).Remap(0f, 1f, bounds.min.y, bounds.max.y);
                point.z = ((float)Rnd.NextDouble()).Remap(0f, 1f, bounds.min.z, bounds.max.z);
            }
            return point;
        }
    }
}
