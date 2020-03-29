using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Begin! IP: 127.0.0.1 Port: 27000");
            //UDPSocket s = new UDPSocket();
            //s.Server("127.0.0.1", 27000);
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 27000);
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("Waiting for a client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            data = newsock.Receive(ref sender);

            Console.WriteLine("Message received from {0}:", sender.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            string welcome = "Welcome to my test server";
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.Send(data, data.Length, sender);

            while (true) {
                data = newsock.Receive(ref sender);

                Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
                newsock.Send(data, data.Length, sender);
            }

        }
    }
}
