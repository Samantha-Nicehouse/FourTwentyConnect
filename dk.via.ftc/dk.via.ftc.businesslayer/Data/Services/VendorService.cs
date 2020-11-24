using System;
using System.Text;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SockNet.ClientSocket;


namespace dk.via.businesslayer.Data.Services
{
    public class VendorService : IVendorService
    {
        private SocketClient client = new SocketClient("localhost", 4012);
     

        public VendorService()
        {
            
        }

      
        
        
        public async Task AddVendorDbAsync(VendorAdmin vendorAdmin)
        {
            byte[] recData = null;
            string output = JsonConvert.SerializeObject(vendorAdmin);
        
            try
            {
                if (await client.Connect())
                {
              
                    await client.Send(output+"11");
                    recData = await client.ReceiveBytes();
                    
                   
                }
                Console.WriteLine("Received data: " + Encoding.UTF8.GetString(recData));
                client.Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception raised: " + e);
                client.Disconnect();
            }
            //...
            client.Disconnect();
        }
    }
}