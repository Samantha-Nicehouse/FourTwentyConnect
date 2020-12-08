using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C;
using dk.via.ftc.dataTier_v2_C.Persistence;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public class CountryService: ICountryService
    {
      
        private FTCDBContext fTCDBContext;

        
        public CountryService(FTCDBContext context)
        {
             fTCDBContext = context;
        }
        
        public async Task<IList<Country>> GetCountriesAsync()
        {
            List<Country> countries;
            countries = fTCDBContext.Countries.ToList();
            await fTCDBContext.SaveChangesAsync();

            return countries;
        }
    }
}