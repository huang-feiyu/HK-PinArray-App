using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    /**
     * === Wall.cs ===
     * Description: C# script that will be attached to Prefab Wall
     * Function:
     *      - Update real heights according to heights
     */
    public class Wall : MonoBehaviour
    {
        private Transform[] _cubes;
        public List<int> selectedCubes = new();

        private float _initZ;

        void Start()
        {
            var i = 0;
            _cubes = new Transform[16];
            foreach (Transform cube in transform)
            {
                _cubes[i] = cube;
                i++;

                _initZ = cube.position.z;
            }
        }

        public void SetHeight(int height)
        {
            foreach (var i in selectedCubes)
            {
                _cubes[i].localScale = new Vector3(GlobalManager.CubeSize, GlobalManager.CubeSize,
                    GlobalManager.CubeSize + height);
                _cubes[i].position =
                    new Vector3(_cubes[i].position.x, _cubes[i].position.y, _initZ - (float)height / 2);
            }
        }
    }
}
