using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;

namespace dk.via.businesslayer.Data.Services
{
    public interface IVendorService
    {
        public Task AddVendorDbAsync(Vendor vendor);
    }
}