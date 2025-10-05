using AceLand.Library.Utils;
using Newtonsoft.Json;

namespace AceLand.Library
{
    public static partial class ALib
    {
        public static Helper Helper
        {
            get
            {
                _helper ??= new Helper();
                return _helper;
            }
        }
        private static Helper _helper;
        
        public static Platform Platform
        {
            get
            {
                _platform ??= new Platform();
                return _platform;
            }
        }
        private static Platform _platform;

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