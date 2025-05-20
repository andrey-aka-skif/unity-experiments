using TMPro;
using UnityEngine;

namespace Assets.Experiment03.GeneratedUI.Scripts
{
    public class CustomDropdown : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _titleText;

        [SerializeField]
        private Transform _listRoot;

        public Transform ListRoot => _listRoot;

        public void SetupTitle(string title) => _titleText.text = title;
    }
}
