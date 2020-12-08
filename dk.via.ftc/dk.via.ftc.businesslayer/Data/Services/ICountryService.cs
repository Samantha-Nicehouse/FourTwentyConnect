using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;

namespace dk.via.ftc.businesslayer.Data.Services
{
    public interface ICountryService
    {
        public Task<IList<Country>> GetCountriesAsync();
    }
}