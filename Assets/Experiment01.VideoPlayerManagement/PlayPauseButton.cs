using UnityEngine;

namespace Assets.Experiment01.VideoPlayerManagement
{
    public class PlayPauseButton : ActionButton
    {
        [SerializeField] private GameObject _playText;
        [SerializeField] private GameObject _pauseText;

        public void SetState(bool isPlaying)
        {
            Debug.Log(isPlaying);

            if (isPlaying)
            {
                _playText.SetActive(false);
                _pauseText.SetActive(true);
            }
            else
            {
                _playText.SetActive(true);
                _pauseText.SetActive(false);
            }
        }
    }
}
