using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
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
        private string uri = "https://localhost:44301/db";
        private string uriDb = "https://localhost:44301/db";
        private readonly HttpClient client;

        public StrainAPIService()
        {
            client = new HttpClient();
        }
        public async Task<IList<Strain>> GetAllStrainsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Adults");
            string message = await stringAsync;
            List<Strain> result = JsonSerializer.Deserialize<List<Strain>>(message);
            return result;
        }

        public async Task UpdateStrainsDatabaseAsync() {
            IList<Strain> strains = await GetAllStrainsAsync();
            foreach(Strain strain in strains)
            {
                string strainAsJson = JsonSerializer.Serialize(strain);
                HttpContent content = new StringContent(strainAsJson,
                Encoding.UTF8,
                "application/json");
                await client.PutAsync(uri + "/Strain", content);
                Debug.WriteLine("Strain:" + strain.StrainName+"Updated");
            }
        }

    }
}
