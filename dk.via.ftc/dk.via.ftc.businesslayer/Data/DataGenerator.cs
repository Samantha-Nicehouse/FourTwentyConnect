using dk.via.ftc.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
using dk.via.ftc.businesslayer.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data
{
    public class DataGenerator
    {
        public async static Task Initialize(StrainContext sc)
        {
                StrainAPIService sa = new StrainAPIService();
                List<StrainAPIObj> strains = await sa.GetAllStrainsAsync();
                foreach (StrainAPIObj strain in strains)
                {
                    sc.Strains.Add(strain);
                }
            Console.WriteLine("DataGeneratorOut: "+sc.Strains.Count);
        }
    }
}
