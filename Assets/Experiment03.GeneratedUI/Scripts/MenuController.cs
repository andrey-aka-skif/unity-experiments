using System;
using UnityEngine;

namespace Assets.Experiment03.GeneratedUI.Scripts
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        private Transform _root;

        [SerializeField]
        private CustomDropdown _paragraphItemPrefab;

        [SerializeField]
        private CustomPageItem _pageItemPrefab;

        public event Action<string> OnPageSelect;

        public void CreateMenu(Content content)
        {
            foreach (var paragraph in content.Paragraphs)
            {
                var paragraphItemUnityObject = Instantiate(_paragraphItemPrefab, _root);
                paragraphItemUnityObject.SetupTitle(paragraph.Title);

                foreach (var page in paragraph.Pages)
                {
                    var pageItemUnityObject = Instantiate(_pageItemPrefab, paragraphItemUnityObject.ListRoot);
                    pageItemUnityObject.Setup(page.Title, page.Id);
                    pageItemUnityObject.OnSelected += OnSelected;
                }
            }
        }

        public void OnSelected(string id) => OnPageSelect?.Invoke(id);
    }
}
