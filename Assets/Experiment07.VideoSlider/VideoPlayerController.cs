using UnityEngine;
using UnityEngine.Video;

namespace Assets.Experiment07.VideoSlider
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoPlayerController : MonoBehaviour
    {
        private VideoPlayer _player;
        private VideoPlayerSlider _slider;

        private bool _isPlayedBeforeSliderDrag;

        private void Awake()
        {
            _player = GetComponent<VideoPlayer>();
            _slider = transform.GetComponentInChildrenOrThrow<VideoPlayerSlider>();
        }

        private void Update()
        {
            if (_player.isPlaying)
            {
                _slider.Value = (float)(_player.time / _player.clip.length);
            }
        }

        private void OnEnable()
        {
            _slider.BeginDrag += OnSliderBeginDrag;
            _slider.EndDrag += OnSliderEndDrag;
            _slider.ValueChanged += OnSliderValueChanged;
        }

        private void OnDisable()
        {
            _slider.BeginDrag -= OnSliderBeginDrag;
            _slider.EndDrag -= OnSliderEndDrag;
            _slider.ValueChanged -= OnSliderValueChanged;
        }

        private void OnSliderBeginDrag()
        {
            _isPlayedBeforeSliderDrag = _player.isPlaying;

            if (_player.isPlaying)
            {
                _player.Pause();
            }
        }

        private void OnSliderEndDrag()
        {
            if (_isPlayedBeforeSliderDrag)
            {
                _player.Play();
            }
        }

        private void OnSliderValueChanged(float value)
        {
            _player.time = _player.clip.length * value;
        }
    }

    public class VideoPlayerUI : MonoBehaviour
    {

    }
}
