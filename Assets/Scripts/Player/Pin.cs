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
    private static readonly Color NormalColor = Color.white;
    private static readonly Color SelectedColor = Color.grey;

    private Tuple<Transform, int>[] _pins;
    public List<int> selectedPins = new();

    // Start is called before the first frame update
    void Start()
    {
        // Initialization for pin-heights
        var i = 0;
        _pins = new Tuple<Transform, int>[16];
        foreach (Transform pin in transform)
        {
            _pins[i] = new Tuple<Transform, int>(pin, 0);
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
            if (pin.gameObject != _pins[i].Item1.gameObject) continue;

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
            _pins[i] = new Tuple<Transform, int>(_pins[i].Item1, height);
        }
    }

    public int[] GetHeight()
    {
        var heights = new int[16];
        for (int i = 0; i < 16; i++)
        {
            heights[i] = _pins[i].Item2;
        }

        return heights;
    }
}
