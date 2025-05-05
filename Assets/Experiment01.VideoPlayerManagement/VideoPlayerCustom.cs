using NUnit.Framework.Internal;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;
using static Unity.VisualScripting.Member;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Experiment01.VideoPlayerManagement
{
    [RequireComponent(typeof(VideoPlayer))]
    public class VideoPlayerCustom : MonoBehaviour
    {
        [SerializeField]
        private VideoPlayerUI _inlinePlayer;

        [SerializeField]
        private VideoPlayerUI _fullScreenPlayer;

        private VideoPlayer _player;
        private RenderTexture _renderTexture;

        private VideoPreviewCreator _previewCreator;

        public event Action ScreenSizeMinimizing;
        public event Action ScreenSizeExpanding;

        private void Awake()
        {
            _player = GetComponent<VideoPlayer>();
            _renderTexture = _player.targetTexture;
            _previewCreator = new VideoPreviewCreator();
            _previewCreator.Prepare(gameObject);
        }

        private void OnEnable()
        {
            _inlinePlayer.PlayPauseClick += OnPlayPauseClick;
            _inlinePlayer.ScreenSizeChanging += OnScreenSizeExpanding;

            _fullScreenPlayer.PlayPauseClick += OnPlayPauseClick;
            _fullScreenPlayer.ScreenSizeChanging += OnScreenSizeMinimizing;

            _previewCreator.Created += OnPreviewCreated;
        }

        private void OnDisable()
        {
            _inlinePlayer.PlayPauseClick -= OnPlayPauseClick;
            _inlinePlayer.ScreenSizeChanging -= OnScreenSizeExpanding;

            _fullScreenPlayer.PlayPauseClick -= OnPlayPauseClick;
            _fullScreenPlayer.ScreenSizeChanging -= OnScreenSizeMinimizing;

            _previewCreator.Created -= OnPreviewCreated;
        }

        public void SetupClip(VideoClip clip)
        {
            _player.clip = clip;
            _player.Stop();
            _player.Prepare();

            _previewCreator.Create(clip, _renderTexture);
            SetupPlayPauseButtons();
        }

        private void OnScreenSizeMinimizing() => ScreenSizeMinimizing?.Invoke();

        private void OnScreenSizeExpanding() => ScreenSizeExpanding?.Invoke();

        private void OnPlayPauseClick()
        {
            if (_player.isPlaying)
                _player.Pause();
            else
                _player.Play();

            SetupPlayPauseButtons();
        }

        private void SetupPlayPauseButtons()
        {
            _inlinePlayer.SetPlayingState(_player.isPlaying);
            _fullScreenPlayer.SetPlayingState(_player.isPlaying);
        }

        private void OnPreviewCreated(Texture preview)
        {
            Debug.Log(_renderTexture.IsCreated());
            Debug.Log($"Texture ({preview.width}:{preview.height})");
            Debug.Log($"RenderTexture ({_renderTexture.width}:{_renderTexture.height})");

            Graphics.Blit(preview, _renderTexture);
        }
    }

    public class VideoPreviewCreator
    {
        private VideoPlayer _player;
        private int _width;
        private int _height;
        private RenderTexture _renderTexture;

        public event Action<Texture> Created;

        public void Prepare(GameObject root)
        {
            _player = root.AddComponent<VideoPlayer>();
            _player.renderMode = VideoRenderMode.APIOnly;
            _player.playOnAwake = false;
            _player.audioOutputMode = VideoAudioOutputMode.None;
            _player.sendFrameReadyEvents = true;
            _player.prepareCompleted += Prepared;
            _player.frameReady += FrameReady;
        }

        public void Create(VideoClip clip) => Create(clip, (int)clip.width, (int)clip.height);

        public void Create(VideoClip clip, RenderTexture renderTexture)
        {
            _renderTexture = renderTexture;

            Create(clip, renderTexture.width, renderTexture.height);
        }

        public void Create(VideoClip clip, int width, int height)
        {
            _player.clip = clip;
            _player.Stop();
            _player.Prepare();
            _width = width;
            _height = height;
        }

        private void Prepared(VideoPlayer player) => player.Play();

        private void FrameReady(VideoPlayer player, long frameIndex)
        {
            player.Pause();

            var texture2d = RenderTextureToTexture2D(_renderTexture);

            if (texture2d.width != _width || texture2d.height != _height)
                texture2d = ChangeTextureSize(texture2d, _width, _height);

            Created?.Invoke(texture2d);
        }

        public static Texture2D RenderTextureToTexture2D(RenderTexture renderTexture)
        {
            // Создаем новую текстуру того же размера
            Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);

            // Читаем пиксели из RenderTexture
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();

            // Восстанавливаем предыдущую активную RenderTexture
            RenderTexture.active = null;

            return texture;
        }

        public Texture2D ChangeTextureSize(Texture2D texture, int newWidth, int newHeight)
        {
            // Проверяем входные параметры
            if (texture == null)
            {
                Debug.LogError("Текстура не может быть null");
                return null;
            }

            // Проверяем, можно ли читать текстуру
            if (!texture.isReadable)
            {
                Debug.LogError("Текстура должна иметь установленный флаг 'Read/Write Enabled'");
                return null;
            }

            // Переинициализируем текстуру с новым размером
            texture.Reinitialize(newWidth, newHeight);

            // Применяем изменения
            texture.Apply();

            return texture;
        }
    }
}
