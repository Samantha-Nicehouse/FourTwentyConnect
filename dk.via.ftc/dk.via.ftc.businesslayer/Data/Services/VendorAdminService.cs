using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SockNet.ClientSocket;
// DO NOT ERASE WE NEED THIS FOR THE PRESCRIBER APPLICATION
namespace dk.via.businesslayer.Data.Services
{
    public class VendorAdminService
    
    
    {
        private SocketClient client = new SocketClient("localhost", 4012);
        
        /*public async Task AddVendorAdminDbAsync(VendorAdmin vendorAdmin)
        {
            byte[] recData = null;
            string output = JsonConvert.SerializeObject(vendorAdmin);
             try
             {
                 if (await client.Connect())
                 {
                          
                     await client.Send(output);
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
             
                    }*/
                    
                }
           
    }
