using AceLand.Library.Attribute;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Reflection;

namespace AceLand.Library.Editor.InspectorButton
{

    public class InspectorButtonsDrawer
    {
        [PublicAPI] public readonly List<InspectorButton> Buttons = new List<InspectorButton>();

        public InspectorButtonsDrawer(object target)
        {
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            var methods = target.GetType().GetMethods(bindingFlags);

            foreach (var method in methods)
            {
                var buttonAttribute = method.GetCustomAttribute<InspectorButtonAttribute>();

                if (buttonAttribute == null)
                    continue;

                Buttons.Add(InspectorButton.Create(method, buttonAttribute));
            }
        }

        public void DrawButtons(IEnumerable<object> targets)
        {
            foreach (var button in Buttons)
                button.Draw(targets);
        }
    }
}