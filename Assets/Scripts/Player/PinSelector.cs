using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    /**
     * === PinSelector.cs ===
     * Description: C# script that attaches to SelectAll checkbox
     * Function:
     *      - Click to select all
     *      - Automatically remove SelectAll state if users manually unselect one of pins
     *      - When it's at SelectAll state, click to unselect all
     */
    public class PinSelector : MonoBehaviour
    {
        public Toggle toggle;

        public void OnToggleChange()
        {
            if (toggle.isOn)
            {
                foreach (var pin in GlobalManager.Pins)
                {
                    pin.SelectAll();
                }
            }
            else
            {
                var selectAll = true;
                foreach (var pin in GlobalManager.Pins)
                {
                    selectAll &= pin.GetSelectAll();
                }

                if (selectAll)
                {
                    foreach (var pin in GlobalManager.Pins)
                    {
                        pin.UnselectAll();
                    }
                }
            }
        }

        private void Update()
        {
            foreach (var pin in GlobalManager.Pins)
            {
                if (!pin.GetSelectAll())
                {
                    toggle.isOn = false;
                    break;
                }
            }
        }
    }
}
