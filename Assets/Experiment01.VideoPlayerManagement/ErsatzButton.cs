using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Assets.Experiment01.VideoPlayerManagement
{
    [RequireComponent(typeof(Button))]
    public class ErsatzButton : MonoBehaviour
    {
        [SerializeField]
        private VideoPlayerCustom _player;

        [SerializeField]
        private VideoClip _clip;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        private void OnClick() => _player.SetupClip(_clip);
    }
}
