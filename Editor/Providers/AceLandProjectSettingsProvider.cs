using AceLand.Library.ProjectSetting;
using AceLand.ProjectSetting.Editor;
using UnityEditor;
using UnityEngine;
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
        }

        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            var provider = new AceLandProjectSettingsProvider(SETTINGS_NAME, SettingsScope.Project);
            return provider;
        }

        public override void OnGUI(string searchContext)
        {
            SerializedProperty(
                out var separateEditorAndBuild,
                out var systemRoot,
                out var customerSystemFolder,
                out var tempRoot,
                out var customerTempFolder,
                out var systemRootPath,
                out var tempRootPath,
                out var key,
                out var iv
            );
            
            EditorGUI.BeginChangeCheck();
            
            EditorGUILayout.Space(12f);
            EditorGUILayout.LabelField("System Folders", EditorStyles.boldLabel);
            separateEditorAndBuild.boolValue =
                EditorGUILayout.Toggle("Separate Editor And Build", separateEditorAndBuild.boolValue);
            EditorGUILayout.PropertyField(systemRoot);
            if ((SystemRoot)systemRoot.enumValueIndex is SystemRoot.Custom)
                customerSystemFolder.stringValue =  EditorGUILayout.TextField("Customer System Folder", customerSystemFolder.stringValue);
            EditorGUILayout.PropertyField(tempRoot);
            if ((SystemRoot)tempRoot.enumValueIndex is SystemRoot.Custom)
                customerTempFolder.stringValue = EditorGUILayout.TextField("Custom Temp Folder", customerTempFolder.stringValue);
            EditorGUI.EndDisabledGroup();
            
            EditorGUILayout.Space(12f);
            EditorGUILayout.PropertyField(systemRootPath);
            EditorGUILayout.PropertyField(tempRootPath);
            
            EditorGUILayout.Space(12f);
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.LabelField("Crypto", EditorStyles.boldLabel);
            key.stringValue = EditorGUILayout.TextField("Key", key.stringValue);
            iv.stringValue = EditorGUILayout.TextField("IV", iv.stringValue);
            EditorGUI.EndDisabledGroup();
            
            if (GUILayout.Button("Create New Key", GUILayout.Width(200)))
            {
                Undo.RecordObject(Settings.targetObject, "Apply Changes");
                Settings.ApplyModifiedProperties();
                
                var ps = Settings.targetObject as AceLandProjectSettings;
                ps?.EditorGenNewKeys();

                key.stringValue = ps?.Key;
                iv.stringValue = ps?.IV;
            }
            
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(Settings.targetObject, "Apply Changes");
                Settings.ApplyModifiedProperties();
                
                var ps = Settings.targetObject as AceLandProjectSettings;
                ps?.EditorValidate();

                systemRootPath.stringValue = ps?.SystemRootPath ?? string.Empty;
                tempRootPath.stringValue = ps?.TempRootPath ?? string.Empty;
            }
            else
            {
                Settings.ApplyModifiedPropertiesWithoutUndo();
            }
        }

        private void SerializedProperty(
            out SerializedProperty separateEditorAndBuild,
            out SerializedProperty systemRoot,
            out SerializedProperty customerSystemFolder,
            out SerializedProperty tempRoot,
            out SerializedProperty customerTempFolder,
            out SerializedProperty systemRootPath,
            out SerializedProperty tempRootPath,
            out SerializedProperty key,
            out SerializedProperty iv
        )
        {
            separateEditorAndBuild = Settings.FindProperty("separateEditorAndBuild");
            systemRoot = Settings.FindProperty("systemRoot");
            customerSystemFolder = Settings.FindProperty("customerSystemFolder");
            tempRoot = Settings.FindProperty("tempRoot");
            customerTempFolder = Settings.FindProperty("customerTempFolder");
            systemRootPath = Settings.FindProperty("systemRootPath");
            tempRootPath = Settings.FindProperty("tempRootPath");
            key = Settings.FindProperty("key");
            iv = Settings.FindProperty("iv");
            
        }
    }
}