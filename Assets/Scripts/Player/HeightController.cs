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
        public TMP_Text heightText;

        void Start()
        {
            slider.value = 0;
            heightText.text = "0";
            slider.onValueChanged.AddListener(OnHeightChange);
        }

        void OnHeightChange(float value)
        {
            var height = Mathf.RoundToInt(value * GlobalManager.MaxHeight);
            heightText.text = height.ToString();
            for (var i = 0; i < 16; i++)
            {
                print(GlobalManager.Walls[i]);
                print(GlobalManager.Pins[i]);
                GlobalManager.Walls[i].selectedCubes = GlobalManager.Pins[i].selectedPins;

                GlobalManager.Pins[i].SetHeight(height);
                GlobalManager.Walls[i].SetHeight(height);
            }
        }
    }
}
