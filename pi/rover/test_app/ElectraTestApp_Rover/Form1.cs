using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;



namespace ElectraTestApp_Rover
{
    public partial class GS : Form
    {
        Serial_Controller serialController;
        Wireless_Controller piController;

        public GS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
