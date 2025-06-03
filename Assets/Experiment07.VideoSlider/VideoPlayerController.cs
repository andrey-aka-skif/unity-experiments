using System;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Experiment07.VideoSlider
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoPlayerController : MonoBehaviour
    {
        [SerializeField]
        private VideoPlayerUI[] _UiPlayers;

        private VideoPlayer _player;
        private bool _hasPlayedBeforeBeginNavigate = false;
        private bool _isNavigateNow = false;

        /*
         * События ScreenSizeMinimizing и ScreenSizeExpanding
         * используются внешним кодом для выполнения дополнительных 
         * действий. На работу плеера непосредственно не влияют.
         */
        public event Action ScreenSizeMinimizing;
        public event Action ScreenSizeExpanding;

        private void Awake() => _player = GetComponent<VideoPlayer>();

        private void Update()
        {
            if (!_player.isPlaying || _isNavigateNow)
            {
                return;
            }

            foreach (var player in _UiPlayers)
            {
                if (player.gameObject.activeInHierarchy)
                {
                    player.Time = _player.time;
                }
            }
        }

        private void OnEnable()
        {
            foreach (var player in _UiPlayers)
            {
                player.PlayPauseClick += OnPlayPauseClick;
                player.ScreenSizeExpanding += OnScreenSizeExpanding;
                player.ScreenSizeMinimizing += OnScreenSizeMinimizing;
                player.BeginNavigate += OnBeginNavigate;
                player.EndNavigate += OnEndNavigate;
                player.TimeChanged += OnTimeChanged;
            }
        }

        private void OnDisable()
        {
            foreach (var player in _UiPlayers)
            {
                player.PlayPauseClick -= OnPlayPauseClick;
                player.ScreenSizeExpanding -= OnScreenSizeExpanding;
                player.ScreenSizeMinimizing -= OnScreenSizeMinimizing;
                player.BeginNavigate -= OnBeginNavigate;
                player.EndNavigate -= OnEndNavigate;
            }
        }

        public void SetupClip(VideoClip clip)
        {
            _player.clip = clip;
            _player.Stop();
            _player.Prepare();

            SetupUIPlayers();
        }

        private void OnScreenSizeExpanding() => ScreenSizeExpanding?.Invoke();

        private void OnScreenSizeMinimizing() => ScreenSizeMinimizing?.Invoke();

        private void OnPlayPauseClick()
        {
            if (_player.isPlaying)
                _player.Pause();
            else
                _player.Play();

            SetupUIPlayers();
        }

        private void SetupUIPlayers()
        {
            foreach (var player in _UiPlayers)
            {
                player.SetPlayingState(_player.isPlaying);
                player.MaxTime = _player.clip.length;
            }
        }

        private void OnBeginNavigate()
        {
            _hasPlayedBeforeBeginNavigate = _player.isPlaying;
            _isNavigateNow = true;

            if (_player.isPlaying)
            {
                _player.Pause();
            }
        }

        private void OnEndNavigate()
        {
            _isNavigateNow = false;

            if (_hasPlayedBeforeBeginNavigate)
            {
                _player.Play();
            }
        }

        private void OnTimeChanged(double time)
        {
            _player.time = time;
        }
    }
}
