using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public interface IDispensaryService
    {
        public Task<DispensaryAdmin> GetDispensaryByUsername(string username);
        public Task AddDispensary(Dispensary dispensary);
        public Task<IList<Dispensary>> GetDispensariesAsync();
        public Task AddDispensaryAdmin(DispensaryAdmin dispensaryAdmin);
    }
}