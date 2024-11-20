using AceLand.Library.Attribute;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace AceLand.Library.Editor.InspectorButton
{
    internal class InspectorButtonWithoutParams : InspectorButton
    {
        public InspectorButtonWithoutParams(MethodInfo method, InspectorButtonAttribute buttonAttribute)
            : base(method, buttonAttribute) { }

        protected override void DrawInternal(IEnumerable<object> targets)
        {
            if ( ! GUILayout.Button(DisplayName))
                return;

            foreach (var obj in targets)
            {
                Method.Invoke(obj, null);
            }
        }
    }
}