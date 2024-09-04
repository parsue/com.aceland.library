namespace AceLand.Library.Editor.InspectorButton
{
    using AceLand.Library.Attribute;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using UnityEditor;
    using UnityEngine;
    using Utils;
    using Object = UnityEngine.Object;

    internal class InspectorButtonWithParams : InspectorButton
    {
        private readonly Parameter[] _parameters;
        private bool _expanded;

        public InspectorButtonWithParams(MethodInfo method, InspectorButtonAttribute buttonAttribute, ParameterInfo[] parameters)
            : base(method, buttonAttribute)
        {
            _parameters = parameters.Select(paramInfo => new Parameter(paramInfo)).ToArray();
            _expanded = buttonAttribute.Expanded;
        }

        protected override void DrawInternal(IEnumerable<object> targets)
        {
            (Rect foldoutRect, Rect buttonRect) = DrawUtility.GetFoldoutAndButtonRects(DisplayName);

            _expanded = DrawUtility.DrawInFoldout(foldoutRect, _expanded, DisplayName, () =>
            {
                foreach (Parameter param in _parameters)
                    param.Draw();
            });

            if ( ! GUI.Button(buttonRect, "Invoke"))
                return;

            var _paramValues = _parameters.Select(param => param.Value).ToArray();

            foreach (object obj in targets)
                Method.Invoke(obj, _paramValues);
        }

        private readonly struct Parameter
        {
            private readonly FieldInfo _fieldInfo;
            private readonly ScriptableObject _scriptableObj;
            private readonly NoScriptFieldEditor _editor;

            public Parameter(ParameterInfo paramInfo)
            {
                Type _generatedType = ScriptableObjectCache.GetClass(paramInfo.Name, paramInfo.ParameterType);
                _scriptableObj = ScriptableObject.CreateInstance(_generatedType);
                _fieldInfo = _generatedType.GetField(paramInfo.Name);
                _editor = CreateEditor<NoScriptFieldEditor>(_scriptableObj);
            }

            public object Value
            {
                get
                {
                    _editor.ApplyModifiedProperties();
                    return _fieldInfo.GetValue(_scriptableObj);
                }
            }

            public void Draw()
            {
                _editor.OnInspectorGUI();
            }

            private static TEditor CreateEditor<TEditor>(Object obj) where TEditor : Editor
            {
                return (TEditor) Editor.CreateEditor(obj, typeof(TEditor));
            }
        }
    }
}