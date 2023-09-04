using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;

public class Benchmark : MonoBehaviour
{
    public int interval = 10;

    public HeightSender sender;

    private bool _isZero = false;

    void Start()
    {
        gameObject.SetActive(GlobalManager.DebugMode);
    }

    public void BenchmarkToggle()
    {
        GlobalManager.IsBenchmark = !GlobalManager.IsBenchmark;
        if (!GlobalManager.IsBenchmark)
        {
            foreach (var pin in GlobalManager.Pins)
            {
                pin.UnselectAll();
            }
        }
    }

    public void Update()
    {
        if (GlobalManager.IsBenchmark)
        {
            Thread.Sleep(interval);
            _isZero = !_isZero;

            for (var i = 0; i < GlobalManager.Pins.Count; i++)
            {
                var pin = GlobalManager.Pins[i];
                if (pin.selectedPins.Count != 0)
                {
                    pin.SelectAll();
                    pin.SetHeight(_isZero ? 0 : GlobalManager.MaxHeight);
                }

                var json = sender.GetJsonFromHeights(i);
                SerialPortHandler.Write(json);

                print(json);
            }
        }
    }
}
