using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dk.via.ftc.web.Data
{
    public class UserManager : IUserManager
    {
        private string uri = "https://localhost:44373/api";
        private readonly HttpClient client;
        private string username;

        public UserManager()
        {
            client = new HttpClient();
        }
        public async Task<User> ValidateUser(string userName, string passWord)
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Dispensary/DAValidate/"+userName+"/"+passWord);
            string message = await stringAsync;
            Console.WriteLine(message);
            if (message == "true")
            {
                Task<string> stringAsync1 = client.GetStringAsync(uri + "/Dispensary/Dispensary/" + userName);
                string message1 = await stringAsync1;
                Console.WriteLine(message1);
                DispensaryAdmin da = JsonConvert.DeserializeObject<DispensaryAdmin>(message1);
                User user = new User();
                user.Password = da.Pass;
                user.Role = "DispensaryAdmin";
                user.SecurityLevel = 2;
                user.UserName = da.Username;
                return user;
            }
            else
            {
                throw new Exception("Username or Password do not match with our records");
            }
        }
        public async Task userNameInUseAsync(string username)
        {
            HttpContent content = new StringContent(username,
                Encoding.UTF8,
                "application/json");
        }

    }
}

