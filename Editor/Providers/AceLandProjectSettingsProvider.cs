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

        private bool _enableCreateCrypto = false;
        
        private AceLandProjectSettingsProvider(string path, SettingsScope scope = SettingsScope.User) 
            : base(path, scope) { }
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            Settings = AceLandProjectSettings.GetSerializedSettings();
            _enableCreateCrypto = false;
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
            EditorGUILayout.Space(12f);
            EditorGUILayout.PropertyField(systemRoot);
            if ((SystemRoot)systemRoot.enumValueIndex is SystemRoot.Custom)
                customerSystemFolder.stringValue =  EditorGUILayout.TextField("Customer System Folder", customerSystemFolder.stringValue);
            EditorGUILayout.PropertyField(systemRootPath);
            
            EditorGUILayout.Space(12f);
            EditorGUILayout.PropertyField(tempRoot);
            if ((SystemRoot)tempRoot.enumValueIndex is SystemRoot.Custom)
                customerTempFolder.stringValue = EditorGUILayout.TextField("Custom Temp Folder", customerTempFolder.stringValue);
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.PropertyField(tempRootPath);
            
            EditorGUILayout.Space(12f);
            EditorGUILayout.LabelField("Crypto", EditorStyles.boldLabel);
            EditorGUI.BeginDisabledGroup(true);
            key.stringValue = EditorGUILayout.TextField("Key", key.stringValue);
            iv.stringValue = EditorGUILayout.TextField("IV", iv.stringValue);
            EditorGUI.EndDisabledGroup();
            
            EditorGUILayout.HelpBox(
                "Changing Crypto will make current encrypted values cannot decrypted correctly.\n\n" +
                "Check Enable Create Key to enable the Create New Key button.",
                MessageType.Warning
            );
            
            EditorGUILayout.HelpBox(
                "You can undo the change. However the undo records will be clear on this page deactivated.",
                MessageType.Info
            );
            _enableCreateCrypto = EditorGUILayout.Toggle("Enable Create Key", _enableCreateCrypto);
            
            EditorGUI.BeginDisabledGroup(!_enableCreateCrypto);
            if (GUILayout.Button("Create New Key", GUILayout.Width(200)))
            {
                Undo.RecordObject(Settings.targetObject, "Apply Changes");
                Settings.ApplyModifiedProperties();
                
                var ps = Settings.targetObject as AceLandProjectSettings;
                ps?.EditorGenNewKeys();

                key.stringValue = ps?.Key;
                iv.stringValue = ps?.IV;

                _enableCreateCrypto = false;
            }
            EditorGUI.EndDisabledGroup();
            
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