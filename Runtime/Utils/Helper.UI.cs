using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using ZLinq;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        public static bool IsOverUIElement(Vector2 screenPosition, int displayIndex = 0) =>
            IsPointerOverUIElement(GetEventSystemRaycastResults(screenPosition, displayIndex));
        
        private static bool IsPointerOverUIElement(IEnumerable<RaycastResult> eventSystemRaycastResults)
        {
            return eventSystemRaycastResults
                .AsValueEnumerable()
                .Any(curRaycastResult => curRaycastResult.gameObject.layer == LayerMask.NameToLayer("UI"));
        }

        private static IEnumerable<RaycastResult> GetEventSystemRaycastResults(Vector2 screenPosition, int displayIndex = 0)
        {
            PointerEventData eventData = new(EventSystem.current)
            {
                position = screenPosition,
                displayIndex = displayIndex
            };
            var raycastResults = new List<RaycastResult>();
            if (EventSystem.current != null)
            {
                EventSystem.current.RaycastAll(eventData, raycastResults);
            }
            foreach (var raycast in raycastResults)
            {
                yield return raycast;
            }
        }
    }
}