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
                        -col * GlobalManager.CubeSize * 4, 0);
                    GlobalManager.Walls.Add(wall.GetComponent<Wall>());
                }
            }
        }
    }
}
