using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

namespace Player
{
    /**
     * === Initializer.cs ===
     * Description: C# script that performs as a method class, can be attached to Canvas
     * Function:
     *      - Generate Pins & Walls
     */
    public class Initializer : MonoBehaviour
    {
        public GameObject pinPrefab;
        public Transform pinParent;

        public GameObject wallPrefab;
        public Transform wallParent;

        void Start()
        {
            GeneratePin();
            GenerateWall();

            var cols = GlobalManager.Cols;
            var rows = GlobalManager.Rows;
            var matrix = new int[GlobalManager.Rows][];
            for (var i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                for (var j = 0; j < cols; j++)
                {
                    matrix[i][j] = i * rows + j;
                }
            }

            for (var i = 0; i < rows / 2; i++)
            {
                (matrix[i], matrix[rows - i - 1]) = (matrix[rows - i - 1], matrix[i]);
            }

            GlobalManager.IArray = new List<int>();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    GlobalManager.IArray.Add(matrix[i][j]);
                }
            }
        }

        void GeneratePin()
        {
            GlobalManager.Pins = new();

            for (var col = 0; col < GlobalManager.Cols; col++)
            {
                for (var row = 0; row < GlobalManager.Rows; row++)
                {
                    var pin = Instantiate(pinPrefab, pinParent);
                    pin.transform.localPosition = new Vector3(row * GlobalManager.PinSize * 4,
                        -col * GlobalManager.PinSize * 4, 0);
                    GlobalManager.Pins.Add(pin.GetComponent<Pin>());
                }
            }

            pinParent.localPosition = new Vector3(-GlobalManager.Rows * GlobalManager.PinSize,
                GlobalManager.Cols * GlobalManager.PinSize, 0);
        }

        void GenerateWall()
        {
            GlobalManager.Walls = new();

            for (var col = 0; col < GlobalManager.Cols; col++)
            {
                for (var row = 0; row < GlobalManager.Rows; row++)
                {
                    var wall = Instantiate(wallPrefab, wallParent);
                    wall.transform.localPosition = new Vector3(row * GlobalManager.CubeSize * 4,
                        -col * GlobalManager.CubeSize * 4, -30);
                    GlobalManager.Walls.Add(wall.GetComponent<Wall>());
                }
            }

            wallParent.localPosition = new Vector3(-GlobalManager.Rows * GlobalManager.CubeSize,
                GlobalManager.Cols * GlobalManager.CubeSize, 0);
        }


        public static void OnBeginDrag()
        {
            GlobalManager.Waving = false;
            GlobalManager.Dragging = true;
        }

        public static void OnEndDrag()
        {
            GlobalManager.Dragging = false;
        }
    }
}
