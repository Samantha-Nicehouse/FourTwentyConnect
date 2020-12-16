using dk.via.ftc.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Vendor = dk.via.ftc.businesslayer.Models.Vendor;
using VendorAdmin = dk.via.ftc.businesslayer.Models.VendorAdmin;

namespace dk.via.ftc.web.Data
{
    public class VendorService: IVendorService
    {
        
    
        private string uri = "https://localhost:44373/api";
        private readonly HttpClient client;
        public VendorService()
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
            await client.PutAsync(uri + "/Vendor/VendorAdmin", content);
        }
      /*  public async Task AddVendorVendorAdminAsync(VendorVendorAdmin vvA)
        {
            string vendorAsJson = JsonSerializer.Serialize(vvA);
            Console.WriteLine(vendorAsJson);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Vendor", content);
        }*/

      public async Task<string> GetVendorByLicense(string license)
      {
          Task<string> stringAsync = client.GetStringAsync(uri + "/Vendor/VendorLic/"+license);
          string message = await stringAsync;
          return message;
      }
       
        
}
}

