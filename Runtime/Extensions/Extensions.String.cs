using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        public static async Task SaveToFile(this string data, string fullFilePathName,
            CancellationToken token)
        {
            if (data.IsNullOrEmptyOrWhiteSpace()) return;

            if (!File.Exists(fullFilePathName))
                await File.Create(fullFilePathName).DisposeAsync();

            await File.WriteAllTextAsync(fullFilePathName, data, token);
        }

        public static async Task<string> LoadFromFile(this string fullFilePathName, CancellationToken token)
        {
            return !File.Exists(fullFilePathName) 
                ? string.Empty 
                : await File.ReadAllTextAsync(fullFilePathName, token);
        }
    }
}
