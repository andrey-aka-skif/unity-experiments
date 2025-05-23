using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Assets.Experiment03.HierarchicalSelector
{
    public class PointerDownHandlerSelector : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(transform.name);
        }
    }
}
