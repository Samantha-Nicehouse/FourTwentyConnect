using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dk.via.ftc.web.Data
{
    public class UserManager
    {
        private string uri = "https://localhost:44373/api";
        private readonly HttpClient client;
        private string username;

        public UserManager()
        {
            client = new HttpClient();
        }

     public async Task userNameInUseAsync(string username)
        {
            HttpContent content = new StringContent(username,
                Encoding.UTF8,
                "application/json");
        }
    }
}

