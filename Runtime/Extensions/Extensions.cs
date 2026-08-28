using Unity.Mathematics;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly System.Random Rnd = new();
        private static readonly float3 DesaturationValue = new(0.2126f, 0.7152f, 0.0722f);
    }
}
