using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

/**
 * === Pin.cs ===
 * Description: C# script that will be attached to Prefab Pin
 * Function:
 *      - Click to select or unselect (temporarily use two colors to indicate selected or not)
 *      - Hold pins along with heights
 *      - Update pin color according to heights
 */
public class Pin : MonoBehaviour
{
    public static Color NormalColor = Color.white;
    public static Color SelectedColor = Color.grey;

    private Tuple<Transform, int>[] pins;
    public List<int> selectedPins = new();

    // Start is called before the first frame update
    void Start()
    {
        // Initialization for pin-heights
        var i = 0;
        pins = new Tuple<Transform, int>[16];
        foreach (Transform pin in transform)
        {
            pins[i] = new Tuple<Transform, int>(pin, 0);
            i++;
        }

        // Get all the child pins and add a click event listener to each.
        foreach (Transform pin in transform)
        {
            var button = pin.GetComponent<Button>();
            button.onClick.AddListener(() => OnPinClick(pin));
        }
    }

    // Click to select or unselect
    private void OnPinClick(Transform pin)
    {
        for (var i = 0; i < 16; i++)
        {
            if (pin.gameObject != pins[i].Item1.gameObject) continue;

            var button = pin.GetComponent<Button>();
            if (selectedPins.Contains(i))
            {
                selectedPins.Remove(i);
                button.image.color = NormalColor;
            }
            else
            {
                selectedPins.Add(i);
                button.image.color = SelectedColor;
            }

            break;
        }
    }

    // Update selected heights (invoked by ScrollBar)
    public void SetHeight(int height)
    {
        foreach (var i in selectedPins)
        {
            pins[i] = new Tuple<Transform, int>(pins[i].Item1, height);
        }
    }

    public int[] GetHeight()
    {
        var heights = new int[16];
        for (int i = 0; i < 16; i++)
        {
            heights[i] = pins[i].Item2;
        }

        return heights;
    }
}
