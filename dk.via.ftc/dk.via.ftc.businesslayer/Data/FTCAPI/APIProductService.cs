using dk.via.ftc.businesslayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.FTCAPI
{
    public class APIProductService : IAPIProductService
    {
        private string uri = "https://localhost:44332/db/Product";
        private readonly HttpClient client;
        public APIProductService()
        {
            client = new HttpClient();
        }
        public async Task AddProductAsync(Product product)
        {
            string stringAsJson = JsonSerializer.Serialize(product);
            HttpContent content = new StringContent(stringAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Put", content);
            Console.WriteLine(stringAsJson + " Sent To Data Layer");
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Products/All");
            string message = await stringAsync;
            IList<Product> products = System.Text.Json.JsonSerializer.Deserialize<IList<Product>>(message);
            return products;
        }

        public async Task<IList<Product>> GetProductsAsyncByStrain(int strain_id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Strain/"+strain_id);
            string message = await stringAsync;
            IList<Product> products = System.Text.Json.JsonSerializer.Deserialize<IList<Product>>(message);
            return products;
        }

        public async Task UpdateProduct(Product product)
        {
            string stringAsJson = JsonSerializer.Serialize(product);
            HttpContent content = new StringContent(stringAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Patch", content);
            Console.WriteLine(stringAsJson + " Sent To Data Layer");
        }
    }
}
