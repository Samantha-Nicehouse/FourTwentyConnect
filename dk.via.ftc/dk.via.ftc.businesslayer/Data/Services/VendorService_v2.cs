using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Data;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.businesslayer.Data.Services
{
    public class VendorService_v2 : IVendorService_v2
    {
        private string uri = "https://localhost:44332/db";
        private readonly HttpClient client;

        public VendorService_v2()
        {
            client = new HttpClient();
        }

        public async Task AddVendorAdminAsync(VendorAdmin vendorAdmin)
        {
            vendorAdmin.Pass = FTCEncrypt.EncryptString(vendorAdmin.Pass);
            string vendorAsJson = JsonSerializer.Serialize(vendorAdmin);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Vendor/VendorAdmin", content);
        }

        
        public async Task<string> GetVendorByLicense(string license)
        {
            string stringAsync = await client.GetStringAsync(uri + "/Vendor/License/" + license);
            return stringAsync;
        }
        public async Task AddVendorAsync(Vendor vendor)
        {
            string vendorAsJson = JsonSerializer.Serialize(vendor);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Vendor/Vendor", content);
        }
    }
}
/*   public async Task AddVendorVendorAdminAsync(VendorVendorAdmin vvA)
   {
       string vendorAsJson = JsonSerializer.Serialize(vvA);
       HttpContent content = new StringContent(vendorAsJson,
           Encoding.UTF8,
           "application/json");
       await client.PutAsync(uri + "/Vendor", content);
   }
   
}
}*/