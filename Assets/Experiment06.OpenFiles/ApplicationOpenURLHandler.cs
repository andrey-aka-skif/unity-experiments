using System.IO;
using UnityEngine;

namespace Assets.Experiment06.OpenFiles
{
    public class ApplicationOpenURLHandler : MonoBehaviour
    {
        [SerializeField]
        private string _fileFolder;

        [SerializeField]
        private string _fileName = "WL250040DTAV.pdf";

        private void Start() => OpenFileFromStreamingAssetsPath(_fileName);

        private void OpenFileFromStreamingAssetsPath(string fileName)
        {
            var path = Path.Combine(Application.streamingAssetsPath, fileName);

            Debug.Log(Application.streamingAssetsPath);
            Debug.Log(path);

            if (!File.Exists(path))
            {
                Debug.Log($"File {path} not exist");
                return;
            }

            string urlPath = path.Replace("\\", "/");

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            urlPath = "file:///" + urlPath;
#else
        urlPath = "file://" + urlPath;
#endif

            Application.OpenURL(urlPath);
        }
    }
}
