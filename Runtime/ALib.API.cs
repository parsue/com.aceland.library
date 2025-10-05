using Newtonsoft.Json;

namespace AceLand.Library
{
    public static partial class ALib
    {
        public static string SystemRootPath => ProjectSettings.SystemRootPath;
        public static string TempRootPath => ProjectSettings.TempRootPath;


        public static JsonSerializerSettings JsonSerializerSettings { get; } = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Converters = converters,
        };

        public static JsonSerializerSettings JsonSerializerSettingsWithType { get; } = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Converters = converters,
        };
    }
}