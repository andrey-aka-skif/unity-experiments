using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Experiment04.HierarchicalSelector
{
    public class PointerDownHandlerSelector : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(transform.name);
        }
    }
}
