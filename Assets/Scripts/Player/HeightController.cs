using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * === HeightController.cs ===
 * Description: C# script that will be attached to HeightController with few children components
 * Function:
 *      - Display height value
 *      - Update height value
 *      - TODO: generate gradient color value
 */
public class HeightController : MonoBehaviour
{
    private const int MaxHeight = 150;
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
        var height = Mathf.RoundToInt(value * MaxHeight);
        heightText.text = height.ToString();
        foreach (var pin in GlobalManager.Pins)
        {
            pin.SetHeight(height);
        }
    }
}
