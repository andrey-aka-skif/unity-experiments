using System;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Experiment01.VideoPlayerManagement
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoPlayerCustom : MonoBehaviour
    {
        [SerializeField]
        private VideoPlayerUI _inlinePlayer;

        [SerializeField]
        private VideoPlayerUI _fullScreenPlayer;

        private VideoPlayer _player;

        public event Action ScreenSizeMinimizing;
        public event Action ScreenSizeExpanding;

        private void Awake() => _player = GetComponent<VideoPlayer>();

        private void OnEnable()
        {
            _inlinePlayer.PlayPauseClick += OnPlayPauseClick;
            _inlinePlayer.ScreenSizeChanging += OnScreenSizeExpanding;

            _fullScreenPlayer.PlayPauseClick += OnPlayPauseClick;
            _fullScreenPlayer.ScreenSizeChanging += OnScreenSizeMinimizing;
        }

        private void OnDisable()
        {
            _inlinePlayer.PlayPauseClick -= OnPlayPauseClick;
            _inlinePlayer.ScreenSizeChanging -= OnScreenSizeExpanding;

            _fullScreenPlayer.PlayPauseClick -= OnPlayPauseClick;
            _fullScreenPlayer.ScreenSizeChanging -= OnScreenSizeMinimizing;
        }

        public void SetupClip(VideoClip clip)
        {
            _player.clip = clip;
            _player.Stop();
            _player.Prepare();

            SetupPlayPauseButtons();
        }

        private void OnScreenSizeMinimizing() => ScreenSizeMinimizing?.Invoke();

        private void OnScreenSizeExpanding() => ScreenSizeExpanding?.Invoke();

        private void OnPlayPauseClick()
        {
            if (_player.isPlaying)
                _player.Pause();
            else
                _player.Play();

            SetupPlayPauseButtons();
        }

        private void SetupPlayPauseButtons()
        {
            _inlinePlayer.SetPlayingState(_player.isPlaying);
            _fullScreenPlayer.SetPlayingState(_player.isPlaying);
        }
    }
}
