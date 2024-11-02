using System;
using AceLand.Library.Attribute;
using UnityEditor;
using UnityEngine;

namespace AceLand.Library.Editor.ConditionalShowProperty
{
    [CustomPropertyDrawer(typeof(ConditionalShowAttribute))]
    public class ConditionalShowPropertyDrawer : PropertyDrawer
    {
        private const float BOTTOM_SPACING = 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var condHAtt = (ConditionalShowAttribute)attribute;
            var enabled = GetConditionalShowAttributeResult(condHAtt, property);
            if (!enabled) return;
                EditorGUI.PropertyField(position, property, label, true);

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var baseAttr = (ConditionalShowAttribute)attribute;
            var enabled = GetConditionalShowAttributeResult(baseAttr, property);

            return enabled
                ? EditorGUI.GetPropertyHeight(property, label) + BOTTOM_SPACING
                : -EditorGUIUtility.standardVerticalSpacing + BOTTOM_SPACING;
        }

        private bool GetConditionalShowAttributeResult(ConditionalShowAttribute baseAttr, SerializedProperty property)
        {
            if (baseAttr.IsValidator && baseAttr.Validator is not null) return baseAttr.Validator.Invoke();

            var sourceProperty = property.serializedObject.FindProperty(baseAttr.FieldName);

            if (sourceProperty is not null) return CheckPropertyType(baseAttr, sourceProperty);
            
            if (baseAttr.FieldNames == null || baseAttr.FieldNames.Length == 0) return false;
                
            foreach (var fieldName in baseAttr.FieldNames)
            {
                sourceProperty = property.serializedObject.FindProperty(fieldName);
                if (sourceProperty is null) return false;
                if (!CheckPropertyType(baseAttr, sourceProperty)) return false;
            }

            return true;

        }

        private bool CheckPropertyType(ConditionalShowAttribute condHAtt, SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return property.boolValue == condHAtt.BoolValue;

                case SerializedPropertyType.Enum:
                    foreach (var index in condHAtt.EnumIndex)
                    {
                        if (condHAtt.IsFlag)
                        {
                            if ((property.enumValueIndex & index) == 1)
                                return true;
                        }
                        else
                        {
                            if (property.enumValueIndex == index)
                                return true;
                        }
                    }
                    return false;

                default:
                    throw new Exception("Data type of the property used for conditional hiding [" + property.propertyType + "] is currently not supported");
            }
        }
    }
}
