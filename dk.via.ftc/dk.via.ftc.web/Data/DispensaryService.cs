﻿using dk.via.ftc.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace dk.via.ftc.web.Data
{
    public class DispensaryService : IDispensaryService
    {
        private string uri = "https://localhost:44373/api/Dispensary";
        private readonly HttpClient client;
        public DispensaryService()
        {
            client = new HttpClient();
        }
        public async Task<bool> CheckLicense(string license)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/License/"+license);
            string message = await stringAsync;
            bool obj = JsonConvert.DeserializeObject<bool>(message);
            return obj;
        }

        public async Task AddDispensaryAsync(Dispensary dispensary)
        {
            string dispensaryAsJson = JsonConvert.SerializeObject(dispensary);
            Console.WriteLine(dispensaryAsJson);
            HttpContent content = new StringContent(dispensaryAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri, content);
        }

    }
}