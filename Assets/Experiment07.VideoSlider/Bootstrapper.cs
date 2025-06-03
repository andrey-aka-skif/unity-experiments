using UnityEngine;
using UnityEngine.Video;

namespace Assets.Experiment07.VideoSlider
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private VideoClip _clip;

        [SerializeField]
        private VideoPlayerController _player;

        private void Start()
        {
            _player.SetupClip(_clip);
        }
    }
}
