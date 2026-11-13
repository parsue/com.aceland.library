using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
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

        // UI Toolkit 入口:手動列舉序列化屬性並為每個屬性建立 PropertyField,讓
        // [CustomPropertyDrawer] 的 UITK CreatePropertyGUI 能被正確分派(IMGUI 的
        // DrawDefaultInspector 只會走 OnGUI,會使純 UITK drawer 落到基底 → "No GUI Implemented")。
        //
        // 注意:不可使用 new InspectorElement(serializedObject) —— InspectorElement 會依物件
        // 查找並套用其 CustomEditor,而本類即 typeof(Object) 的全域 CustomEditor,將造成
        // CreateInspectorGUI → InspectorElement → ObjectEditor → … 無限遞迴 / stack overflow。
        //
        // Inspector 按鈕仍為 IMGUI,包入 IMGUIContainer 於屬性之後繪製。
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            var property = serializedObject.GetIterator();
            if (property.NextVisible(true))
            {
                do
                {
                    var field = new PropertyField(property.Copy())
                    {
                        name = "PropertyField:" + property.propertyPath,
                    };

                    // 腳本欄位(m_Script)維持唯讀,對齊預設 Inspector 行為。
                    if (property.propertyPath == "m_Script")
                        field.SetEnabled(false);

                    root.Add(field);
                }
                while (property.NextVisible(false));
            }

            root.Bind(serializedObject);

            if (_buttonsDrawer is { Buttons: { Count: > 0 } })
                root.Add(new IMGUIContainer(() => _buttonsDrawer.DrawButtons(targets)));

            return root;
        }
    }
}
