using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/**
 * === HeightController.cs ===
 * Description: C# script that will be attached to HeightController with few children components
 * Function:
 *      - Display height value
 *      - TODO: update pin's heights, gradient color display
 */
public class HeightController : MonoBehaviour
{
    private const int MaxHeight = 500;
    public Slider slider;
    public TMP_Text heightText;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        heightText.text = "0";
        slider.onValueChanged.AddListener(OnHeightChange);
    }

    void OnHeightChange(float value)
    {
        heightText.text = ((int)(value * MaxHeight)).ToString();
    }
}
