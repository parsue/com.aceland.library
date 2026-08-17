using System;
using System.IO;
using AceLand.Library.ProjectSetting;
using AceLand.Lifecycle;
using UnityEngine;

namespace AceLand.Library.Modules
{
    [LifecycleModule(ModulePhase.Runtime, Order = -5000)]
    internal sealed class ALibSettingsModule : ModuleBase
    {
        internal AceLandProjectSettings Settings { get; private set; }

        private bool initializing;

        public override void Initialize()
        {
            if (initializing || Settings != null) return;
            
            initializing = true;
            
            Settings ??= Resources.Load<AceLandProjectSettings>(nameof(AceLandProjectSettings));

            if (Settings == null)
                throw new InvalidOperationException(
                    $"'{nameof(AceLandProjectSettings)}' not found in any Resources folder.");

            Settings.SetSystemRoot();
            Directory.CreateDirectory(Settings.SystemRootPath);
            Directory.CreateDirectory(Settings.TempRootPath);

            initializing = false;
            Debug.Log("AceLand Library: Project Settings Initialized.");
        }

        public override void Shutdown()
        {
            Settings = null;
        }
    }
}