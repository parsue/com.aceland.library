namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        public static async Task SaveToFile(this string data, string filename)
        {
            if (data.IsNullOrEmptyOrWhiteSpace()) return;

            var filePath = Path.Combine(Application.persistentDataPath, filename);

            if (!File.Exists(filePath))
                await File.Create(filePath).DisposeAsync();

            await File.WriteAllTextAsync(filePath, data);
        }

        public static async Task<string> LoadFromFile(this string filename)
        {
            var filePath = Path.Combine(Application.persistentDataPath, filename);
            return !File.Exists(filePath) ? string.Empty : await File.ReadAllTextAsync(filePath);
        }
    }
}
