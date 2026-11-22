#nullable enable
using System;
#if UNITY_6000_5_OR_NEWER
using Unity.Scripting.LifecycleManagement;
#endif

namespace AceLand.Library.Utils
{
    public sealed partial class ALibHelper : IDisposable
    {
        public static ALibHelper Get()
        {
            _instance ??= new ALibHelper();
            return _instance;
        }
        
#if UNITY_6000_5_OR_NEWER
        [AutoStaticsCleanup]
#endif
        private static ALibHelper? _instance;
        
        private ALibHelper() {}
        ~ALibHelper() => Dispose();

        public void Dispose()
        {
            _instance = null;
        }
    }
}