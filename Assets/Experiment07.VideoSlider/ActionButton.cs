using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Experiment07.VideoSlider
{
    [RequireComponent(typeof(Button))]
    public class ActionButton : MonoBehaviour
    {
        private Button _button;

        public event Action Click;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        private void OnClick() => Click?.Invoke();
    }
}
