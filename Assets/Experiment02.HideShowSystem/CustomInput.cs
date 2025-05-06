using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Experiment02.HideShowSystem
{
    public class CustomInput : MonoBehaviour
    {
        private RaycastHit _raycastHit;

        public event Action<GameObject> Touched;
        public event Action UnTouched;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out _raycastHit))
            {
                UnTouched?.Invoke();
                return;
            }

            Touched?.Invoke(_raycastHit.transform.gameObject);
        }
    }
}
