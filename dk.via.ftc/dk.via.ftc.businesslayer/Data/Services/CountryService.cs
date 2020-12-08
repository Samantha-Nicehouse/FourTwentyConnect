using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
using Newtonsoft.Json;

namespace dk.via.ftc.businesslayer.Data.Services
{
    public class CountryService: ICountryService
    {
        /*
          public class ProductService : IProductService
    {
        private string uri = "https://localhost:44332/db";
        private readonly HttpClient client = new HttpClient();
        private StrainContext sc;
        public ProductService(IServiceProvider serviceProvider)
        {
            sc = serviceProvider.GetRequiredService<StrainContext>();
        }
        public IList<Product> Products { get; set; }

         */


        private string uri = "https://localhost:44332/db/Countries/";
        private readonly HttpClient client = new HttpClient();
        public async Task<IList<Country>> GetCountriesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/All");
            string message = await stringAsync;
            IList<Country> obj = JsonConvert.DeserializeObject<IList<Country>>(message);
            return obj;
        }

    }
}