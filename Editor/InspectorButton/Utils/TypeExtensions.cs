using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace AceLand.Library.Editor.InspectorButton.Utils
{
    public static class TypeExtensions
    {
        private static readonly HashSet<Type> UnitySerializablePrimitiveTypes = new HashSet<Type>
        {
            typeof(bool), typeof(byte), typeof(sbyte), typeof(char), typeof(double), typeof(float), typeof(int),
            typeof(uint), typeof(long), typeof(ulong), typeof(short), typeof(ushort), typeof(string),
        };

        private static readonly HashSet<Type> UnitySerializableBuiltinTypes = new HashSet<Type>
        {
            typeof(Vector2), typeof(Vector3), typeof(Vector4), typeof(Rect), typeof(Quaternion), typeof(Matrix4x4),
            typeof(Color), typeof(Color32), typeof(LayerMask), typeof(AnimationCurve), typeof(Gradient),
            typeof(RectOffset), typeof(GUIStyle)
        };

        public static bool IsUnitySerializable(this Type type)
        {
            if (type.IsAbstract) // static classes and interfaces are considered abstract too.
                return false;

            if (IsCustomSerializableType(type))
                return true;

            if (type.InheritsFrom(typeof(UnityEngine.Object)) && !type.IsGenericTypeDefinition)
                return true;

            if (type.IsEnum)
                return true;

            return UnitySerializablePrimitiveTypes.Contains(type) || UnitySerializableBuiltinTypes.Contains(type);

            bool IsCustomSerializableType(Type typeToCheck) =>
                typeToCheck.IsSerializable && typeToCheck.GetSerializedFields().Any() &&
                !IsSystemType(typeToCheck);

            bool IsSystemType(Type typeToCheck) => typeToCheck.Namespace?.StartsWith("System") == true;
        }

        private static IEnumerable<FieldInfo> GetSerializedFields(this Type type)
        {
            const BindingFlags instanceFilter = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var instanceFields = type.GetFields(instanceFilter);
            return instanceFields.Where(field => field.IsPublic || field.GetCustomAttribute<SerializeField>() != null);
        }

        private static bool IsSubclassOfRawGeneric(this Type typeToCheck, Type generic)
        {
            while (typeToCheck != null && typeToCheck != typeof(object))
            {
                var _ = typeToCheck.IsGenericType ? typeToCheck.GetGenericTypeDefinition() : typeToCheck;

                if (generic == _)
                    return true;

                typeToCheck = typeToCheck.BaseType;
            }

            return false;
        }

        private static bool InheritsFrom(this Type typeToCheck, Type baseType)
        {
            var subClassOfRawGeneric = false;
            if (baseType.IsGenericType)
                subClassOfRawGeneric = typeToCheck.IsSubclassOfRawGeneric(baseType);

            return baseType.IsAssignableFrom(typeToCheck) || subClassOfRawGeneric;
        }
    }
}
