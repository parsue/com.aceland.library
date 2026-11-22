using System;
using System.IO;
using AceLand.Library.ProjectSetting;
#if UNITY_6000_5_OR_NEWER
using Unity.Scripting.LifecycleManagement;
#endif
using UnityEngine;

namespace AceLand.Library
{
    internal static class Bootstrapper
    {
#if UNITY_6000_5_OR_NEWER
        [AutoStaticsCleanup]
#endif
        public static AceLandProjectSettings Settings { get; private set; }

#if UNITY_6000_5_OR_NEWER
        [AutoStaticsCleanup]
#endif
        private  static bool _initializing;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Initialize()
        {
            if (_initializing || Settings != null) return;
            
            _initializing = true;
            
            Settings ??= Resources.Load<AceLandProjectSettings>(nameof(AceLandProjectSettings));

            if (Settings == null)
                throw new InvalidOperationException(
                    $"'{nameof(AceLandProjectSettings)}' not found in any Resources folder.");

            Settings.SetSystemRoot();
            Directory.CreateDirectory(Settings.SystemRootPath);
            Directory.CreateDirectory(Settings.TempRootPath);

            _initializing = false;
            Debug.Log("AceLand Library: Project Settings Initialized.");
        }
    }
}