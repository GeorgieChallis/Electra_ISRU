using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace ArduinoTester
{
    public partial class GS : Form
    {
        enum Command
        {
            ERROR = 0,
            STATUS = 1,
            ALL_DATA = 2,
            SW_MAGNET = 3,
            sW_HEATER = 4,
            SW_ELECTRO = 5,
            SW_RED = 6,
            SW_YELLOW = 7,
            SW_GREEN = 8,
            RD_MAGNET = 9,
            RD_HEATER = 10,
            RD_ELECTRO = 11,
            RD_TEMP_1 = 12,
            RD_TEMP_2 = 13,
            RD_LIGHT = 21
            //Other commands not yet implemented in hardware
        }

        static SerialPort _serialPort;

        public GS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button17_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort();
            _serialPort.BaudRate = 115200;
            try
            {
                _serialPort.PortName = textBox1.Text;
                _serialPort.Open();

            }
            catch (Exception) { return; }
            finally
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.DiscardInBuffer();
                    _serialPort.Write("!");
                    Thread.Sleep(50);  //Yeah I know this is bad, but it's just once at our start-up...
                    status_text.Text = "Connected";
                    button17.Enabled = false;
                    button3.Enabled = true;
                }
                else status_text.Text = "Connection Failed";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button17.Enabled = true;
            button3.Enabled = false;
            if (_serialPort.IsOpen) _serialPort.Close();
            status_text.Text = "Disconnected";
        }

        private void GetTemp_Button_Click(object sender, EventArgs e)
        {
            String temperature = CheckDataReceived((int)Command.RD_TEMP_1);
            temp_text.Text = temperature;
        }

        private void GetLight_Button_Click(object sender, EventArgs e)
        {
            String light = CheckDataReceived((int)Command.RD_LIGHT);
            light_text.Text = light;
        }

        private void Red_Button_Click(object sender, EventArgs e)
        {
            String red = CheckDataReceived((int)Command.RD_LIGHT);
        }

        private void Yellow_Button_Click(object sender, EventArgs e)
        {
            String yellow = CheckDataReceived((int)Command.RD_LIGHT);
        }

        private void Green_Button_Click(object sender, EventArgs e)
        {

            String green = CheckDataReceived((int)Command.RD_LIGHT);
        }

        private void Magnet_Button_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                String sendString = ((int)Command.SW_MAGNET).ToString() + ';';
                _serialPort.Write(sendString);
            }
        }

        private void Heater_Button_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                String sendString = ((int)Command.sW_HEATER).ToString() + ';';
                _serialPort.Write(sendString);
            }
        }

        private void Electro_Button_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                String sendString = ((int)Command.SW_ELECTRO).ToString() + ';';
                _serialPort.Write(sendString);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        String CheckDataReceived(int expectedCommand)
        {
            if (!_serialPort.IsOpen) return "";
            else
            {
                String sendString = expectedCommand.ToString() + ';';

                _serialPort.DiscardInBuffer();
                _serialPort.Write(sendString);

                int totalBytes = _serialPort.BytesToRead;
                if (totalBytes < 1) return "";
                byte[] buffer = new byte[totalBytes];
                _serialPort.Read(buffer, 0, totalBytes);

                if (buffer[0] != (char)'{') return "";
                else
                {
                    int recvdCommand = (int)buffer[1];
                    if (recvdCommand != expectedCommand) return "";
                    //process
                    return Encoding.Default.GetString(buffer);
                }

            }
        }
    }
}
