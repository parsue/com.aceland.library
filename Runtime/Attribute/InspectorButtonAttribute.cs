namespace AceLand.Library.Attribute
{
    using JetBrains.Annotations;
    using System;

    public enum InspectorButtonMode
    {
        AlwaysEnabled,
        EnabledInPlayMode,
        DisabledInPlayMode
    }

    [Flags]
    public enum InspectorButtonSpacing
    {
        None = 0,
        Before = 1,
        After = 2
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class InspectorButtonAttribute : Attribute
    {
        public readonly string Name;
        public InspectorButtonAttribute() { }
        public InspectorButtonAttribute(string name) => Name = name;
        [PublicAPI] public InspectorButtonMode Mode { get; set; } = InspectorButtonMode.DisabledInPlayMode;
        [PublicAPI] public bool Expanded { get; set; }
    }
}