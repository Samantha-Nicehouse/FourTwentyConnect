using dk.via.ftc.businesslayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.Services
{
    public interface IStrainAPIService
    {
        public Task<IList<Strain>> GetAllStrainsAsync();

        public Task UpdateStrainsDatabaseAsync();
    }
}
