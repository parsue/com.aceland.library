using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ZLinq;

namespace AceLand.Library.Utils
{
    public partial class Helper
    {
        public bool IsOverUIElement(Vector2 screenPosition, int displayIndex = 0) =>
            IsPointerOverUIElement(GetEventSystemRaycastResults(screenPosition, displayIndex));
        
        private bool IsPointerOverUIElement(IEnumerable<RaycastResult> eventSystemRaycastResults)
        {
            return eventSystemRaycastResults
                .AsValueEnumerable()
                .Any(curRaycastResult => curRaycastResult.gameObject.layer == LayerMask.NameToLayer("UI"));
        }

        private IEnumerable<RaycastResult> GetEventSystemRaycastResults(Vector2 screenPosition, int displayIndex = 0)
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