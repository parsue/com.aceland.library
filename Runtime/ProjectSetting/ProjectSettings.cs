using System.IO;
using UnityEngine;

namespace AceLand.Library.ProjectSetting
{
    public abstract class ProjectSettings<T> : ScriptableObject
        where T : ScriptableObject
    {
        private const string Path = "Assets/Resources";

#if UNITY_EDITOR
        private static T GetOrCreateSettings()
        {
            var settingName = typeof(T).Name;
            var fullPath = Path + "/" + settingName + ".asset";
            var settings = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(fullPath);
            if (settings != null) return settings;
            
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
            
            settings = CreateInstance<T>();
            UnityEditor.AssetDatabase.CreateAsset(settings, fullPath);
            UnityEditor.AssetDatabase.SaveAssets();
            
            return settings;
        }
        
        public static UnityEditor.SerializedObject GetSerializedSettings()
        {
            return new(GetOrCreateSettings());
        }
#endif
    }
}