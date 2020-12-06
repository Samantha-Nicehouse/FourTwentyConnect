using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
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
        private string uri = "https://strainapi.evanbusse.com/03N4JvC/strains/search/";
        private string uriDb = "https://localhost:44301/db";
        private readonly HttpClient client;

        public StrainAPIService()
        {
            client = new HttpClient();
        }
        public async Task<List<StrainAPIObj>> GetAllStrainsAsync()
        {
            List<Task> listOfTasks = new List<Task>();
            Task<string> stringAsync = client.GetStringAsync(uri + "all");
            string message;
            message = await stringAsync;
            List<StrainAPIObj> strains = new List<StrainAPIObj>();

            string messageTrim = message.Substring(1, message.Length - 1); // Remove {} wrap
            for (int i = messageTrim.Length; i > 10;)

            {
                string strainName = messageTrim.Substring(0, messageTrim.IndexOf(":{")).Trim('"'); // Gets the name of strain
                string strainNameToremove = messageTrim.Substring(0, messageTrim.IndexOf(":{"));
                string strainNameCut = messageTrim.Replace(strainNameToremove + ":", ""); // removes name of strain
                string strainCut;
                if (strainNameCut.IndexOf("},") > 0)
                {
                    strainCut = strainNameCut.Substring(0, strainNameCut.IndexOf("},") + 1);
                    string strainRemove = strainNameCut.Replace(strainCut + ",", "");
                    StrainAPIObj strain = JsonSerializer.Deserialize<StrainAPIObj>(strainCut);
                    strain.strainname = strainName;
                    strains.Add(strain);
                    messageTrim = strainRemove;
                    i = messageTrim.Length;
                }
                else
                {
                    strainCut = strainNameCut.Substring(0, strainNameCut.IndexOf("}}}") + 2);
                    string strainRemove = strainNameCut.Replace(strainCut + ",", "");
                    StrainAPIObj strain = JsonSerializer.Deserialize<StrainAPIObj>(strainCut);
                    strain.strainname = strainName;
                    strains.Add(strain);
                    Console.WriteLine(strainName);
                    i = 0;
                }
                listOfTasks.Add(ExecuteTask(strainName + " Added"));



            }
            await Task.WhenAll(listOfTasks);
            return strains;
        }

        public async Task UpdateStrainsDatabaseAsync() {
            
        }
        public static Task ExecuteTask(string Item)
        {
            Console.WriteLine($"TaskExecuted: {Item}");
            return Task.CompletedTask;
        }
    }
}
