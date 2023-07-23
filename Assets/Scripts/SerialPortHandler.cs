using UnityEngine;
using System;
using System.IO.Ports;

public class SerialPortHandler : MonoBehaviour
{
    private static SerialPort _port; // Global singleton

    private const int BaudRate = 115200;

    public static string[] GetPorts()
    {
        // Hard to get description of port (always choose the biggest one or the newer one)
        return SerialPort.GetPortNames();
    }

    public static bool Connect(string portName)
    {
        Disconnect();

        _port = new SerialPort(portName, BaudRate, Parity.None, 8, StopBits.None);

        try
        {
            _port.Open();
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to open port: " + ex.Message);
            return false;
        }
    }

    public static void Disconnect()
    {
        if (_port is { IsOpen: true })
        {
            _port.Close();
            Debug.Log("Close " + _port.PortName);
        }
    }

    public static void Write(string message)
    {
        if (_port is { IsOpen: true })
        {
            _port.WriteLine(message);
        }
    }
}
