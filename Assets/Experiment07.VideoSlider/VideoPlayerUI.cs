using System;
using TMPro;
using UnityEngine;

namespace Assets.Experiment07.VideoSlider
{
    public class VideoPlayerUI : MonoBehaviour
    {
        [SerializeField]
        private PlayPauseButton _playPauseButton;

        [SerializeField]
        private ActionButton _screenSizeChangeButton;

        [SerializeField]
        private TMP_Text _currentTimeText;

        [SerializeField]
        private TMP_Text _maxTimeText;

        public event Action PlayPauseClick;
        public event Action ScreenSizeExpanding;
        public event Action ScreenSizeMinimizing;
        public event Action BeginNavigate;
        public event Action EndNavigate;
        public event Action<double> TimeChanged;

        private VideoPlayerSlider _slider;
        private double _maxTime;

        private void Awake()
        {
            _slider = transform.GetComponentInChildrenOrThrow<VideoPlayerSlider>();
        }

        private void OnEnable()
        {
            _playPauseButton.Click += OnPlayPauseClick;
            _screenSizeChangeButton.Click += OnScreenSizeChange;
            _slider.BeginDrag += OnSliderBeginDrag;
            _slider.EndDrag += OnSliderEndDrag;
            _slider.ValueChanged += OnSliderValueChanged;
        }

        private void OnDisable()
        {
            _playPauseButton.Click -= OnPlayPauseClick;
            _screenSizeChangeButton.Click -= OnScreenSizeChange;
            _slider.BeginDrag -= OnSliderBeginDrag;
            _slider.EndDrag -= OnSliderEndDrag;
            _slider.ValueChanged -= OnSliderValueChanged;
        }

        public double MaxTime
        {
            set
            {
                _maxTime = value;
                _maxTimeText.text = FormatTime(_maxTime);
            }
        }

        public double Time
        {
            set
            {
                _currentTimeText.text = FormatTime(value);
                _slider.Value = (float)(value / _maxTime);
            }
        }

        public void SetPlayingState(bool isPlay) => _playPauseButton.SetState(isPlay);

        private void OnPlayPauseClick() => PlayPauseClick?.Invoke();

        private void OnScreenSizeChange() => ScreenSizeExpanding?.Invoke();

        private void OnSliderBeginDrag() => BeginNavigate?.Invoke();

        private void OnSliderEndDrag() => EndNavigate?.Invoke();

        private void OnSliderValueChanged(float value)
        {
            var time = _maxTime * value;
            TimeChanged?.Invoke(time);
        }

        private static string FormatTime(double totalSeconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);

            if (timeSpan.TotalHours >= 1)
            {
                return string.Format("{0:D2}:{1:D2}:{2:D2}",
                    (int)timeSpan.TotalHours,
                    timeSpan.Minutes,
                    timeSpan.Seconds);
            }
            else if (timeSpan.TotalMinutes >= 1)
            {
                return string.Format("{0:D2}:{1:D2}",
                    timeSpan.Minutes,
                    timeSpan.Seconds);
            }
            else
            {
                return string.Format("{0:D2}",
                    timeSpan.Seconds);
            }
        }
    }
}
