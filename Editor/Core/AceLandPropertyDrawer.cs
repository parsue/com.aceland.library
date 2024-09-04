using UnityEditor;
using UnityEngine;

namespace AceLand.Editor.Core
{
    public class AceLandPropertyDrawer : PropertyDrawer
    {
        private const float SUB_LABEL_SPACING = 4;
        protected const float BOTTOM_SPACING = 2;
        private const bool FIX_LINE_HEIGHT = false;
        private const float LINE_HEIGHT = 0f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return FIX_LINE_HEIGHT ? LINE_HEIGHT : EditorGUI.GetPropertyHeight(property, label, true) + BOTTOM_SPACING;
        }

        protected internal void DrawIconLabel(string name)
        {
            var content = EditorGUIUtility.IconContent(name);
            GUILayout.Label(content);
        }

        protected void DrawMultiplePropertyFields(Rect pos, SerializedProperty[] props, GUIContent[] subLabels)
        {
            var indent = EditorGUI.indentLevel;
            var labelWidth = EditorGUIUtility.labelWidth;

            var propsCount = props.Length;
            var width = (pos.width - (propsCount - 1) * SUB_LABEL_SPACING) / propsCount;
            var contentPos = new Rect(pos.x, pos.y, width, pos.height);
            EditorGUI.indentLevel = 0;
            for (var i = 0; i < propsCount; i++)
            {
                EditorGUIUtility.labelWidth = EditorStyles.label.CalcSize(subLabels[i]).x;
                EditorGUI.PropertyField(contentPos, props[i], subLabels[i]);
                contentPos.x += width + SUB_LABEL_SPACING;
            }

            EditorGUIUtility.labelWidth = labelWidth;
            EditorGUI.indentLevel = indent;
        }
    }
}
