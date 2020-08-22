using System;
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
            SW_HEATER = 4,
            SW_ELECTRO = 5,
            SW_RED = 6,
            SW_YELLOW = 7,
            SW_GREEN = 8,
            RD_MAGNET = 9,
            RD_HEATER = 10,
            RD_ELECTRO = 11,
            RD_TEMP_1 = 12,
            RD_TEMP_2 = 13,
            RD_LIGHT = 21,
            RD_RED = 28,
            RD_YELLOW = 29,
            RD_GREEN = 30,
            ESTOP    = 22
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
                    Thread.Sleep(250);

                    EnableCommands(true);

                    status_text.Text = "Connected";
                }
                else status_text.Text = "Connection Failed";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EnableCommands(false);
            if (_serialPort.IsOpen) _serialPort.Close();
            status_text.Text = "Disconnected";
        }

        private void GetTemp_Button_Click(object sender, EventArgs e)
        {
            String temperature = CheckDataReceived((int)Command.RD_TEMP_1);
            if (temperature != "") temp_text.Text = temperature;
        }

        private void GetLight_Button_Click(object sender, EventArgs e)
        {
            String light = CheckDataReceived((int)Command.RD_LIGHT);
            if (light != "") light_text.Text = light;
        }

        private void Red_Button_Click(object sender, EventArgs e)
        {
            float.TryParse(CheckDataReceived((int)Command.SW_RED), out float red);
            red_label.Text = (red < 1.0f) ? "OFF" : "ON";
        }

        private void Yellow_Button_Click(object sender, EventArgs e)
        {
            float.TryParse(CheckDataReceived((int)Command.SW_YELLOW), out float yellow);
            yellow_label.Text = (yellow < 1.0f) ? "OFF" : "ON";
        }

        private void Green_Button_Click(object sender, EventArgs e)
        {
            float.TryParse(CheckDataReceived((int)Command.SW_GREEN), out float green);
            green_label.Text = (green < 1.0f) ? "OFF" : "ON";
        }

        private void Magnet_Button_Click(object sender, EventArgs e)
        {
            float.TryParse(CheckDataReceived((int)Command.SW_MAGNET), out float state);
            magnet_label.Text = (state < 1.0f) ? "OFF" : "ON";
        }

        private void Heater_Button_Click(object sender, EventArgs e)
        {
            float.TryParse(CheckDataReceived((int)Command.SW_HEATER), out float state);
            heater_label.Text = (state < 1.0f) ? "OFF" : "ON";
        }

        private void Electro_Button_Click(object sender, EventArgs e)
        {
            float.TryParse(CheckDataReceived((int)Command.SW_ELECTRO), out float state);
            electro_label.Text = (state < 1.0f) ? "OFF" : "ON";
        }

        String CheckDataReceived(int expectedCommand)
        {
            if (!_serialPort.IsOpen)
                return "";
            else
            {
                String sendString = expectedCommand.ToString() + ';';

                _serialPort.DiscardInBuffer();
                _serialPort.Write(sendString);

                Thread.Sleep(100);

                int totalBytes = _serialPort.BytesToRead;
                if (totalBytes < 4) {
                    Console.WriteLine("No data to read.");
                    return "";
                }

                byte[] buffer = new byte[totalBytes];
                _serialPort.Read(buffer, 0, totalBytes);

                if (buffer[0] != 0x7b || buffer[2] != 0x3a) {
                    Console.WriteLine("Wrong packet format.");
                    return "";
                }
                else
                {
                    int recvdCommand = (int)buffer[1];
                    if (recvdCommand != expectedCommand)  {
                        Console.WriteLine("Command number does not match.");
                        return "";
                    }
                    //process
                    byte[] temp = new byte[totalBytes - 4];

                    int j = 0;
                    for (int i = 3; i < totalBytes-1; i++) {
                        temp[j] = buffer[i];
                        ++j;
                    }

                    return Encoding.Default.GetString(temp);
                }
            }
        }

        void EnableCommands(bool connected) {
            Connect_Button.Enabled = !connected;
            Disconnect_Button.Enabled = connected;
            GetTemp_Button.Enabled = connected;
            GetLight_Button.Enabled = connected;
            Red_Button.Enabled = connected;
            Green_Button.Enabled = connected;
            Magnet_Button.Enabled = connected;
            Heater_Button.Enabled = connected;
            Electro_Button.Enabled = connected;

            if (connected)
            {
                float.TryParse(CheckDataReceived((int)Command.RD_RED), out float red);
                red_label.Text = (red < 1.0f) ? "OFF" : "ON";

                float.TryParse(CheckDataReceived((int)Command.RD_YELLOW), out float yellow);
                yellow_label.Text = (yellow < 1.0f) ? "OFF" : "ON";

                float.TryParse(CheckDataReceived((int)Command.RD_GREEN), out float green);
                green_label.Text = (green < 1.0f) ? "OFF" : "ON";

                float.TryParse(CheckDataReceived((int)Command.SW_MAGNET), out float state);
                magnet_label.Text = (state < 1.0f) ? "OFF" : "ON";

                float.TryParse(CheckDataReceived((int)Command.SW_HEATER), out state);
                heater_label.Text = (state < 1.0f) ? "OFF" : "ON";

                float.TryParse(CheckDataReceived((int)Command.SW_ELECTRO), out state);
                electro_label.Text = (state < 1.0f) ? "OFF" : "ON";
            }

            else {
                red_label.Text = "----";
                yellow_label.Text = "----";
                green_label.Text = "----";
                magnet_label.Text = "----";
                heater_label.Text = "----";
                electro_label.Text = "----";

                temp_text.Text += "*";
                light_text.Text += "*";
            }
        }

        private void Stop_Button_Click(object sender, EventArgs e)
        {
            String heater = CheckDataReceived((int)Command.SW_HEATER);
            Thread.Sleep(500);
            //Check that heater and electrolysis are off
        }
    }
}
