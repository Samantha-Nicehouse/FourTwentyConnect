using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.businesslayer.Data.Services
{
    public interface IVendorService_v2
    {
        public Task AddVendorAsync(Vendor vendor);
        public Task AddVendorAdminAsync(VendorAdmin vendorAdmin);
        public Task<ActionResult> AddVendorVendorAdminAsync(VendorVendorAdmin vendorVendorAdmin);
    }
}