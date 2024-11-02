using UnityEngine;
using System;

namespace AceLand.Library.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
        AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public sealed class ConditionalShowAttribute : PropertyAttribute
    {
        public delegate bool ShowCondition();

        public readonly string FieldName;
        public readonly string[] FieldNames;
        public readonly int[] EnumIndex;
        public readonly bool BoolValue;
        public readonly bool IsFlag;
        public readonly bool IsValidator;
        public readonly Func<bool> Validator;

        public ConditionalShowAttribute(params string[] boolVariableNames)
        {
            FieldName = string.Empty;
            FieldNames = boolVariableNames;
            BoolValue = true;
            IsFlag = false;
            IsValidator = false;
            Validator = null;
        }

        public ConditionalShowAttribute(Func<bool> validator)
        {
            FieldName = string.Empty;
            FieldNames = null;
            IsFlag = false;
            IsValidator = true;
            Validator = validator;
        }

        public ConditionalShowAttribute(string boolVariableName, bool boolValue = true)
        {
            FieldName = boolVariableName;
            FieldNames = null;
            BoolValue = boolValue;
            IsFlag = false;
            IsValidator = false;
            Validator = null;
        }

        public ConditionalShowAttribute(string enumVariableName, params object[] enumValues)
        {
            foreach (var t in enumValues)
                if (!t.GetType().IsEnum) return;

            FieldName = enumVariableName;
            FieldNames = null;
            IsFlag = false;
            IsValidator = false;
            Validator = null;

            EnumIndex = new int[enumValues.Length];
            for (var i = 0; i < enumValues.Length; i++)
                EnumIndex[i] = Array.IndexOf(Enum.GetValues(enumValues[i].GetType()), enumValues[i]);
        }

        public ConditionalShowAttribute(string enumVariableName, params int[] enumIndex)
        {
            FieldName = enumVariableName;
            FieldNames = null;
            EnumIndex = enumIndex;
            IsFlag = false;
            IsValidator = false;
            Validator = null;
        }

        public ConditionalShowAttribute(string enumVariableName, bool isFlag, params object[] enumValues)
        {
            foreach (var t in enumValues)
                if (!t.GetType().IsEnum) return;

            FieldName = enumVariableName;
            FieldNames = null;
            IsFlag = isFlag;
            IsValidator = false;
            Validator = null;

            EnumIndex = new int[enumValues.Length];
            for (var i = 0; i < enumValues.Length; i++)
                EnumIndex[i] = Array.IndexOf(Enum.GetValues(enumValues[i].GetType()), enumValues[i]);
        }

        public ConditionalShowAttribute(string enumVariableName, bool isFlag, params int[] enumIndexes)
        {
            FieldName = enumVariableName;
            FieldNames = null;
            EnumIndex = enumIndexes;
            IsFlag = isFlag;
            IsValidator = false;
            Validator = null;
        }
    }
}
