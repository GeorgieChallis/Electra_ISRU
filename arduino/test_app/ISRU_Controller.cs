using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Net;
using System.Net.Sockets;

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
                Thread.Sleep(100);
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
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
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

    public class Wireless_Controller : ISRU_Controller
    {
        public string forge_IP;
        public string gimli_IP;
        public IPHostEntry hostName;

        public Socket sender;
        
        public override void Connect()
        {
            string data = null;
            byte[] bytes = new Byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public override void Disconnect()
        {
            //throw new NotImplementedException();
        }
        public override string Send(string data)
        {
            throw new NotImplementedException();
        }
    }
}
