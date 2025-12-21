using System.IO;
using AceLand.Library.ProjectSetting;
using UnityEngine;

namespace AceLand.Library
{
    public static partial class ALib
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

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Initialize()
        {
            ProjectSettings.SetSystemRoot();
            Directory.CreateDirectory(SystemRootPath);
            Directory.CreateDirectory(TempRootPath);
        }
    }
}