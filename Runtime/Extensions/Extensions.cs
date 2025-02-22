using Random = System.Random;
using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly Random Rnd = new();
        private static readonly Vector3 DesatuationValue = new(0.2126f, 0.7152f, 0.0722f);
    }
}
