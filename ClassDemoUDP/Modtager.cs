using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClassDemoUDP
{
    internal class Modtager
    {
        private int PORT;

        public Modtager(int port)
        {
            this.PORT = port;
        }

        public void Start()
        {
            using (UdpClient client = new UdpClient(PORT))
            {
                IPEndPoint AfsenderEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiver = client.Receive(ref AfsenderEP);

                Console.WriteLine("Modtaget fra " + AfsenderEP.Address + " " + AfsenderEP.Port);
                string str = Encoding.ASCII.GetString(receiver);
                Console.WriteLine("Modtaget \n" + str);

                //ekko tilbage til afsender
                client.Send(receiver, receiver.Length, AfsenderEP);

            }
        }
    }
}