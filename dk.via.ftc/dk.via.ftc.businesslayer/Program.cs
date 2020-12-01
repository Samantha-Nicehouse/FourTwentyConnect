using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SockNet.ClientSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CLR.Entity;
using dk.via.businesslayer;
using dk.via.ftc.businesslayer.Models;
using FlitBit.Json;
using Newtonsoft.Json;
using dk.via.ftc.businesslayer.Persistence;
using Microsoft.Extensions.DependencyInjection;
using dk.via.ftc.businesslayer.Data;
using dk.via.ftc.businesslayer.Data.Services;
using Microsoft.AspNetCore;

namespace dk.via.businesslayer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<StrainContext>();
                    await DataGenerator.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
        static async Task MainAsync(string[] args)
        {
            //await SocketClientJson();
            
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        public static void SocketClient()
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1", 4012);
            NetworkStream stream = tcpClient.GetStream();
            TextWriter tw = new StreamWriter(stream, Encoding.UTF8);
            JsonWriter writer = new JsonTextWriter(tw);

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

        public static async Task SocketClientJson()
        {
            byte[] recData = null;
            Vendor vendor = new Vendor();
            vendor.VendorName = "Name";
            vendor.vendorLicense = "12345678";
            vendor.City = "City";
            vendor.Country = "Country";
            vendor.stateProvince = "State";

            string output = JsonConvert.SerializeObject(vendor);
            SocketClient client = new SocketClient("localhost", 4012);
            try
            {
                if (await client.Connect())
                {

                    await client.Send(output);
                    recData = await client.ReceiveBytes();
                    Console.WriteLine(recData);
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
