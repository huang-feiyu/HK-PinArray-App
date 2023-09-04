using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class Benchmark : MonoBehaviour
{
    public int interval = 1;

    public HeightSender sender;

    public TMP_InputField timesInput;

    private bool _isZero = false;

    void Start()
    {
        gameObject.SetActive(GlobalManager.DebugMode);
        timesInput.text = "0";
    }

    public void BenchmarkToggle()
    {
        GlobalManager.IsBenchmark = !GlobalManager.IsBenchmark;
        if (!GlobalManager.IsBenchmark)
        {
            foreach (var pin in GlobalManager.Pins)
            {
                //pin.UnselectAll();
            }
        }
        else
        {
            Invoke("SendOnce", interval);
        }
    }

    public void SendOnce()
    {
        var times = int.Parse(timesInput.text);
        if (GlobalManager.IsBenchmark && times > 0)
        {
            _isZero = !_isZero;
            if (times > 0)
            {
                timesInput.text = (times - 1).ToString();
            }

            if (times == 0)
            {
                GetComponent<Toggle>().isOn = false;
            }

            Invoke("SendOnce", interval);

            for (var i = 0; i < GlobalManager.Pins.Count; i++)
            {
                var pin = GlobalManager.Pins[i];
                if (pin.selectedPins.Count != 0)
                {
                    //pin.SelectAll();
                    pin.SetHeight(_isZero ? 0 : GlobalManager.MaxHeight);
                }

                var json = sender.GetJsonFromHeights(i);
                SerialPortHandler.Write(json);

                print(json);
            }
        }
    }
}
