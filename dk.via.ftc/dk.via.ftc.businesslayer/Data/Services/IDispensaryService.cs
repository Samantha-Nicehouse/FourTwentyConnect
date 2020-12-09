using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;

namespace dk.via.ftc.businesslayer.Data.Services
{
    public interface IDispensaryService
    {
         Task<IList<Dispensary>> GetDispensariesAsync();
         Task AddDispensaryAsync(Dispensary dispensary);
    }
}