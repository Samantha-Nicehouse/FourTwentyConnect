using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketClient();
        }
        public static void SocketClient()
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1", 4012);
            NetworkStream stream = tcpClient.GetStream();

            // send to server
            string message = "Hello from client";
            byte[] dataToServer = Encoding.ASCII.GetBytes(message);
            stream.Write(dataToServer, 0, dataToServer.Length);

            // read response
            byte[] fromServer = new byte[1024];
            int bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            tcpClient.Close();
        }
    }
}
