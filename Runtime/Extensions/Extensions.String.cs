using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        public static string ToFullPath(this string filename)
            => Path.Combine(Application.persistentDataPath, filename);

        public static async Task SaveToFile(this string data, string fileFullPathName)
        {
            if (data.IsNullOrEmptyOrWhiteSpace()) return;

            if (!File.Exists(fileFullPathName))
                await File.Create(fileFullPathName).DisposeAsync();

            await File.WriteAllTextAsync(fileFullPathName, data);
        }

        public static async Task<string> LoadFromFile(this string fileFullPathName)
        {
            return !File.Exists(fileFullPathName) 
                ? string.Empty 
                : await File.ReadAllTextAsync(fileFullPathName);
        }
    }
}
