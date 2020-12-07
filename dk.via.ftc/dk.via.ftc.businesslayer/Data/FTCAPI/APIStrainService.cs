using dk.via.ftc.businesslayer.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models.DTO;

namespace dk.via.ftc.businesslayer.Data.FTCAPI
{
    public class APIStrainService : IAPIStrainService
    {
        private string uri = "https://localhost:44332/db/Strains";
        private readonly HttpClient client;
        public APIStrainService()
        {
            client = new HttpClient();
        }

        //add
        public async Task AddStrainAsync(StrainAPIObj strain)
        {
            string stringAsJson = JsonSerializer.Serialize(strain);
            HttpContent content = new StringContent(stringAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Put", content);
            Console.WriteLine(stringAsJson + " Sent To Data Layer");
        }
        //get1
        public async Task<Strain> GetStrainByIDAsync(int id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Strain/" + id);
            string message = await stringAsync;
            Strain strain = System.Text.Json.JsonSerializer.Deserialize<Strain>(message);
            return strain;
        }
        //getall

        public async Task<IList<Strain>> GetStrainsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/All");
            string message = await stringAsync;
            IList<Strain> strain = System.Text.Json.JsonSerializer.Deserialize<IList<Strain>>(message);
            return strain;
        }
    }
}
