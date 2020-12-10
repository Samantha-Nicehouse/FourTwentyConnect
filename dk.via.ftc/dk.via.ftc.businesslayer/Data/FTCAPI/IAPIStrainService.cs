using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.FTCAPI
{
    public interface IAPIStrainService
    {
        public Task AddStrainAsync(StrainAPIObj strain);
        public Task AddStrainsAsync(List<StrainAPIObj> strain);
        public Task<Strain> GetStrainByIDAsync(int id);
        public Task<IList<Strain>> GetStrainsAsync();
    }
}
