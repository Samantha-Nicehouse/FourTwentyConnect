﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading;

namespace dk.via.businesslayer.Data.Services
{
    public class ProductService
    {
        private string uri = "https://localhost:44301/db";
        private readonly HttpClient client;

        public IList<Product> Products { get; set; }

        public ProductService()
        {
            client = new HttpClient();
        }
        
        /*
         * public async Task AddVendorAsync(Vendor vendor)
        {
            string vendorAsJson = JsonSerializer.Serialize(vendor);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Vendor", content);
        }
         */

        public async Task AddProductAsync(Product product)
        {
            //string productAsJson = JsonSerializer.Serialize(product);
            //HttpContent content = new StringContent(productJson.Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PutAsync(uri + "/Products", content);
            //Console.WriteLine(response.ToString());
        }
        
        

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Products");
            string message = await stringAsync;
<<<<<<< Updated upstream
            List<Product> result = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(message);
            return result;
=======
            Product product= System.Text.Json.JsonSerializer.Deserialize<Product>(message);
            StrainAPIObj strain = sc.GetStrainById(product.StrainId).strain;
            ProductStrain ps = new ProductStrain();
            ps.strain = strain;
            ps.ProductId = product.ProductId;
            ps.GrowType = product.GrowType;
            ps.IsAvailable = product.IsAvailable;
            ps.Orderlines = product.Orderlines;
            ps.ProductName = product.ProductName;
            ps.ReservedInventory = product.ReservedInventory;
            ps.ThcContent = product.ThcContent;
            ps.StrainId = product.StrainId;
            return ps;
>>>>>>> Stashed changes
        }
        
        public async Task <Product> GetProductAsyncByStrain(int strain_id)
      
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Products/"+strain_id);
            string message = await stringAsync;
<<<<<<< Updated upstream
            Product product= System.Text.Json.JsonSerializer.Deserialize<Product>(message);
            return product;
=======
            IList<Product> results = System.Text.Json.JsonSerializer.Deserialize<IList<Product>>(message);
            IList<ProductStrain> pss = new List<ProductStrain>();
            foreach (Product product in results)
            {
                StrainAPIObj strain = sc.GetStrainById(product.StrainId).strain;
                ProductStrain ps = new ProductStrain();
                ps.strain = strain;
                ps.ProductId = product.ProductId;
                ps.GrowType = product.GrowType;
                ps.IsAvailable = product.IsAvailable;
                ps.Orderlines = product.Orderlines;
                ps.ProductName = product.ProductName;
                ps.ReservedInventory = product.ReservedInventory;
                ps.ThcContent = product.ThcContent;
                pss.Add(ps);
            }
            Console.WriteLine(pss);
            return pss;
>>>>>>> Stashed changes
        }
    }
}