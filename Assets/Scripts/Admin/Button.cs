using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Admin
{
    public class Button : MonoBehaviour
    {
        public Popup popup;
        public Dropdown dropdown;

        public void OnClickConnect()
        {
            var port = dropdown.selectedItem;
            SerialPortHandler.Disconnect();
            var connected = port == "NONE" || SerialPortHandler.Connect(port);
            popup.info.text = "Connect to " + port + " → " + (connected ? "Success" : "Fail");

            popup.gameObject.SetActive(true);
        }
    }
}
