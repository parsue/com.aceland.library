using UnityEditor;
using Object = UnityEngine.Object;

namespace AceLand.Library.Editor.InspectorButton
{
    [CustomEditor(typeof(Object), true)]
    [CanEditMultipleObjects]
    internal class ObjectEditor : UnityEditor.Editor
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
