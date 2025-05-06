using UnityEngine;

namespace Assets.Experiment02.HideShowSystem
{
    [RequireComponent(typeof(Renderer))]
    public class Hideable : MonoBehaviour
    {
        private Renderer _renderer;

        private void Start() => _renderer = GetComponent<Renderer>();

        public void Hide() => _renderer.enabled = false;

        public void Show() => _renderer.enabled = true;
    }
}
