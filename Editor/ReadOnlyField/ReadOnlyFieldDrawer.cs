using AceLand.Library.Attribute;
using UnityEditor;
using UnityEngine;

namespace AceLand.Library.Editor.ReadOnlyField
{
    [CustomPropertyDrawer(typeof(ReadOnlyFieldAttribute))]
    public class ReadOnlyFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Disable GUI to make the field read-only
            GUI.enabled = false;

            // Draw the property as usual
            EditorGUI.PropertyField(position, property, label);

            // Re-enable GUI to return to normal behavior
            GUI.enabled = true;
        }
    }
}