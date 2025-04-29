using System;
using UnityEngine;

namespace Assets.Experiment01.VideoPlayerManagement
{
    public class VideoPlayerUI : MonoBehaviour
    {
        public event Action PlayPauseClick;
        public event Action ScreenSizeChanging;

        [SerializeField] private PlayPauseButton _playPauseButton;
        [SerializeField] private ActionButton _screenSizeChangeButton;

        public void SetPlayingState(bool isPlay) => _playPauseButton.SetState(isPlay);

        private void OnPlayPauseClick() => PlayPauseClick?.Invoke();

        private void OnScreenSizeChange() => ScreenSizeChanging?.Invoke();

        private void OnEnable()
        {
            _playPauseButton.Click += OnPlayPauseClick;
            _screenSizeChangeButton.Click += OnScreenSizeChange;
        }
    }
}
