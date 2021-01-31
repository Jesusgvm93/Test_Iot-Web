using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class Esp32 : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);
    public string receivedString;
    public GameObject objectToEnable;
    public GameObject objectToDisable;
    public static bool enable = true;
    public static bool disable = false;
    public string textValue;
    private string datos;
    public Text textElement;
    int data = 1;
  
   
    void Start()
    {
        serialPort.Open();
        textElement.text = textValue;
    }

   void Update()
    {
        if (data == 0)
        {
            Distance();
        }

        else
        {
            data = 1;
        }
        
        textElement.text = textValue; 
    }

    public void LedOn()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Write("A");
            objectToEnable.SetActive(true);
            data = 0;
        }
    }
  
    public void LedOff()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Write("c");
            objectToDisable.SetActive(false);
            data = 1;
            
        }
    }

    public void Distance()
    {
        receivedString = serialPort.ReadLine();
        serialPort.BaseStream.Flush();
        string[] datos = receivedString.Split(',');
        if (datos[0] != "")
        {
            textValue = datos [0] + " " + "Cm";
        }
    }
}

