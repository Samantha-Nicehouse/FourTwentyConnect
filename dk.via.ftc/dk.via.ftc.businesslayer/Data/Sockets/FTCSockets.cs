using dk.via.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Data.Sockets.SocketModels;
using dk.via.ftc.businesslayer.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SockNet.ServerSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.Sockets
{
    public class FTCSockets
    {
        IProductService _service;
        SocketServer socketServer;
        public FTCSockets(IProductService service)
        {
            _service = service;
            socketServer = new SocketServer();
            socketServer.InitializeSocketServer("127.0.0.1", 4012);
            socketServer.SetReaderBufferBytes(5120);
            socketServer.StartListening();
            Console.WriteLine("Socket Server Initialised");
            //Thread threadReceiveData = new Thread(new ThreadStart(recieveConnections));
            //threadReceiveData.IsBackground = true;
            //threadReceiveData.Start();
            Task.Run(()=> recieveConnections());
            Console.WriteLine("Socket Server Waiting For Connections");


        }
        public async Task recieveConnections()
        {
            Console.WriteLine("SOCKET SERVER: Waiting..");
            while (true)
            {
                await Task.Delay(3000);
                Console.WriteLine("SOCKET SERVER: Waiting..");
                if (socketServer.IsNewData())
                {
                    Console.WriteLine("Recieved Data");
                    IList<ProductStrain> list = await _service.GetProductsAllProductsAsync();

                    DrugRoot drugRoot = new DrugRoot(list.Count);
                    int counter = 0;
                    foreach(ProductStrain ps in list)
                    {
                        Drug prod1 = new Drug();
                        string indi = "";
                        foreach (string strI in ps.effects.medical)
                        {
                            indi += strI + ", ";
                        }
                        prod1.indications = indi.Substring(0, indi.Length-1);
                        prod1.productName = ps.ProductName;
                        prod1.strain = ps.strainname;
                        prod1.product_id = ps.ProductId;
                        drugRoot.drugs[counter] = prod1;
                        counter++;
                    }
                    string output = JsonConvert.SerializeObject(drugRoot);
                    Console.WriteLine("Json To Send:" + output);
                    var data = socketServer.GetData();
                    Console.WriteLine(data.Value);
                    byte[] bytes = Encoding.ASCII.GetBytes(output);
                    Console.WriteLine("Sending To Client: " + output);
                    socketServer.ResponseToClient(data.Key,bytes);
                }
            }
        }
    }

}
