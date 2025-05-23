using UnityEngine;

namespace Assets.Experiment04.Layouts
{
    public class LockCursor : MonoBehaviour
    {
        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
