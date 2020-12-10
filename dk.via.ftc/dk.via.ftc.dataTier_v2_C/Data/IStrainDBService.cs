using dk.via.ftc.businesslayer.Models.DTO;
using dk.via.ftc.dataTier_v2_C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public interface IStrainDBService
    {
        public Task AddStrainAsync(Strain strain);
        public Task AddStrainsAsync(List<StrainAPIObj> strains);
        public Task<Strain> GetStrainByIDAsync(int id);
        public Task<IList<Strain>> GetStrainsAsync();
    }
}
