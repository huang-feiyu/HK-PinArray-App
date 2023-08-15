using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    /**
     * === HeightController.cs ===
     * Description: C# script that will be attached to HeightController with few children components
     * Function:
     *      - Display height value
     *      - Update height value
     */
    public class HeightController : MonoBehaviour
    {
        public Slider slider;
        public TMP_InputField heightInput;

        void Start()
        {
            slider.value = 0;
            heightInput.text = "0";
            slider.onValueChanged.AddListener(OnHeightChange);
            heightInput.onValueChanged.AddListener(OnHeightChange);
        }

        private void OnHeightChange(string value)
        {
            var height = Int32.Parse(value);
            if (height >= 150)
            {
                heightInput.text = "150";
                height = 150;
            }
            else if (height <= 0)
            {
                heightInput.text = "0";
                height = 0;
            }

            for (var i = 0; i < GlobalManager.Pins.Count; i++)
            {
                GlobalManager.Walls[i].selectedCubes = GlobalManager.Pins[i].selectedPins;

                GlobalManager.Pins[i].SetHeight(height);
                GlobalManager.Walls[i].SetHeight(height);
            }
        }

        void OnHeightChange(float value)
        {
            var height = Mathf.RoundToInt(value * GlobalManager.MaxHeight);
            heightInput.text = height.ToString();
            for (var i = 0; i < GlobalManager.Pins.Count; i++)
            {
                GlobalManager.Walls[i].selectedCubes = GlobalManager.Pins[i].selectedPins;

                GlobalManager.Pins[i].SetHeight(height);
                GlobalManager.Walls[i].SetHeight(height);
            }
        }
    }
}
