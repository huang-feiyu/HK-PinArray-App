using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player
{
    /**
     * === Pin.cs ===
     * Description: C# script that will be attached to Prefab Pin
     * Function:
     *      - Click to select or unselect (temporarily use two colors to indicate selected or not)
     *      - Update pin color according to heights
     *      - Hold SelectAll status along with SelectAll/UnselectAll
     *      - Hold pins along with heights along with getter/setter
     *      - TODO: Gradient color display, dragging & zooming manipulation
     */
    public class Pin : MonoBehaviour
    {
        private static readonly Color NormalColor = Color.white;
        private static readonly Color SelectedColor = Color.grey;

        private Tuple<Transform, int>[] _pins;
        public List<int> selectedPins = new();

        public bool selectAll = false;

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

        private void Update()
        {
            if (GlobalManager.Dragging)
            {
                for (var i = 0; i < 16; i++)
                {
                    var button = _pins[i].Item1.GetComponent<Button>();
                    if (RectTransformUtility.RectangleContainsScreenPoint(button.GetComponent<RectTransform>(),
                            Input.mousePosition) && !selectedPins.Contains(i))
                    {
                        selectedPins.Add(i);
                        button.image.color = SelectedColor;
                    }
                }
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

            selectAll = selectedPins.Count == 16;
        }

        public void SelectAll()
        {
            for (var i = 0; i < 16; i++)
            {
                var button = _pins[i].Item1.GetComponent<Button>();
                button.image.color = SelectedColor;
                if (!selectedPins.Contains(i))
                {
                    selectedPins.Add(i);
                }
            }

            selectAll = selectedPins.Count == 16;
        }

        public void UnselectAll()
        {
            for (var i = 0; i < 16; i++)
            {
                var button = _pins[i].Item1.GetComponent<Button>();
                button.image.color = NormalColor;
            }

            selectedPins = new List<int>();
            selectAll = selectedPins.Count == 16;
        }

        public bool GetSelectAll()
        {
            return selectAll;
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
}
