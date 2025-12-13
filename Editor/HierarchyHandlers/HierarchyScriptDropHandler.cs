using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AceLand.Library.Editor.HierarchyHandlers
{
    [InitializeOnLoad]
    public class HierarchyScriptDropHandler
    {
        static HierarchyScriptDropHandler()
        {
#if UNITY_6000_3_OR_NEWER
            DragAndDrop.AddDropHandlerV2(OnScriptHierarchyDrop);
#else
            DragAndDrop.AddDropHandler(OnScriptHierarchyDrop);
#endif
        }

#if UNITY_6000_3_OR_NEWER
        private static DragAndDropVisualMode OnScriptHierarchyDrop(
            EntityId dropTargetEntityId,
            HierarchyDropFlags dropMode,
            Transform parentForDraggedObjects,
            bool perform
        )
#else
        private static DragAndDropVisualMode OnScriptHierarchyDrop(
            int dragInstanceId,
            HierarchyDropFlags dropMode,
            Transform parentForDraggedObjects,
            bool perform
        )
#endif
        {
            var monoScript = GetScriptBeingDragged();
            if (monoScript == null) return DragAndDropVisualMode.None;
            if (!perform) return DragAndDropVisualMode.Copy;
            
            var gameObject = EditorHelper.CreateAndRename(monoScript.name);
            gameObject.AddComponent(monoScript.GetClass());
            return DragAndDropVisualMode.Copy;
        }

        private static MonoScript GetScriptBeingDragged()
        {
            foreach (var draggedObject in DragAndDrop.objectReferences)
            {
                if (draggedObject is not MonoScript monoScript) continue;
                
                var scriptType = monoScript.GetClass();
                if (scriptType == null || 
                    !scriptType.IsSubclassOf(typeof(MonoBehaviour)) ||
                    scriptType.GetTypeInfo().IsAbstract) continue;
                return monoScript;
            }
            return null;
        }
    }
}