using UnityEngine;

namespace Assets.Experiment03.GeneratedUI.Scripts
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private Content _content;

        [SerializeField]
        private MenuController _menuController;

        [SerializeField]
        private ContentShowController _showController;

        private void Awake()
        {
            _menuController.CreateMenu(_content);
            _showController.Init(_content);
        }
    }
}
