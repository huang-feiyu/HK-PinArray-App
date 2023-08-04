using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Admin
{
    public class Popup : MonoBehaviour
    {
        public string playerScene = "Scenes/PlayerScene";

        public Popup popup;
        public TMP_Text info;


        private void Start()
        {
            popup.gameObject.SetActive(false);
        }

        public void OnClickClose()
        {
            popup.gameObject.SetActive(false);
        }

        public void OnClickDebug()
        {
            GlobalManager.DebugMode = true;
            SceneManager.LoadScene(playerScene);
        }

        public void OnClickPlay()
        {
            GlobalManager.DebugMode = false;
            SceneManager.LoadScene(playerScene);
        }
    }
}
