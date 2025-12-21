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
    }
}