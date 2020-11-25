using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.dataTier_v2_C.Persistence;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public class VendorService : IVendorService
    {
        public async Task AddVendorAsync(Vendor vendor)
        {
            using (FTCDBContext ftcdbContext = new FTCDBContext())
            {
                await ftcdbContext.Vendors.AddAsync(vendor);
                await ftcdbContext.SaveChangesAsync();
            }
        }
        public async Task<ActionResult> AddVendorVendorAdmin(VendorVendorAdmin vvA)
        {
            Vendor vendor = new Vendor();
            vendor.City = vvA.vendor.City;
            vendor.Country = vvA.vendor.Country;
            vendor.stateProvince = vvA.vendor.stateProvince;
            vendor.vendorLicense = vvA.vendor.vendorLicense;
            vendor.VendorName = vvA.vendor.VendorName;
            VendorAdmin vendorAdmin = new VendorAdmin();
            vendorAdmin.Email = vvA.vendorAdmin.Email;
            vendorAdmin.Pass = vvA.vendorAdmin.Pass;
            vendorAdmin.Phone = vvA.vendorAdmin.Phone;
            vendorAdmin.Username = vvA.vendorAdmin.Username;
            vendorAdmin.Vendor = vendor;
            vendorAdmin.FirstName = vvA.vendorAdmin.FirstName;
            vendorAdmin.LastName = vvA.vendorAdmin.LastName;

            try
            {
                using (FTCDBContext ftcdbContext = new FTCDBContext())
                {
                    await ftcdbContext.Vendors.AddAsync(vendor);
                    vendorAdmin.VendorId = vendor.VendorId;
                    await ftcdbContext.VendorAdmins.AddAsync(vendorAdmin);
                    await ftcdbContext.SaveChangesAsync();
                    return new OkObjectResult(new{message="202"});
                }
            }
            catch (NpgsqlException ex)
            {
                return new OkObjectResult(new{message=ex.Message});
            }
        }
    }
}