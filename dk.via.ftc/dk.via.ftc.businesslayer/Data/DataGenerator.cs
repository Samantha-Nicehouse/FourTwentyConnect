using dk.via.ftc.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data
{
    public class DataGenerator
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StrainContext(
                serviceProvider.GetRequiredService<DbContextOptions<StrainContext>>()))
            {
                // Look for any board games.
                /*if (context.Strains.Any())
                {
                    return;   // Data was already seeded
                }*/
                StrainAPIService sa = new StrainAPIService();
                /*List<Strain> strains = await sa.GetAllStrainsAsync();
                foreach (Strain strain in strains)
                {
                    string strainAsJson = System.Text.Json.JsonSerializer.Serialize(strain);
                    Debug.WriteLine("Strain:" + strain.StrainName + "Updated");
                }*/
               await sa.UpdateStrainsDatabaseAsync();
                //context.SaveChanges();
            }
        }
    }
}
