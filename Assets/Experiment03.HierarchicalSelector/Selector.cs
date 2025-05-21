using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Experiment03.HierarchicalSelector
{
    public class Selector : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(transform.name);
        }
    }
}
