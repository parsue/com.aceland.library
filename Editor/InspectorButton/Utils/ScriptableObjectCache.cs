using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Assertions;

namespace AceLand.Library.Editor.InspectorButton.Utils
{
    internal static class ScriptableObjectCache
    {
        private const string ASSEMBLY_NAME = "EasyButtons.DynamicAssembly";

        private static readonly AssemblyBuilder AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
            new AssemblyName(ASSEMBLY_NAME)
        {
            CultureInfo = CultureInfo.InvariantCulture,
            Flags = AssemblyNameFlags.None,
            ProcessorArchitecture = ProcessorArchitecture.MSIL,
            VersionCompatibility = AssemblyVersionCompatibility.SameDomain
        }, AssemblyBuilderAccess.Run);

        private static readonly ModuleBuilder ModuleBuilder = AssemblyBuilder.DefineDynamicModule(ASSEMBLY_NAME, true);

        private static readonly Dictionary<string, Type> ClassDict = new Dictionary<string, Type>();

        public static Type GetClass(string fieldName, Type fieldType)
        {
            var className = GetClassName(fieldName, fieldType);

            if (ClassDict.TryGetValue(className, out var classType))
                return classType;

            if ( ! fieldType.IsUnitySerializable())
            {
                fieldType = typeof(NonSerializedError);
            }

            classType = CreateClass(className, fieldName, fieldType);
            ClassDict[className] = classType;
            return classType;
        }

        private static Type CreateClass(string className, string fieldName, Type fieldType)
        {
            var typeBuilder = ModuleBuilder.DefineType(
                $"{ASSEMBLY_NAME}.{className}",
                TypeAttributes.NotPublic,
                typeof(ScriptableObject));

            typeBuilder.DefineField(fieldName, fieldType, FieldAttributes.Public);
            var type = typeBuilder.CreateType();
            return type;
        }

        private static string GetClassName(string fieldName, Type fieldType)
        {
            var fullTypeName = fieldType.FullName;

            Assert.IsNotNull(fullTypeName);

            var classSafeTypeName = fullTypeName
                .Replace('.', '_')
                .Replace('`', '_');

            return $"{classSafeTypeName}_{fieldName}".CapitalizeFirstChar();
        }
    }
}