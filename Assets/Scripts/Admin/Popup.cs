using System;
using TMPro;
using UnityEngine;

namespace Admin
{
    public class Popup : MonoBehaviour
    {
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
            info.text = "Transfer to Player Scene [Debug]";
            GlobalManager.DebugMode = true;
        }

        public void OnClickPlay()
        {
            info.text = "Transfer to Player Scene [Normal]";
            GlobalManager.DebugMode = false;
        }
    }
}
