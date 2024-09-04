namespace AceLand.Library.Editor.InspectorButton
{
    using AceLand.Library.Attribute;
    using JetBrains.Annotations;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEditor;
    using Utils;

    public abstract class InspectorButton
    {
        [PublicAPI] public readonly string DisplayName;
        [PublicAPI] public readonly MethodInfo Method;

        internal readonly bool _disabled;

        internal protected InspectorButton(MethodInfo method, InspectorButtonAttribute buttonAttribute)
        {
            DisplayName = string.IsNullOrEmpty(buttonAttribute.Name) switch
            {
                true => ObjectNames.NicifyVariableName(method.Name),
                false => buttonAttribute.Name
            };

            Method = method;

            bool _inAppropriateMode = EditorApplication.isPlaying switch
            {
                true => buttonAttribute.Mode == InspectorButtonMode.EnabledInPlayMode,
                false => buttonAttribute.Mode == InspectorButtonMode.DisabledInPlayMode
            };

            _disabled = !(buttonAttribute.Mode == InspectorButtonMode.AlwaysEnabled || _inAppropriateMode);
        }

        public void Draw(IEnumerable<object> targets)
        {
            using (new EditorGUI.DisabledScope(_disabled))
            {
                using (new DrawUtility.VerticalIndent(true, false))
                {
                    DrawInternal(targets);
                }
            }
        }

        internal static InspectorButton Create(MethodInfo method, InspectorButtonAttribute buttonAttribute)
        {
            var _parameters = method.GetParameters();

            return _parameters.Length switch
            {
                0 => new InspectorButtonWithoutParams(method, buttonAttribute),
                _ => new InspectorButtonWithParams(method, buttonAttribute, _parameters),
            };
        }

        protected abstract void DrawInternal(IEnumerable<object> targets);
    }
}
