using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Admin
{
    public class Dropdown : MonoBehaviour
    {
        public TMP_Dropdown dropdown;

        public string selectedItem;

        void Start()
        {
            UpdateItems();
            dropdown.onValueChanged.AddListener(delegate { SelectItem(); });
        }

        void SelectItem()
        {
            var index = dropdown.value;
            selectedItem = dropdown.options[index].text;
        }

        void UpdateItems()
        {
            dropdown.ClearOptions();
            var portNames = new List<string>(SerialPortHandler.GetPorts());
            portNames.Insert(0, "NONE");
            dropdown.AddOptions(portNames);

            SelectItem();
        }
    }
}
