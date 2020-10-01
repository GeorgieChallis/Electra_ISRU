using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;



namespace ArduinoTester
{
    public partial class GS : Form
    {
        Serial_Controller serialController;
        Wireless_Controller piController;
        
        public GS()
        {
            InitializeComponent();
            serialController = new Serial_Controller();
            piController = new Wireless_Controller();
        }

        private void Form1_Load(object sender, EventArgs e) { }


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
            if (!serialController.Connected) return "";
            else
            {
                string output = serialController.Send(expectedCommand);
                return output;
            }
        }

        void EnableCommands(bool connected)
        {
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

            else
            {
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
            String heater = CheckDataReceived((int)Command.ESTOP);
            Thread.Sleep(500);
            //Check that heater and electrolysis are off
            float.TryParse(CheckDataReceived((int)Command.RD_MAGNET), out float state);
            magnet_label.Text = (state < 1.0f) ? "OFF" : "ON";

            float.TryParse(CheckDataReceived((int)Command.RD_HEATER), out state);
            heater_label.Text = (state < 1.0f) ? "OFF" : "ON";

            float.TryParse(CheckDataReceived((int)Command.RD_ELECTRO), out state);
            electro_label.Text = (state < 1.0f) ? "OFF" : "ON";
        }


        private void Connect_Button_Click(object sender, EventArgs e)
        {
            serialController.PortName = textBox1.Text;
            serialController.Connect();

            if (serialController.Connected)
            {
                EnableCommands(true);
                status_text.Text = "Connected";
            }
            else status_text.Text = "Connection Failed";
        }

        private void Disconnect_Button_Click(object sender, EventArgs e)
        {
            serialController.Disconnect();
            if (serialController.Connected)
            {
                EnableCommands(false);
                status_text.Text = "Disconnected";
            }
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

        private void Connect_Button2_Click(object sender, EventArgs e)
        {
            piController.Connect();
        }

        private void Disconnect_Button2_Click(object sender, EventArgs e)
        {
            piController.Disconnect();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) // If arduino tab
            {
                piController.Disconnect();
                EnableCommands(false);
            }
            else if (tabControl1.SelectedIndex == 1) // If Pi tab
            {
                serialController.Disconnect();
                EnableCommands(false);
            }
            else Console.WriteLine("?");
        }
    }
}
