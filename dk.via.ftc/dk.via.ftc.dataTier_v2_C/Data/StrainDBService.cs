using dk.via.ftc.dataTier_v2_C.Models;
using dk.via.ftc.dataTier_v2_C.Persistence;
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
                Console.WriteLine(strain.StrainName + " ALREADY EXISTS, REPLACED WITH NEW");
            }
        }
        //get1
        public async Task<Strain> GetStrainByIDAsync(int id)
        {
            IQueryable<Strain> str = fTCDBContext.Strains.Where(e => e.StrainId.Equals(id));
            return str.First();
        }
        //getall

        public async Task<IList<Strain>> GetStrainsAsync()
        {
            return fTCDBContext.Strains.ToList();
        }
    }
}
