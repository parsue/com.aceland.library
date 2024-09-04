namespace AceLand.Library.Editor.InspectorButton
{
    using AceLand.Library.Attribute;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;

    internal class InspectorButtonWithoutParams : InspectorButton
    {
        public InspectorButtonWithoutParams(MethodInfo method, InspectorButtonAttribute buttonAttribute)
            : base(method, buttonAttribute) { }

        protected override void DrawInternal(IEnumerable<object> targets)
        {
            if ( ! GUILayout.Button(DisplayName))
                return;

            foreach (object obj in targets)
            {
                Method.Invoke(obj, null);
            }
        }
    }
}