using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;


namespace dk.via.ftc.web.Data
{
    public interface IVendorService
    {
        Task AddVendorAsync(Vendor vendor);
        //  Task AddVendorAdminAsync(VendorAdmin vendorAdmin);

        // Task AddVendorVendorAdminAsync(VendorVendorAdmin vendorVendorAdmin);
        public Task<string> GetVendorByLicense(string license);
       
        public Task AddVendorAdminAsync(VendorAdmin vendorAdmin);
    }
}