using UnityEngine;

namespace Assets.Experiment01.VideoPlayerManagement
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private VideoPlayerCustom _player;
        [SerializeField] private GameObject _menu;
        [SerializeField] private GameObject _fullScreenPlayer;

        private void OnEnable()
        {
            _player.ScreenSizeMinimizing += OnScreenSizeMinimizing;
            _player.ScreenSizeExpanding += OnScreenSizeExpanding;
        }

        private void OnScreenSizeMinimizing()
        {
            _menu.SetActive(true);
            _fullScreenPlayer.SetActive(false);
        }

        private void OnScreenSizeExpanding()
        {
            _menu.SetActive(false);
            _fullScreenPlayer.SetActive(true);
        }
    }
}
