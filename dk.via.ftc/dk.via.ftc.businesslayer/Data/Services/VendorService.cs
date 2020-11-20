using System;
using System.Text;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Newtonsoft.Json;
using SockNet.ClientSocket;

namespace dk.via.businesslayer.Data.Services
{
    public class VendorService : IVendorService
    {
        private SocketClient client = new SocketClient("localhost", 4012);
        public VendorService()
        {
            
        }

        public async Task AddVendorDbAsync(Vendor vendor)
        {
            byte[] recData = null;
            string output = JsonConvert.SerializeObject(vendor);
        
            try
            {
                if (await client.Connect())
                {
              
                    await client.Send(output);
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