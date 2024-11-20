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
            var sourceBoolProperty = property.serializedObject.FindProperty(baseAttr.BoolFieldName);
            var sourceEnumProperty = property.serializedObject.FindProperty(baseAttr.EnumFieldName);

            if (sourceBoolProperty is not null && sourceEnumProperty is not null)
            {
                return CheckBoolPropertyType(baseAttr, sourceBoolProperty) &&
                       CheckEnumPropertyType(baseAttr, sourceEnumProperty);
            }

            if (sourceBoolProperty is not null || sourceEnumProperty is not null)
            {
                return CheckBoolPropertyType(baseAttr, sourceBoolProperty) ||
                       CheckEnumPropertyType(baseAttr, sourceEnumProperty);
            }
            
            if (baseAttr.BoolFieldNames == null || baseAttr.BoolFieldNames.Length == 0) return false;
                
            foreach (var fieldName in baseAttr.BoolFieldNames)
            {
                sourceBoolProperty = property.serializedObject.FindProperty(fieldName);
                if (sourceBoolProperty is null) return false;
                if (!CheckBoolPropertyType(baseAttr, sourceBoolProperty)) return false;
            }

            return true;

        }

        private bool CheckBoolPropertyType(ConditionalShowAttribute condHAtt, SerializedProperty boolProperty)
        {
            if (boolProperty?.propertyType is not SerializedPropertyType.Boolean) return false;
            
            return boolProperty.boolValue == condHAtt.BoolValue;
        }
        
        private bool CheckEnumPropertyType(ConditionalShowAttribute condHAtt, SerializedProperty enumProperty)
        {
            if (enumProperty?.propertyType is not SerializedPropertyType.Enum) return false;
            if (condHAtt.EnumIndex == null) return true;
            
            foreach (var index in condHAtt.EnumIndex)
            {
                if (condHAtt.IsFlag)
                {
                    if ((enumProperty.enumValueIndex & index) == 1)
                        return true;
                }
                else
                {
                    if (enumProperty.enumValueIndex == index)
                        return true;
                }
            }
            
            return false;
        }
    }
}
