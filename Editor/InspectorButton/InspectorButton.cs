using AceLand.Library.Attribute;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Reflection;
using AceLand.Library.Editor.InspectorButton.Utils;
using UnityEditor;

namespace AceLand.Library.Editor.InspectorButton
{
    public abstract class InspectorButton
    {
        [PublicAPI] public readonly string DisplayName;
        [PublicAPI] public readonly MethodInfo Method;

        private readonly bool _disabled;

        protected internal InspectorButton(MethodInfo method, InspectorButtonAttribute buttonAttribute)
        {
            DisplayName = string.IsNullOrEmpty(buttonAttribute.Name) switch
            {
                true => ObjectNames.NicifyVariableName(method.Name),
                false => buttonAttribute.Name
            };

            Method = method;

            var inAppropriateMode = EditorApplication.isPlaying switch
            {
                true => buttonAttribute.Mode == InspectorButtonMode.EnabledInPlayMode,
                false => buttonAttribute.Mode == InspectorButtonMode.DisabledInPlayMode
            };

            _disabled = !(buttonAttribute.Mode == InspectorButtonMode.AlwaysEnabled || inAppropriateMode);
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
            var parameters = method.GetParameters();

            return parameters.Length switch
            {
                0 => new InspectorButtonWithoutParams(method, buttonAttribute),
                _ => new InspectorButtonWithParams(method, buttonAttribute, parameters),
            };
        }

        protected abstract void DrawInternal(IEnumerable<object> targets);
    }
}
