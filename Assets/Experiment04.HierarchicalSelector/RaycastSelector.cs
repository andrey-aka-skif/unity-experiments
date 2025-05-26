using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Experiment04.HierarchicalSelector
{
    public class RaycastSelector : MonoBehaviour
    {
        private RaycastHit _raycastHit;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out _raycastHit))
                return;

            var root = _raycastHit.transform.GetComponentInParent<Root>();

            if (root != null)
                Debug.Log(root.transform.name);

        }
    }
}
