namespace AceLand.Library.Editor.InspectorButton.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Configuration.Assemblies;
    using System.Globalization;
    using System.Reflection;
    using System.Reflection.Emit;
    using UnityEngine;
    using UnityEngine.Assertions;

    internal static class ScriptableObjectCache
    {
        private const string AssemblyName = "EasyButtons.DynamicAssembly";

        private static readonly AssemblyBuilder _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
            new AssemblyName(AssemblyName)
        {
            CultureInfo = CultureInfo.InvariantCulture,
            Flags = AssemblyNameFlags.None,
            ProcessorArchitecture = ProcessorArchitecture.MSIL,
            VersionCompatibility = AssemblyVersionCompatibility.SameDomain
        }, AssemblyBuilderAccess.Run);

        private static readonly ModuleBuilder _moduleBuilder = _assemblyBuilder.DefineDynamicModule(AssemblyName, true);

        private static readonly Dictionary<string, Type> _classDict = new Dictionary<string, Type>();

        public static Type GetClass(string fieldName, Type fieldType)
        {
            string _className = GetClassName(fieldName, fieldType);

            if (_classDict.TryGetValue(_className, out Type classType))
                return classType;

            if ( ! fieldType.IsUnitySerializable())
            {
                fieldType = typeof(NonSerializedError);
            }

            classType = CreateClass(_className, fieldName, fieldType);
            _classDict[_className] = classType;
            return classType;
        }

        private static Type CreateClass(string className, string fieldName, Type fieldType)
        {
            TypeBuilder _typeBuilder = _moduleBuilder.DefineType(
                $"{AssemblyName}.{className}",
                TypeAttributes.NotPublic,
                typeof(ScriptableObject));

            _typeBuilder.DefineField(fieldName, fieldType, FieldAttributes.Public);
            Type _type = _typeBuilder.CreateType();
            return _type;
        }

        private static string GetClassName(string fieldName, Type fieldType)
        {
            string _fullTypeName = fieldType.FullName;

            Assert.IsNotNull(_fullTypeName);

            string _classSafeTypeName = _fullTypeName
                .Replace('.', '_')
                .Replace('`', '_');

            return $"{_classSafeTypeName}_{fieldName}".CapitalizeFirstChar();
        }
    }
}