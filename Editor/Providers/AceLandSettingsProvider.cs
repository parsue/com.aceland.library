using UnityEditor;
using UnityEngine.UIElements;

namespace AceLand.Library.Editor.Providers
{
    public abstract class AceLandSettingsProvider : SettingsProvider
    {
        protected internal AceLandSettingsProvider(string path, SettingsScope scope = SettingsScope.User) 
            : base(path, scope) { }
        
        protected SerializedObject Settings;
        
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            Undo.undoRedoPerformed += OnUndoRedoPerformed;
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
        }

        public override void OnGUI(string searchContext)
        {
            EditorGUI.BeginChangeCheck();
            
            EditorHelper.DrawAllProperties(Settings);
            EditorGUILayout.Space(20f);
            
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(Settings.targetObject, "Apply Changes");
                Settings.ApplyModifiedProperties();
            }
            else
            {
                Settings.ApplyModifiedPropertiesWithoutUndo();
            }
        }
        
        private void OnUndoRedoPerformed()
        {
            // Refresh the serialized object when undo/redo is performed
            Settings.Update();
            // Optionally, you can also force a repaint if needed
            EditorUtility.SetDirty(Settings.targetObject);
        }
    }
}