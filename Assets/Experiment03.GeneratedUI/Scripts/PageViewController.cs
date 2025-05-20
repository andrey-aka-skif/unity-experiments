using TMPro;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Experiment03.GeneratedUI.Scripts
{
    public class PageViewController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _title;

        [SerializeField]
        private VideoPlayer _player;

        [SerializeField]
        private TMP_Text _description;

        public void SetView(string title, VideoClip clip, string description)
        {
            _title.text = title;
            _player.clip = clip;
            _description.text = description;
        }
    }
}
