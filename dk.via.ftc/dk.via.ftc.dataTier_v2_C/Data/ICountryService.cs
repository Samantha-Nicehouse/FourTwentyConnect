using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public interface ICountryService
    {
        public Task<IList<Country>> GetCountriesAsync();
    }
}