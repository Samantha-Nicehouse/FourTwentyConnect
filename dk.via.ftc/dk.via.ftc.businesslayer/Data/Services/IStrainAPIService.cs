using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.Services
{
    public interface IStrainAPIService
    {
        public Task<List<StrainAPIObj>> GetAllStrainsAsync();

        public Task UpdateStrainsDatabaseAsync();
    }
}
