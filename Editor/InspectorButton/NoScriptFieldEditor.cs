namespace AceLand.Library.Editor.InspectorButton
{
    using System;
    using System.Reflection;
    using UnityEditor;
    using UnityEngine;

    internal class NoScriptFieldEditor : Editor
    {
        private static readonly MethodInfo _removeLogEntriesByMode;
        private static readonly string[] _propertiesToExclude = { "m_Script" };

        static NoScriptFieldEditor()
        {
            const string logEntryClassName = "UnityEditor.LogEntry";
            const string removeLogMethodName = "RemoveLogEntriesByMode";

            var _editorAssembly = Assembly.GetAssembly(typeof(Editor));
            Type logEntryType = _editorAssembly.GetType(logEntryClassName);
            _removeLogEntriesByMode = logEntryType.GetMethod(removeLogMethodName, BindingFlags.NonPublic | BindingFlags.Static);

            if (_removeLogEntriesByMode == null)
                Debug.LogError($"Could not find the {logEntryClassName}.{removeLogMethodName}() method. ");
        }

        public override void OnInspectorGUI()
        {
            DrawPropertiesExcluding(serializedObject, _propertiesToExclude);
        }

        public void ApplyModifiedProperties()
        {
            if (!serializedObject.hasModifiedProperties)
                return;

            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            RemoveNoScriptWarning();
        }

        private static void RemoveNoScriptWarning()
        {
            if (!Application.isPlaying)
                return;

            const int noScriptAssetMode = 262144;
            _removeLogEntriesByMode?.Invoke(null, new object[] { noScriptAssetMode });
        }
    }
}
