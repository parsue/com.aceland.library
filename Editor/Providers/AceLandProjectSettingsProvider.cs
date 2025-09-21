using AceLand.Library.ProjectSetting;
using UnityEditor;
using UnityEngine.UIElements;

namespace AceLand.Library.Editor.Providers
{
    public class AceLandProjectSettingsProvider : AceLandSettingsProvider
    {
        public const string SETTINGS_NAME = "Project/AceLand Packages";
        
        private AceLandProjectSettingsProvider(string path, SettingsScope scope = SettingsScope.User) 
            : base(path, scope) { }
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            Settings = AceLandProjectSettings.GetSerializedSettings();
            var s = Settings.targetObject as AceLandProjectSettings;
            s?.OnValidate();
        }

        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new AceLandProjectSettingsProvider(SETTINGS_NAME, SettingsScope.Project);
            
            return provider;
        }
    }
}