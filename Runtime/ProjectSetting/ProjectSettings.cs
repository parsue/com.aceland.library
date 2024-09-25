using System.IO;
using UnityEditor;
using UnityEngine;

namespace AceLand.Library.ProjectSetting
{
    public abstract class ProjectSettings<T> : ScriptableObject
        where T : ScriptableObject
    {
        private const string PATH = "Assets/Resources";

#if UNITY_EDITOR
        private static T GetOrCreateSettings()
        {
            var settingName = typeof(T).Name;
            var fullPath = PATH + "/" + settingName + ".asset";
            var settings = AssetDatabase.LoadAssetAtPath<T>(fullPath);
            if (settings != null) return settings;
            
            if (!Directory.Exists(PATH)) Directory.CreateDirectory(PATH);
            
            settings = CreateInstance<T>();
            AssetDatabase.CreateAsset(settings, fullPath);
            AssetDatabase.SaveAssets();
            
            return settings;
        }
        
        public static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
#endif
    }
}