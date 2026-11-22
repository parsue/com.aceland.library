#nullable enable
using System;
#if UNITY_6000_5_OR_NEWER
using Unity.Scripting.LifecycleManagement;
#endif

namespace AceLand.Library.Utils
{
#if UNITY_6000_5_OR_NEWER
    public sealed partial class GlobalPath : IDisposable
#else
    public sealed class GlobalPath : IDisposable
#endif
    {
        public static GlobalPath Get()
        {
            _instance ??= new GlobalPath();
            return _instance;
        }
        
#if UNITY_6000_5_OR_NEWER
        [AutoStaticsCleanup]
#endif
        private static GlobalPath? _instance;

        private GlobalPath()
        {
            var settings = Bootstrapper.Settings;
            SystemPath = settings.SystemRootPath;
            TempPath = settings.TempRootPath;
        }
        
        ~GlobalPath() => Dispose();

        public void Dispose()
        {
            _instance = null;
            SystemPath = null;
            TempPath = null;
        }

        public string? SystemPath { get; private set; }
        public string? TempPath { get; private set; }
    }
}