using UnityEngine;

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
        private const int PinSize = 160;
        private Vector3 _pinStartPoint; // (-620, 220, 0)

        public GameObject wallPrefab;
        public Transform wallParent;
        private const int WallSize = 100;
        private Vector3 _wallStartPoint; // (1400, 900, -100)

        void Start()
        {
            _pinStartPoint = pinParent.GetComponent<RectTransform>().position;
            GeneratePin();

            _wallStartPoint = wallParent.GetComponent<RectTransform>().position;
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
                    pin.transform.position = new Vector3(row * PinSize, -col * PinSize, 0) + _pinStartPoint;
                    GlobalManager.Pins.Add(pin.GetComponent<Pin>());
                }
            }
        }

        void GenerateWall()
        {
            GlobalManager.Walls = new();

            for (var col = 0; col < GlobalManager.Cols; col++)
            {
                for (var row = 0; row < GlobalManager.Rows; row++)
                {
                    var wall = Instantiate(wallPrefab, wallParent);
                    wall.transform.position = new Vector3(row * WallSize, -col * WallSize, 0) + _wallStartPoint;
                    GlobalManager.Walls.Add(wall.GetComponent<Wall>());
                }
            }
        }
    }
}
