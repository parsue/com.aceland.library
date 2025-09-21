using System.IO;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.Library
{
    public static class ALib
    {
        internal static AceLandProjectSettings ProjectSettings
        {
            get
            {
                _projectSettings ??= Resources.Load<AceLandProjectSettings>(nameof(AceLandProjectSettings));
                return _projectSettings;
            }
        }
        private static AceLandProjectSettings _projectSettings;
        
        public static string SystemRootPath => ProjectSettings.SystemRootPath;
        public static string TempRootPath => ProjectSettings.TempRootPath;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Initialize()
        {
            Directory.CreateDirectory(SystemRootPath);
            Directory.CreateDirectory(TempRootPath);
        }
    }
}