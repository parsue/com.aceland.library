using System;
using AceLand.Library.Attribute;
using UnityEditor;
using UnityEngine;

namespace AceLand.Library.Editor.Drawer
{
    [CustomPropertyDrawer(typeof(HintBoxAttribute))]
    public class HintBoxDrawer : PropertyDrawer
    {
        private const float SPACING = 2f;
        private const float ICON_WIDTH = 20f;
        private const float SIDE_PADDING = 8f;

        private float _cachedWidth = -1f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var fieldHeight = EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
            return fieldHeight + SPACING + GetHintHeight();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attr = (HintBoxAttribute)attribute;

            if (!Mathf.Approximately(_cachedWidth, position.width))                                                                                                                    
            {
                _cachedWidth = position.width;
                if (Event.current.type == EventType.Layout)
                    EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            var fieldHeight = EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
            var hintHeight = GetHintHeight();

            Rect hintRect, fieldRect;
            switch (attr.Position)
            {
                case HintBoxPosition.BeforeTheField:
                    hintRect  = new Rect(position.x, position.y, position.width, hintHeight);
                    fieldRect = new Rect(position.x, hintRect.yMax + SPACING, position.width, fieldHeight);
                    break;

                case HintBoxPosition.AfterTheField:
                    fieldRect = new Rect(position.x, position.y, position.width, fieldHeight);
                    hintRect  = new Rect(position.x, fieldRect.yMax + SPACING, position.width, hintHeight);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            EditorGUI.HelpBox(EditorGUI.IndentedRect(hintRect), attr.Hint, (UnityEditor.MessageType)attr.MessageType);
            EditorGUI.PropertyField(fieldRect, property, label, includeChildren: true);
        }

        private float GetHintHeight()
        {
            var attr = (HintBoxAttribute)attribute;

            var width = _cachedWidth > 0f ? _cachedWidth : EditorGUIUtility.currentViewWidth - 40f;
            var textWidth = Mathf.Max(40f, width - ICON_WIDTH - SIDE_PADDING);

            var height = EditorStyles.helpBox.CalcHeight(new GUIContent(attr.Hint), textWidth);

            var min = attr.MessageType == Attribute.MessageType.None
                ? EditorGUIUtility.singleLineHeight
                : EditorGUIUtility.singleLineHeight * 2f;

            return Mathf.Max(height, min);
        }
    }
}