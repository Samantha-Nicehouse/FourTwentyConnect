using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
            string vendorAsJson = JsonSerializer.Serialize(vendorAdmin);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/VendorAdmin", content);
        }
        
        public async Task AddVendorVendorAdminAsync(VendorVendorAdmin vvA)
        {
            string vendorAsJson = JsonSerializer.Serialize(vvA);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Vendor", content);
        }
        
    }
}