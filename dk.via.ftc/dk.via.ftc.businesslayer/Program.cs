using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SockNet.ClientSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace dk.via.businesslayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            CreateHostBuilder(args).Build().Run();
        }
        static async Task MainAsync(string[] args)
        {
            await SocketClient1();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
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
        public static async Task SocketClient1()
        {
            byte[] recData = null;
            SocketClient client = new SocketClient("127.0.0.1", 4012);
            try
            {
                if (await client.Connect())
                {
                    await client.Send("this is a test");
                    recData = await client.ReceiveBytes();
                }
                Console.WriteLine("Received data: " + Encoding.UTF8.GetString(recData));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception raised: " + e);
            }
            //...
            client.Disconnect();
        }

    }
}
