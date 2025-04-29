using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Experiment01.VideoPlayerManagement
{
    [RequireComponent(typeof(Button))]
    public class ActionButton : MonoBehaviour
    {
        public event Action Click;

        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick() => Click?.Invoke();
    }
}
