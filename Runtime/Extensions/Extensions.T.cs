using System.IO;
using AceLand.Library.Utils;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static T DeepClone<T>(this T deepCloneObject) where T : class
        {
            using var ms = new MemoryStream();
            var formatter = Helper.GetBinaryFormatter();
            formatter.Serialize(ms, deepCloneObject);
            ms.Position = 0;

            return (T)formatter.Deserialize(ms);
        }

    }
}