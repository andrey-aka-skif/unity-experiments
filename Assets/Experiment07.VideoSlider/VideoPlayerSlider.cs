using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Experiment07.VideoSlider
{
    [RequireComponent(typeof(Slider))]
    public class VideoPlayerSlider : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Slider _slider;

        public event Action BeginDrag;
        public event Action EndDrag;
        public event Action<float> ValueChanged;

        private bool _isDragging;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(OnChangeValue);
        }

        public void OnBeginDrag(PointerEventData eventData) => OnBeginDragOrPointerDown();

        public void OnEndDrag(PointerEventData eventData) => OnBeginDragOrPointerDown();

        public void OnPointerDown(PointerEventData eventData) => OnEndDragOrPointerUp();

        public void OnPointerUp(PointerEventData eventData) => OnEndDragOrPointerUp();

        private void OnBeginDragOrPointerDown()
        {
            _isDragging = true;
            BeginDrag?.Invoke();
        }

        private void OnEndDragOrPointerUp()
        {
            _isDragging = false;
            EndDrag?.Invoke();
        }

        private void OnChangeValue(float value)
        {
            if (_isDragging)
            {
                ValueChanged?.Invoke(value);
            }
        }

        public float Value
        {
            get => _slider.value;
            set
            {
                if (!_isDragging)
                {
                    _slider.value = value;
                }
            }
        }
    }
}
