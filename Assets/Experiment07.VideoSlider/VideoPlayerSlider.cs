using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Experiment07.VideoSlider
{
    [RequireComponent(typeof(Slider))]
    public class VideoPlayerSlider : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Slider _slider;

        public event Action BeginDrag;
        public event Action EndDrag;
        public event Action<float> ValueChanged;

        private bool _isNavigateNow;

        private void Awake() => _slider = GetComponent<Slider>();

        public void OnBeginDrag(PointerEventData eventData) => OnBeginDragOrPointerDown();

        public void OnPointerDown(PointerEventData eventData) => OnBeginDragOrPointerDown();

        public void OnEndDrag(PointerEventData eventData) => OnEndDragOrPointerUp();

        public void OnPointerUp(PointerEventData eventData) => OnEndDragOrPointerUp();

        public void OnDrag(PointerEventData eventData) => ValueChanged?.Invoke(_slider.value);

        private void OnBeginDragOrPointerDown()
        {
            if (_isNavigateNow)
            {
                return;
            }

            _isNavigateNow = true;

            BeginDrag?.Invoke();
        }

        private void OnEndDragOrPointerUp()
        {
            if (!_isNavigateNow)
            {
                return;
            }

            _isNavigateNow = false;

            ValueChanged?.Invoke(_slider.value);
            EndDrag?.Invoke();
        }

        public float Value
        {
            get => _slider.value;
            set
            {
                if (!_isNavigateNow)
                {
                    _slider.@value = value;
                }
            }
        }
    }
}
