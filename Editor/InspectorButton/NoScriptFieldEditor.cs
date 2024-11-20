using System.Reflection;
using UnityEngine;

namespace AceLand.Library.Editor.InspectorButton
{
    internal class NoScriptFieldEditor : UnityEditor.Editor
    {
        private static readonly MethodInfo RemoveLogEntriesByMode;
        private static readonly string[] PropertiesToExclude = { "m_Script" };

        static NoScriptFieldEditor()
        {
            const string logEntryClassName = "UnityEditor.LogEntry";
            const string removeLogMethodName = "RemoveLogEntriesByMode";

            var editorAssembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var logEntryType = editorAssembly.GetType(logEntryClassName);
            RemoveLogEntriesByMode = logEntryType.GetMethod(removeLogMethodName, BindingFlags.NonPublic | BindingFlags.Static);

            if (RemoveLogEntriesByMode == null)
                Debug.LogError($"Could not find the {logEntryClassName}.{removeLogMethodName}() method. ");
        }

        public override void OnInspectorGUI()
        {
            DrawPropertiesExcluding(serializedObject, PropertiesToExclude);
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
            RemoveLogEntriesByMode?.Invoke(null, new object[] { noScriptAssetMode });
        }
    }
}
