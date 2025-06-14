﻿using UnityEngine;

namespace Assets.Experiment07.VideoSlider
{
    public class PlayPauseButton : ActionButton
    {
        [SerializeField]
        private GameObject _playText;

        [SerializeField]
        private GameObject _pauseText;

        public void SetState(bool isPlaying)
        {
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
