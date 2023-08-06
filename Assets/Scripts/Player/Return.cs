using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Return : MonoBehaviour
    {
        private const string AdminScene = "Scenes/AdminScene";

        void Start()
        {
            gameObject.SetActive(GlobalManager.DebugMode);
        }

        public void OnClickReturn()
        {
            SceneManager.LoadScene(AdminScene);
        }
    }
}
