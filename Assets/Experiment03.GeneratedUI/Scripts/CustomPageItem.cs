using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

namespace Assets.Experiment03.GeneratedUI.Scripts
{
    [RequireComponent(typeof(Button))]
    public class CustomPageItem : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _titleText;

        private Button _button;
        private string _id = string.Empty;

        public event Action<string> OnSelected;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        private void OnClick() => OnSelected?.Invoke(_id);

        public void Setup(string title, string id)
        {
            _titleText.text = title;
            _id = id;
        }
    }
}
