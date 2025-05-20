using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Experiment03.GeneratedUI.Scripts
{
    [CreateAssetMenu(fileName = "Content", menuName = "Experiment03.GeneratedUI/Create Content", order = 2)]
    public class Content : ScriptableObject
    {
        public List<ContentParagraph> Paragraphs;
    }

    [Serializable]
    public class ContentParagraph
    {
        public string Title;
        public List<ContentPage> Pages;
    }

    [Serializable]
    public class ContentPage
    {
        public string Id { get; private set; }

        public string Title;
        public string Description;
        public VideoClip Clip;

        private ContentPage()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
