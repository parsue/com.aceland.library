using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceLand.Library.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
        AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public sealed class ConditionalShowAttribute : PropertyAttribute
    {
        public string BoolFieldName;
        public string EnumFieldName;
        public string[] BoolFieldNames;
        public int[] EnumIndex;
        public bool BoolValue;
        public bool IsFlag;

        public ConditionalShowAttribute(string boolVariableName, bool boolValue = true)
        {
            SetBoolWithValue(boolVariableName, boolValue);
        }

        public ConditionalShowAttribute(params string[] boolVariableNames)
        {
            SetBools(boolVariableNames);
        }

        public ConditionalShowAttribute(string enumVariableName, params object[] enumValues)
        {
            SetEnums(enumVariableName, enumValues);
        }

        public ConditionalShowAttribute(string enumVariableName,
            bool invert, params object[] enumValues)
        {
            SetInvertEnums(enumVariableName, invert, enumValues);
        }

        public ConditionalShowAttribute(string boolVariableName, string enumVariableName,
            params object[] enumValues)
        {
            SetBoolWithValue(boolVariableName, true);
            SetEnums(enumVariableName, enumValues);
        }

        public ConditionalShowAttribute(string boolVariableName, string enumVariableName,
            bool invert, params object[] enumValues)
        {
            SetBoolWithValue(boolVariableName, true);
            SetInvertEnums(enumVariableName, invert, enumValues);
        }
        
        
        
        

        private void SetBoolWithValue(string boolVariableName, bool boolValue)
        {
            BoolFieldName = boolVariableName;
            BoolValue = boolValue;
        }

        private void SetBools(string[] boolVariableNames)
        {
            BoolFieldName = string.Empty;
            BoolFieldNames = boolVariableNames;
            BoolValue = true;
        }

        private void SetEnums(string enumVariableName, object[] enumValues)
        {
            if (enumValues.Length == 0) return;

            Type type = null;
            
            foreach (var t in enumValues)
            {
                var valueType = t.GetType();
                if (type == null) type = valueType;
                else if (type != valueType) return;
                if (!type.IsEnum) return;
            }

            if (type == null) return;

            EnumFieldName = enumVariableName;
            IsFlag = IsDefined(type, typeof(FlagsAttribute));

            EnumIndex = new int[enumValues.Length];
            for (var i = 0; i < enumValues.Length; i++)
                EnumIndex[i] = Array.IndexOf(Enum.GetValues(enumValues[i].GetType()), enumValues[i]);
        }

        private void SetInvertEnums(string enumVariableName, bool invert, object[] enumValues)
        {
            if (enumValues.Length == 0) return;

            Type type = null;
            
            foreach (var t in enumValues)
            {
                var valueType = t.GetType();
                if (type == null) type = valueType;
                else if (type != valueType) return;
                if (!type.IsEnum) return;
            }

            if (type == null) return;

            EnumFieldName = enumVariableName;
            IsFlag = IsDefined(type, typeof(FlagsAttribute));

            var allValues = Enum.GetValues(type);
            var enums = new List<int>();
            if (!invert)
            {
                foreach (var e in enumValues)
                    enums.Add(Array.IndexOf(Enum.GetValues(e.GetType()), e));
            }
            else
            {
                foreach (var e in allValues)
                {
                    if (enumValues.Contains(e)) continue;
                    enums.Add(Array.IndexOf(Enum.GetValues(e.GetType()), e));
                }
            }

            EnumIndex = enums.ToArray();
        }
    }
}
