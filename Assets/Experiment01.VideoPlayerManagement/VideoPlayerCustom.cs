using System;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Experiment01.VideoPlayerManagement
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoPlayerCustom : MonoBehaviour
    {
        public event Action ScreenSizeMinimizing;
        public event Action ScreenSizeExpanding;

        [SerializeField] private VideoPlayerUI _inlinePlayer;
        [SerializeField] private VideoPlayerUI _fullScreenPlayer;

        private VideoPlayer _player;

        public void SetupClip(VideoClip clip)
        {
            _player.clip = clip;
            _player.Stop();

            SetupPlayPauseButtons();
        }

        private void OnEnable()
        {
            _player = GetComponent<VideoPlayer>();

            _inlinePlayer.PlayPauseClick += OnPlayPauseClick;
            _inlinePlayer.ScreenSizeChanging += OnScreenSizeExpanding;

            _fullScreenPlayer.PlayPauseClick += OnPlayPauseClick;
            _fullScreenPlayer.ScreenSizeChanging += OnScreenSizeMinimizing;
        }

        private void OnScreenSizeMinimizing() => ScreenSizeMinimizing?.Invoke();

        private void OnScreenSizeExpanding() => ScreenSizeExpanding?.Invoke();

        private void OnPlayPauseClick()
        {
            Debug.Log("OnPlayPauseClick");

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
