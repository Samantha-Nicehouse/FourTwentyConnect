using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Persistence;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public class DispensaryService : IDispensaryService
    {
        private List<Dispensary> dispensaries;
        private List<DispensaryAdmin> dispensaryAdmins;
        private FTCDBContext fTCDBContext;

        public DispensaryService(FTCDBContext context)
        {
            fTCDBContext = context;
        }

        public async Task<IList<Dispensary>> GetDispensariesAsync()
        {
            List<Dispensary> dispensaries;
            dispensaries = fTCDBContext.Dispensaries.ToList();
            await fTCDBContext.SaveChangesAsync();

            return dispensaries;
        }

        
        public async Task AddDispensary(Dispensary dispensary)
        {

            await fTCDBContext.Dispensaries.AddAsync(dispensary);
            await  fTCDBContext.SaveChangesAsync();
            
        }
        
        public async Task AddDispensaryAdmin(DispensaryAdmin dispensaryAdmin)
        {

            await fTCDBContext.DispensaryAdmins.AddAsync(dispensaryAdmin);
            Console.WriteLine(dispensaryAdmin.DispensaryId);
            await  fTCDBContext.SaveChangesAsync();
            
        }
    }
}
