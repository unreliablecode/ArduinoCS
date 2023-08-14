using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArduinoCS.Form1;

namespace ArduinoCS.Communicator
{
    public static class Extensions
    {
        public static void DigitalWrite(this SerialPort serialPort, int GPIO, int Logic)
        {
            var json = JsonConvert.SerializeObject(new ArduinoMessage
            {
                GPIO = GPIO,
                LOGIC = Logic,
                isDigitalWrite = 1,
                Message_ = "DigitalWrite " + GPIO + " " + (Logic == 1 ? "HIGH" : "LOW")
            });
            serialPort.WriteLine(json);
        }
        public static void AnalogWrite(this SerialPort serialPort, int GPIO, float value)
        {
            var json = JsonConvert.SerializeObject(new ArduinoMessage
            {
                GPIO = GPIO,
                LOGIC = 1,
                Value = value,
                isDigitalWrite = 1,
                Message_ = "DigitalWrite " + GPIO + " Value " + value
            });
            serialPort.WriteLine(json);
        }
        public static void SendMessage(this SerialPort serialPort, string Message) 
        {
            serialPort.WriteLine($"{Message}");
        }
    }
}
