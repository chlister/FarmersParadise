using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace SensorLib
{
    public static class SensorLib
    {
        private static string StartClient(IPAddress sensorIP, string message)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(sensorIP, 80);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(sensorIP.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    //Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    string sendstring = "Mellem bob";

                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.ASCII.GetBytes(sendstring);

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                    return Encoding.ASCII.GetString(bytes, 0, bytesRec);

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
            return "";
        }

        public static string ReadwithIP(string ip, string message)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            return StartClient(ipAddress, message);
        }

        public static string ReadwithMAC(string mac, string message)
        {
            string _mac = mac.Replace(':', '-');
            string ip = IPMacMapper.FindIPFromMacAddress("00-02-f7-f2-e1-05");
            IPAddress ipAddress = IPAddress.Parse(ip);
            return StartClient(ipAddress, message);
        }

        public static string ReadwithMAC(string mac)
        {
            return ReadwithMAC(mac, "");
        }

        public static string ReadwithIP(string ip)
        {
            return ReadwithIP(ip, "");
        }
    }
}
