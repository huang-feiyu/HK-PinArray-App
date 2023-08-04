using TMPro;
using UnityEngine;

namespace Admin
{
    public class Button : MonoBehaviour
    {
        public Popup popup;
        public Dropdown dropdown;
        public TMP_InputField rows;
        public TMP_InputField cols;

        void Start()
        {
            rows.text = "5";
            cols.text = "5";
        }

        public void OnClickConnect()
        {
            // connect to port
            var port = dropdown.selectedItem;
            SerialPortHandler.Disconnect();
            var connected = port == "NONE" || SerialPortHandler.Connect(port);
            popup.info.text = "Connect to " + port + " → " + (connected ? "Success" : "Fail");

            // generate [rows][cols] Pin-Array
            int.TryParse(rows.text, out GlobalManager.Rows);
            int.TryParse(cols.text, out GlobalManager.Cols);
            popup.info.text += " → " + "Generate [" + rows.text + "][" + cols.text + "] Pin-Array";

            // show popup window to jump into next scene
            popup.gameObject.SetActive(true);
        }
    }
}
