using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading;
using dk.via.ftc.businesslayer.Models.DTO;
using dk.via.ftc.businesslayer.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace dk.via.businesslayer.Data.Services
{
    public class ProductService : IProductService
    {
        private string uri = "https://localhost:44332/db";
        private string uri2 = "https://localhost:44332/db/Strains";
        private readonly HttpClient client = new HttpClient();
        private StrainContext sc;
        public ProductService(IServiceProvider serviceProvider)
        {
            sc = serviceProvider.GetRequiredService<StrainContext>();
        }
        public IList<Product> Products { get; set; }

        

        public async Task AddProductAsync(Product product)
        {
            //string productAsJson = JsonSerializer.Serialize(product);
            //HttpContent content = new StringContent(productJson.Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PutAsync(uri + "/Products", content);
            //Console.WriteLine(response.ToString());
        }
        public async Task<Strain> GetStrainByIDAsync(int id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri2 + "/Strain/" + id);
            string message = await stringAsync;
            Strain strain = System.Text.Json.JsonSerializer.Deserialize<Strain>(message);
            return strain;
        }

        public async Task <ProductStrain> GetProductAsyncByStrain(int strain_id)
      
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Product/"+strain_id);
            string message = await stringAsync;
            Product product= System.Text.Json.JsonSerializer.Deserialize<Product>(message);
            Strain strain = await GetStrainByIDAsync(strain_id);
            ProductStrain ps = new ProductStrain();
            ftc.businesslayer.Models.DTO.Effects ef = new ftc.businesslayer.Models.DTO.Effects();
            ef.medical = strain.Effects.First().Medical.ToList();
            ef.negative = strain.Effects.First().Negative.ToList();
            ef.positive = strain.Effects.First().Positive.ToList();
            ps.effects = ef;
            ps.flavors.Add("DisabledDueToRestrictions");
            ps.ProductId = product.ProductId;
            ps.id = strain.StrainId;
            ps.StrainId = strain.StrainId;
            ps.race = strain.Race;
            ps.strainname = strain.StrainName;
            ps.GrowType = product.GrowType;
            ps.Orderlines = product.Orderlines;
            ps.Unit = product.Unit;
            ps.Vendor = product.Vendor;
            ps.AvailableInventory = product.AvailableInventory;
            ps.IsAvailable = product.IsAvailable;
            ps.ProductName = product.ProductName;
            ps.ReservedInventory = product.ReservedInventory;
            ps.ThcContent = product.ThcContent;
            ps.VendorId = product.VendorId;
            return ps;
        }

        public async Task<IList<ProductStrain>> GetProductsAllProductsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Product/Products/All");
            string message = await stringAsync;
            IList<Product> results = JsonConvert.DeserializeObject < IList<Product>>(message);
            IList<ProductStrain> pss = new List<ProductStrain>();
            foreach (Product product in results)
            {
                StrainAPIObj strain = sc.GetStrainById(product.StrainId);
                ProductStrain ps = new ProductStrain();
                ps.effects = strain.effects;
                ps.flavors = strain.flavors;
                ps.ProductId = product.ProductId;
                ps.id = strain.id;
                ps.StrainId = strain.id;
                ps.race = strain.race;
                ps.strainname = strain.strainname;
                ps.GrowType = product.GrowType;
                ps.Orderlines = product.Orderlines;
                ps.Unit = product.Unit;
                ps.Vendor = product.Vendor;
                ps.AvailableInventory = product.AvailableInventory;
                ps.IsAvailable = product.IsAvailable;
                ps.ProductName = product.ProductName;
                ps.ReservedInventory = product.ReservedInventory;
                ps.ThcContent = product.ThcContent;
                ps.VendorId = product.VendorId;
                pss.Add(ps);
            }
            return pss;
        }
    }
}