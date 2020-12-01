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
            /*Task<string> stringAsync = client.GetStringAsync(uri + "all");
            string message = await stringAsync;
            
            return result;*/
            return null;
        }

        public async Task UpdateStrainsDatabaseAsync() {
            List<Task> listOfTasks = new List<Task>();
            Task<string> stringAsync = client.GetStringAsync(uri + "all");
            string message;
            message = await stringAsync;
            List<StrainAPIObj> strains = new List<StrainAPIObj>();

            string messageTrim = message.Substring(1, message.Length-1);
            for (int i = messageTrim.Length; i > 10;)
            
            {
                    string strainName = messageTrim.Substring(0, messageTrim.IndexOf(":{"));
                string strainNameCut = messageTrim.Replace(strainName + ":", "");
                string strainCut;
                if (strainNameCut.IndexOf("},") > 0)
                {
                    strainCut = strainNameCut.Substring(0, strainNameCut.IndexOf("},") + 1);
                    string strainRemove = strainNameCut.Replace(strainCut + ",", "");
                    StrainAPIObj strain = JsonSerializer.Deserialize<StrainAPIObj>(strainCut);
                    strain.strainname = strainName;
                    strains.Add(strain);
                    Console.WriteLine(strainName);
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
                listOfTasks.Add(ExecuteTask("" + i));



            }
            await Task.WhenAll(listOfTasks);
            Console.WriteLine("Strain Count" + strains.Count);
            /*foreach(Strain strain in strains)
            {
                string strainAsJson = System.Text.Json.JsonSerializer.Serialize(strain);
                HttpContent content = new StringContent(strainAsJson,
                Encoding.UTF8,
                "application/json");
                //await client.PutAsync(uriDb + "/Strain", content);
                Debug.WriteLine("Strain:" + strain.StrainName+"Updated");
            }*/
        }
        public static Task ExecuteTask(string Item)
        {
            Task.Delay(10);
            Console.WriteLine($"TaskExecuted: {Item}");
            return Task.CompletedTask;
        }
    }
}
