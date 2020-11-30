using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.Services
{
    public class StrainAPIService : IStrainAPIService
    {
        private string uri = "https://strainapi.evanbusse.com/03N4JvC/strains/search/";
        private string uriDb = "https://localhost:44301/db";
        private readonly HttpClient client;

        public StrainAPIService()
        {
            client = new HttpClient();
        }
        public async Task<IList<Strain>> GetAllStrainsAsync()
        {
          
            Task<string> stringAsync = client.GetStringAsync(uri + "all");
            string message = await stringAsync;
            List<Strain> result = System.Text.Json.JsonSerializer.Deserialize<List<Strain>>(message);
            Debug.WriteLine(result);
            Debug.WriteLine(message);
            return result;
        }

        public async Task UpdateStrainsDatabaseAsync() {
            IList<Strain> strains = await GetAllStrainsAsync();
            foreach(Strain strain in strains)
            {
                string strainAsJson = System.Text.Json.JsonSerializer.Serialize(strain);
                HttpContent content = new StringContent(strainAsJson,
                Encoding.UTF8,
                "application/json");
                //await client.PutAsync(uriDb + "/Strain", content);
                Debug.WriteLine("Strain:" + strain.StrainName+"Updated");
            }
        }

    }
}
