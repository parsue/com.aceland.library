using UnityEngine;
using System;

namespace AceLand.Library.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
        AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public sealed class ConditionalShowAttribute : PropertyAttribute
    {
        public delegate bool ShowCondition();

        public string FieldName;
        public string[] FieldNames;
        public int[] enumIndex;
        public bool boolValue;
        public bool isFlag;

        public ConditionalShowAttribute(params string[] boolVariableNames)
        {
            FieldName = string.Empty;
            FieldNames = boolVariableNames;
            boolValue = true;
            isFlag = false;
        }

        public ConditionalShowAttribute(string boolVariableName, bool boolValue = true)
        {
            FieldName = boolVariableName;
            FieldNames = null;
            this.boolValue = boolValue;
            isFlag = false;
        }

        public ConditionalShowAttribute(string enumVariableName, params object[] enumValues)
        {
            for (int i = 0; i < enumValues.Length; i++)
                if (!enumValues[i].GetType().IsEnum) return;

            FieldName = enumVariableName;
            FieldNames = null;
            isFlag = false;

            enumIndex = new int[enumValues.Length];
            for (int i = 0; i < enumValues.Length; i++)
                enumIndex[i] = Array.IndexOf(Enum.GetValues(enumValues[i].GetType()), enumValues[i]);
        }

        public ConditionalShowAttribute(string enumVariableName, params int[] enumIndex)
        {
            FieldName = enumVariableName;
            FieldNames = null;
            this.enumIndex = enumIndex;
            isFlag = false;
        }

        public ConditionalShowAttribute(string enumVariableName, bool isFlag, params object[] enumValues)
        {
            for (int i = 0; i < enumValues.Length; i++)
                if (!enumValues[i].GetType().IsEnum) return;

            FieldName = enumVariableName;
            FieldNames = null;
            this.isFlag = isFlag;

            enumIndex = new int[enumValues.Length];
            for (int i = 0; i < enumValues.Length; i++)
                enumIndex[i] = Array.IndexOf(Enum.GetValues(enumValues[i].GetType()), enumValues[i]);
        }

        public ConditionalShowAttribute(string enumVariableName, bool isFlag, params int[] enumIndexes)
        {
            FieldName = enumVariableName;
            FieldNames = null;
            enumIndex = enumIndexes;
            this.isFlag = isFlag;
        }
    }
}
