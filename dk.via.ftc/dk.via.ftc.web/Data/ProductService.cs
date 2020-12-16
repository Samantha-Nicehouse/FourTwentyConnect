using dk.via.ftc.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace dk.via.ftc.web.Data
{
    public class ProductService : IProductService
    {
        private string uri = "https://localhost:44373/api";
        private readonly HttpClient client;
        public ProductService()
        {
            client = new HttpClient();
        }
        public async Task<IList<ProductStrain>> GetProductsAllProductsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Product");
            string message = await stringAsync;
            Console.WriteLine(message);
            List<ProductStrain> results = JsonConvert.DeserializeObject<List<ProductStrain>>(message);
            return results;
        }

    }
}