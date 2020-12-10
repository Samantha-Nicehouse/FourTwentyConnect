using dk.via.ftc.businesslayer.Models.DTO;
using dk.via.ftc.dataTier_v2_C.Models;
using dk.via.ftc.dataTier_v2_C.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public class StrainDBService : IStrainDBService
    {
        private FTCDBContext fTCDBContext;

        public StrainDBService(FTCDBContext context)
        {
            fTCDBContext = context;
        }

        //add
        public async Task AddStrainAsync(Strain strain)
        {
            if (!fTCDBContext.Strains.Where(e => e.StrainId.Equals(strain.StrainId)).Any())
            {
                fTCDBContext.Strains.Add(strain);
                await fTCDBContext.SaveChangesAsync();

                Console.WriteLine(strain.StrainName + " Added To DB");
            }
            else
            {
                fTCDBContext.Strains.Remove(fTCDBContext.Strains.Where(e => e.StrainId.Equals(strain.StrainId)).ToList().FirstOrDefault());
                fTCDBContext.Effects.Remove(fTCDBContext.Effects.Where(e => e.StrainId.Equals(strain.StrainId)).ToList().FirstOrDefault());
                string straJson = JsonConvert.SerializeObject(strain);
                Console.WriteLine(straJson + " ALREADY EXISTS, REPLACED WITH NEW");
                fTCDBContext.Strains.Add(strain);
                await fTCDBContext.SaveChangesAsync();
            }
        }

        public async Task AddStrainsAsync(List<StrainAPIObj> strains)
        {
            foreach (StrainAPIObj strainapi in strains)
            {
                Strain strain = new Strain();
                Effect effect = new Effect();
                strain.Race = strainapi.race;
                strain.StrainName = strainapi.strainname;
                strain.StrainId = strainapi.id;
                effect.StrainId = strain.StrainId;
                if (strainapi.effects != null)
                {
                    if (strainapi.effects.medical != null)
                    {
                        effect.Medical = strainapi.effects.medical.ToArray();
                    }
                    if (strainapi.effects.negative != null)
                    {
                        effect.Negative = strainapi.effects.negative.ToArray();
                    }
                    if (strainapi.effects.positive != null)
                    {
                        effect.Positive = strainapi.effects.positive.ToArray();
                    }
                }
                strain.Effects.Add(effect);
                if (!fTCDBContext.Strains.Where(e => e.StrainId.Equals(strain.StrainId)).Any())
                {
                    fTCDBContext.Strains.Add(strain);

                    Console.WriteLine(strain.StrainName + " Added To DB");
                }
                else
                {
                    fTCDBContext.Strains.Remove(fTCDBContext.Strains.Where(e => e.StrainId.Equals(strain.StrainId)).ToList().FirstOrDefault());
                    string straJson = JsonConvert.SerializeObject(strain);
                    Console.WriteLine(straJson + " ALREADY EXISTS, REPLACED WITH NEW");
                    fTCDBContext.Strains.Add(strain);
                    
                }
                await fTCDBContext.SaveChangesAsync();
            }
            
        }
        //get1
        public async Task<Strain> GetStrainByIDAsync(int id)
        {
            IQueryable<Strain> str = fTCDBContext.Strains.Where(e => e.StrainId.Equals(id));
            IQueryable<Effect> effect = fTCDBContext.Effects.Where(e => e.StrainId.Equals(id));
            Strain strain = str.First();
            strain.Effects.Add(effect.First());

            return strain;
        }
        //getall

        public async Task<IList<Strain>> GetStrainsAsync()
        {
            IList<Strain> strains = fTCDBContext.Strains.ToList();
            foreach(Strain str in strains)
            {
                Effect effect = fTCDBContext.Effects.Where(e => e.StrainId.Equals(str.StrainId)).FirstOrDefault();
                str.Effects.Add(effect);
            }
            return strains;
        }
    }
}
