using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public interface IVendorService
    {
        public Task AddVendorAsync(Vendor vendor);
        public Task AddVendorVendorAdmin(VendorVendorAdmin vendorVendorAdmin);
    }
}