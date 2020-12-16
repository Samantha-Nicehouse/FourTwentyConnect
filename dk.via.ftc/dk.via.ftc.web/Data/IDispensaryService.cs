using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;

namespace dk.via.ftc.web.Data
{
    public interface IDispensaryService
    {
        public Task<bool> CheckLicense(string license);
        public Task AddDispensaryAsync(Dispensary dispensary);
        public Task<string> GetDispensaryLicense(string license);
        Task AddDispensaryAdminAsync(DispensaryAdmin aD);
    }
}