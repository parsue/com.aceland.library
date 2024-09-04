namespace AceLand.Library.Editor.InspectorButton
{
    using AceLand.Library.Attribute;
    using JetBrains.Annotations;
    using System.Collections.Generic;
    using System.Reflection;

    public class InspectorButtonsDrawer
    {
        [PublicAPI] public readonly List<InspectorButton> Buttons = new List<InspectorButton>();

        public InspectorButtonsDrawer(object target)
        {
            const BindingFlags _flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            var _methods = target.GetType().GetMethods(_flags);

            foreach (MethodInfo method in _methods)
            {
                var buttonAttribute = method.GetCustomAttribute<InspectorButtonAttribute>();

                if (buttonAttribute == null)
                    continue;

                Buttons.Add(InspectorButton.Create(method, buttonAttribute));
            }
        }

        public void DrawButtons(IEnumerable<object> targets)
        {
            foreach (InspectorButton button in Buttons)
                button.Draw(targets);
        }
    }
}