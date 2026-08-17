using System;
using AceLand.Library.Modules;
using AceLand.Lifecycle;

namespace AceLand.Library.Services
{
    public interface IALibPath
    {
        string SystemPath { get; }
        string TempPath { get; }
    }
    
    internal sealed class ALibPath : IALibPath, IDisposable
    {
        private ALibPath()
        {
            Disposable = ModuleRegistry.WhenReady<ALibSettingsModule>(m =>
            {
                SystemPath = m.Settings.SystemRootPath;
                TempPath = m.Settings.TempRootPath;
            });
        }

        public void Dispose()
        {
            Disposable?.Dispose();
            SystemPath = null;
            TempPath = null;
        }

        private IDisposable Disposable { get; }
        
        public string SystemPath { get; private set; }
        public string TempPath { get; private set; }
    }
}