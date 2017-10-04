using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace UDPSender
{
    internal class sender
    {
        private readonly int PORT;
        public sender(int port)
        {
            PORT = port;
        }


        public void Start()
        {
            using (UdpClient client = new UdpClient())
            {
                IPEndPoint ModtagerEP = new IPEndPoint(IPAddress.Loopback, PORT);
                string str = "Peter";
                byte[] buffer = Encoding.ASCII.GetBytes(str);

                client.Send(buffer, buffer.Length, ModtagerEP);




            }
        }
    }
}