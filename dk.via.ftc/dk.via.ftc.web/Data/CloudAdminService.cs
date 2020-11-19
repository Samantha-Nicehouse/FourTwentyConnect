using dk.via.ftc.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Data
{
    public class CloudAdminService : IAdminService
    {
        private string uri = "https://localhost:44373/api";
        private readonly HttpClient client;
        public CloudAdminService()
        {
            client = new HttpClient();
        }
        public async Task AddVendorAsync(Vendor vendor)
        {
            string vendorAsJson = JsonSerializer.Serialize(vendor);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Vendor", content);
        }
        public async Task AddVendorAdminAsync(VendorAdmin vendorAdmin)
        {
            string vendorAsJson = JsonSerializer.Serialize(vendorAdmin);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/VendorAdmins", content);
        }
    }
}
