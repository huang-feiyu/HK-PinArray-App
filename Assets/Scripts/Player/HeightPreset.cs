using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;

namespace Player
{
    public class HeightPreset : MonoBehaviour
    {
        public int waveDuration = 1;

        private float _waveRemaining;

        public HeightSender _sender;

        public void Start()
        {
            _waveRemaining = waveDuration;
        }

        public void Wave()
        {
            GlobalManager.Waving = !GlobalManager.Waving;
            print(GlobalManager.Waving);
        }

        public void FixedUpdate()
        {
            if (GlobalManager.Waving)
            {
                _waveRemaining -= (float)1 / 60;
                if (_waveRemaining <= 0)
                {
                    _waveRemaining = waveDuration;
                    print("===Resend all===");

                    for (var i = 0; i < GlobalManager.Pins.Count; i++)
                    {
                        GlobalManager.Pins[i].SelectAll();
                        GlobalManager.Walls[i].selectedCubes = GlobalManager.Pins[i].selectedPins;

                        GlobalManager.Pins[i].SetHeight(i * 10);
                        GlobalManager.Walls[i].SetHeight(i * 10);

                        print("Send to Pin-" + i);

                        _sender.OnClickSubmit();
                    }
                }
            }
            else
            {
                _waveRemaining = waveDuration;
            }
        }
    }
}
