using System;
using AceLand.Lifecycle;

namespace AceLand.Library.Services
{
    public interface IGlobalPath
    {
        string SystemPath { get; }
        string TempPath { get; }
    }
    
    internal sealed class GlobalPath : IGlobalPath, IDisposable
    {
        private GlobalPath()
        {
            ModuleRegistry.WhenReady<ALibSettingsModule>(m =>
            {
                SystemPath = m.Settings.SystemRootPath;
                TempPath = m.Settings.TempRootPath;
            });
        }

        public void Dispose()
        {
            SystemPath = null;
            TempPath = null;
        }

        public string SystemPath { get; private set; }
        public string TempPath { get; private set; }
    }
}