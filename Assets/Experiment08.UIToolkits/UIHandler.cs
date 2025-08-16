using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using System;

namespace Assets.Experiment08.UIToolkits
{
    [RequireComponent(typeof(UIDocument))]
    public class UIHandler : MonoBehaviour
    {
        private const string BEST_SCORE_VALUE_ID = "BestScoreValue";

        private UIDocument _document;
        private Label _bestScoreLabel;
        private Button _playGameButton;
        private Button _exitButton;

        private void OnEnable()
        {
            _document = GetComponent<UIDocument>();

            var root = _document.rootVisualElement;
            _bestScoreLabel = root.Q<Label>(BEST_SCORE_VALUE_ID);

            _bestScoreLabel.text = 42.ToString();

            _playGameButton = root.Q<Button>("PlayButton");
            _exitButton = root.Q<Button>("ExitButton");

            _playGameButton.RegisterCallback<ClickEvent>(OnPlayGame);
            _exitButton.RegisterCallback<ClickEvent>(OnExit);
        }

        private void OnPlayGame(ClickEvent evt)
        {
            Debug.Log("OnPlayGame");
            Debug.Log(evt);
        }

        private void OnExit(ClickEvent evt)
        {
            Debug.Log("OnExit");
            Debug.Log(evt);
        }
    }
}
