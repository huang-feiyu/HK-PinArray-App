using UnityEngine;
using System;
using System.IO.Ports;


public class SerialPortHandler : MonoBehaviour
{
    public static SerialPort Port; // Global singleton

    private const int BaudRate = 115200;

    public string[] GetPorts()
    {
        return SerialPort.GetPortNames();
    }

    public bool Connect(string portName)
    {
        Port = new SerialPort(portName, BaudRate, Parity.None, 8, StopBits.None);
        Port.Open();

        return Port is { IsOpen: true };
    }

    public bool Disconnect()
    {
        var res = Port is { IsOpen: true };
        if (Port is { IsOpen: true })
        {
            Port.Close();
        }

        return res;
    }

    public void Write(string message)
    {
        Port.WriteLine(message);
    }
}
