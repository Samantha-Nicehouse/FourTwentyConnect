using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Newtonsoft.Json;


namespace dk.via.ftc.businesslayer.Data.Services
{
    public class DispensaryService : IDispensaryService
    {
        private string uri = "https://localhost:44332/db/Dispensary/";
        private readonly HttpClient client;

        public DispensaryService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Dispensary>> GetDispensariesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/All");
            string message = await stringAsync;
            IList<Dispensary> obj = JsonConvert.DeserializeObject<IList<Dispensary>>(message);
            return obj;
        }
        public async Task AddDispensaryAsync(Dispensary dispensary)
        {
            string dispensaryAsJson = JsonConvert.SerializeObject(dispensary);
            
            HttpContent content = new StringContent(dispensaryAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Dispensary", content);
        }
    }
}