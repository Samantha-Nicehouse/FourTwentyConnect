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


        private string uri = "https://localhost:44332/db/Countries";
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