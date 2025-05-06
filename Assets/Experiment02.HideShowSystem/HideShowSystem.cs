using System.Collections.Generic;
using UnityEngine;

namespace Assets.Experiment02.HideShowSystem
{
    public class HideShowSystem : MonoBehaviour
    {
        [SerializeField]
        private CustomInput _customInput;

        private Hideable _selected;

        private readonly List<Hideable> _hidden = new();

        private void OnEnable()
        {
            _customInput.Touched += OnTouched;
            _customInput.UnTouched += OnUnTouched;
        }

        private void OnDisable()
        {
            _customInput.Touched -= OnTouched;
            _customInput.UnTouched -= OnUnTouched;
        }

        public void HideSelected()
        {
            if (_selected != null)
            {
                _selected.Hide();
                _hidden.Add(_selected);
            }
        }

        public void ShowAll()
        {
            foreach (var item in _hidden)
                item.Show();
        }

        private void OnTouched(GameObject touched)
        {
            if (!touched.TryGetComponent<Hideable>(out var hideable))
                return;

            _selected = hideable;
        }

        private void OnUnTouched() => _selected = null;
    }
}
