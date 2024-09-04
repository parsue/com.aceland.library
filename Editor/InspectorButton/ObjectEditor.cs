namespace AceLand.Library.Editor.InspectorButton
{
    using UnityEditor;
    using Object = UnityEngine.Object;

    [CustomEditor(typeof(Object), true)]
    [CanEditMultipleObjects]
    internal class ObjectEditor : Editor
    {
        private InspectorButtonsDrawer _buttonsDrawer;

        private void OnEnable()
        {
            _buttonsDrawer = new InspectorButtonsDrawer(target);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            _buttonsDrawer.DrawButtons(targets);
        }
    }
}
