using ArduinoCS.Communicator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class ArduinoMessage 
        {
            public int GPIO; //General Purpose Input Output
            public int LOGIC; // 0 or 1
            public int isDigitalWrite; //1 Digital Write and 0 AnalogWrite
            public float Value;
            public string Message_;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.GetSerialPort.DigitalWrite(int.Parse(textBox1.Text), 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.GetSerialPort.DigitalWrite(int.Parse(textBox1.Text), 0);
        }
    }
}
