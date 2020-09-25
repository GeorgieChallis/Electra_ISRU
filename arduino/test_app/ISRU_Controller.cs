using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ArduinoTester
{
    public abstract class ISRU_Controller
    {
        public abstract void Connect();
        public abstract void Disconnect();
        public abstract string Send(string data);

        public string PortName = "COM4";
        public bool Connected = false;
    }

    public class Serial_Controller : ISRU_Controller
    {
        public static SerialPort _serialPort;
        public override void Connect()
        {
            _serialPort = new SerialPort();
            _serialPort.BaudRate = 115200;
            _serialPort.PortName = PortName;
            try
            {
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

                    Connected = true;
                }
                else Connected = false;
            }

        }
        public override void Disconnect()
        {
            if (_serialPort.IsOpen) _serialPort.Close();
        }

        public string Send(int command)
        {
            string sendString = command.ToString() + ';';

            _serialPort.DiscardInBuffer();
            _serialPort.Write(sendString);

            Thread.Sleep(100);

            int totalBytes = _serialPort.BytesToRead;
            if (totalBytes < 4)
            {
                Console.WriteLine("No data to read.");
                return "";
            }

            byte[] buffer = new byte[totalBytes];
            _serialPort.Read(buffer, 0, totalBytes);

            if (buffer[0] != 0x7b || buffer[2] != 0x3a)
            {
                Console.WriteLine("Wrong packet format.");
                return "";
            }
            else
            {
                int recvdCommand = (int)buffer[1];
                if (recvdCommand != command)
                {
                    Console.WriteLine("Command number does not match.");
                    return "";
                }
                //process
                byte[] temp = new byte[totalBytes - 4];

                int j = 0;
                for (int i = 3; i < totalBytes - 1; i++)
                {
                    temp[j] = buffer[i];
                    ++j;
                }

                return Encoding.Default.GetString(temp);
            }
        }

        public override string Send(string data)
        {
            return "";
        }
    }
}
