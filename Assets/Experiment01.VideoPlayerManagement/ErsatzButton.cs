using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Assets.Experiment01.VideoPlayerManagement
{
    [RequireComponent(typeof(Button))]
    public class ErsatzButton : MonoBehaviour
    {
        [SerializeField] private VideoPlayerCustom _player;
        [SerializeField] private VideoClip _clip;

        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _player.SetupClip(_clip);
        }
    }
}
