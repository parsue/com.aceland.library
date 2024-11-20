using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AceLand.Library.Attribute;
using AceLand.Library.Editor.InspectorButton.Utils;
using UnityEngine;
using Object = UnityEngine.Object;
    
namespace AceLand.Library.Editor.InspectorButton
    {
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
            var (foldoutRect, buttonRect) = DrawUtility.GetFoldoutAndButtonRects(DisplayName);

            _expanded = DrawUtility.DrawInFoldout(foldoutRect, _expanded, DisplayName, () =>
            {
                foreach (var param in _parameters)
                    param.Draw();
            });

            if ( ! GUI.Button(buttonRect, "Invoke"))
                return;

            var paramValues = _parameters.Select(param => param.Value).ToArray();

            foreach (var obj in targets)
                Method.Invoke(obj, paramValues);
        }

        private readonly struct Parameter
        {
            private readonly FieldInfo _fieldInfo;
            private readonly ScriptableObject _scriptableObj;
            private readonly NoScriptFieldEditor _editor;

            public Parameter(ParameterInfo paramInfo)
            {
                var generatedType = ScriptableObjectCache.GetClass(paramInfo.Name, paramInfo.ParameterType);
                _scriptableObj = ScriptableObject.CreateInstance(generatedType);
                _fieldInfo = generatedType.GetField(paramInfo.Name);
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

            private static TEditor CreateEditor<TEditor>(Object obj) where TEditor : UnityEditor.Editor
            {
                return (TEditor) UnityEditor.Editor.CreateEditor(obj, typeof(TEditor));
            }
        }
    }
}