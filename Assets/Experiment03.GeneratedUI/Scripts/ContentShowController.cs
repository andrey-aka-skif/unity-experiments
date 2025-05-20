using System.Linq;
using UnityEngine;

namespace Assets.Experiment03.GeneratedUI.Scripts
{
    public class ContentShowController : MonoBehaviour
    {
        [SerializeField]
        private MenuController _menu;

        [SerializeField]
        private PageViewController _pageView;

        private Content _content;

        private void OnEnable() => _menu.OnPageSelect += OnPageSelect;

        private void OnDisable() => _menu.OnPageSelect -= OnPageSelect;

        public void Init(Content content) => _content = content;

        private void OnPageSelect(string pageId)
        {
            if (_content == null)
                throw new System.ArgumentNullException(nameof(_content));

            var page = _content.Paragraphs
                .SelectMany(p => p.Pages)
                .FirstOrDefault(p => p.Id == pageId);

            if (page != null)
                _pageView.SetView(page.Title, page.Clip, page.Description);
        }
    }
}
