using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoCS
{
    internal class Program
    {
        public static SerialPort GetSerialPort;
        static void Main(string[] args)
        {
            GetSerialPort = new SerialPort();
            while (!GetSerialPort.IsOpen)
            {
                Console.WriteLine("Enter PortName Ex COM3 : ");
                GetSerialPort.PortName = Console.ReadLine();
                Console.WriteLine("Enter BaudRate Ex 9600 : ");
                GetSerialPort.BaudRate = int.Parse(Console.ReadLine());
                try
                {
                    GetSerialPort.Open();
                }
                catch (Exception EX) 
                {
                    MessageBox.Show(EX.Message, "Arduino CS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            new Form1().Show();
        }
    }
}
