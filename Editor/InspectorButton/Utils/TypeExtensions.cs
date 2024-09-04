namespace AceLand.Library.Editor.InspectorButton.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using UnityEngine;

    public static class TypeExtensions
    {
        private static readonly HashSet<Type> _unitySerializablePrimitiveTypes = new HashSet<Type>
        {
            typeof(bool), typeof(byte), typeof(sbyte), typeof(char), typeof(double), typeof(float), typeof(int),
            typeof(uint), typeof(long), typeof(ulong), typeof(short), typeof(ushort), typeof(string),
        };

        private static readonly HashSet<Type> _unitySerializableBuiltinTypes = new HashSet<Type>
        {
            typeof(Vector2), typeof(Vector3), typeof(Vector4), typeof(Rect), typeof(Quaternion), typeof(Matrix4x4),
            typeof(Color), typeof(Color32), typeof(LayerMask), typeof(AnimationCurve), typeof(Gradient),
            typeof(RectOffset), typeof(GUIStyle)
        };

        public static bool IsUnitySerializable(this Type type)
        {
            bool _IsSystemType(Type typeToCheck) => typeToCheck.Namespace?.StartsWith("System") == true;

            bool _IsCustomSerializableType(Type typeToCheck) =>
                typeToCheck.IsSerializable && typeToCheck.GetSerializedFields().Any() &&
                !_IsSystemType(typeToCheck);

            if (type.IsAbstract) // static classes and interfaces are considered abstract too.
                return false;

            if (_IsCustomSerializableType(type))
                return true;

            if (type.InheritsFrom(typeof(UnityEngine.Object)) && !type.IsGenericTypeDefinition)
                return true;

            if (type.IsEnum)
                return true;

            return _unitySerializablePrimitiveTypes.Contains(type) || _unitySerializableBuiltinTypes.Contains(type);
        }

        private static IEnumerable<FieldInfo> GetSerializedFields(this Type type)
        {
            const BindingFlags _instanceFilter = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var _instanceFields = type.GetFields(_instanceFilter);
            return _instanceFields.Where(field => field.IsPublic || field.GetCustomAttribute<SerializeField>() != null);
        }

        private static bool IsSubclassOfRawGeneric(this Type typeToCheck, Type generic)
        {
            while (typeToCheck != null && typeToCheck != typeof(object))
            {
                Type _ = typeToCheck.IsGenericType ? typeToCheck.GetGenericTypeDefinition() : typeToCheck;

                if (generic == _)
                    return true;

                typeToCheck = typeToCheck.BaseType;
            }

            return false;
        }

        private static bool InheritsFrom(this Type typeToCheck, Type baseType)
        {
            bool _subClassOfRawGeneric = false;
            if (baseType.IsGenericType)
                _subClassOfRawGeneric = typeToCheck.IsSubclassOfRawGeneric(baseType);

            return baseType.IsAssignableFrom(typeToCheck) || _subClassOfRawGeneric;
        }
    }
}
