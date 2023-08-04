using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * === PinGenerator.cs ===
 * Description: C# script that performs as a method class, can be attached to any objects
 * Function:
 *      - Generate Pins & Walls
 *      - TODO: generate JSON string
 */
public class PinGenerator : MonoBehaviour
{
    private Vector3 UIStartPoint;
    private const int PinSize = 160;

    public GameObject pinPrefab;
    public Transform pinParent;

    void Start()
    {
        UIStartPoint = pinParent.GetComponent<RectTransform>().position;
        GeneratePin();
    }

    void GeneratePin()
    {
        for (var col = 0; col < GlobalManager.Cols; col++)
        {
            for (var row = 0; row < GlobalManager.Rows; row++)
            {
                var pin = Instantiate(pinPrefab, pinParent);
                pin.transform.position = new Vector3(row * PinSize, -col * PinSize, 0) + UIStartPoint;
            }
        }
    }
}
