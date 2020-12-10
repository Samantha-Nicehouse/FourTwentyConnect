using System;
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
        private string uri = "https://localhost:44332/db/Dispensary";
        private readonly HttpClient client;

        public DispensaryService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Dispensary>> GetDispensariesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Dispensary/All");
            string message = await stringAsync;
            IList<Dispensary> obj = JsonConvert.DeserializeObject<IList<Dispensary>>(message);
            return obj;
        }
        public async Task<DispensaryAdmin> GetDispensaryByUsername(string username)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Dispensary/"+username);
            string message = await stringAsync;
            DispensaryAdmin obj = JsonConvert.DeserializeObject<DispensaryAdmin>(message);
            return obj;
        }
        
        public async Task<bool> ValidateDispensaryAdmin(string username, string password)
        {
            DispensaryAdmin da = await GetDispensaryByUsername(username);
            if (da == null)
            {
                return false;
            }
            if (da.Pass.Equals(password))
            {
                return true;
            }
            return false;
        }
        public async Task AddDispensaryAsync(Dispensary dispensary)
        {
            string dispensaryAsJson = JsonConvert.SerializeObject(dispensary);
            
            HttpContent content = new StringContent(dispensaryAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri + "/Dispensary", content);
        }
        
        public async Task AddDispensaryAdminAsync(DispensaryAdmin dispensaryAdmin)
        {
            string dispensaryAdminAsJson = JsonConvert.SerializeObject(dispensaryAdmin);
            
            HttpContent content = new StringContent(dispensaryAdminAsJson,
                Encoding.UTF8,
                "application/json");
            Console.WriteLine(dispensaryAdminAsJson);
            await client.PutAsync(uri + "/DispensaryAdmin", content);
        }
    }
}