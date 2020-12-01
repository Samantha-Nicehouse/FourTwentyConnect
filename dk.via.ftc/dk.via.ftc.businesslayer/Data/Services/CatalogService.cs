using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using dk.via.ftc.businesslayer.Models;


namespace dk.via.businesslayer.Data.Services
{
    public class CatalogService: ICatalogService
    {
        private string uri = "https://localhost:44301/db";
        private readonly HttpClient client = new HttpClient();
            
        public IList<Product> Products { get; private set; }
        public IList<Vendor> Vendors { get; private set; }
        public IList<Strain> Strains { get; private set; }
    }
    
    public async Task AddCatalogItemAsync(Product product){
     string productJson = JsonSerializer.Serialize(product);
    }
}