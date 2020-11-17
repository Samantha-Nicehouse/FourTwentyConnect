using dk.via.ftc.web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Data
{
    public class AdminService : IAdminService
    {
        private string vendorAdminFile = "vendorAdmins.json";
        private string vendorsFile = "vendors.json";
        private IList<Vendor> vendors;
        private IList<VendorAdmin> vendorAdmins;

        public AdminService()
        {
            if (!File.Exists(vendorsFile))
            {
                SeedVendor();
                WriteVendorToFile();
            }
            else
            {
                var content = File.ReadAllText(vendorsFile);
                vendors = JsonSerializer.Deserialize<List<Vendor>>(content);
            }
            if (!File.Exists(vendorAdminFile))
            {
                SeedVendorAdmin();
                WriteVendorAdminToFile();
            }
            else
            {
                var content = File.ReadAllText(vendorAdminFile);
                vendorAdmins = JsonSerializer.Deserialize<List<VendorAdmin>>(content);
            }
        }
        public async Task AddVendorAdminAsync(Vendor vendor, VendorAdmin vendorAdmin)
        {
            var max = vendors.Max(vendor => vendor.VendorId);
            vendor.VendorId = ++max;
            vendors.Add(vendor);
            WriteVendorToFile();
            vendorAdmin.VendorId = vendor.VendorId;
            vendorAdmins.Add(vendorAdmin);
            WriteVendorAdminToFile();
        }
        private void SeedVendor()
        {
            Vendor[] ps =
            {
                new Vendor
                {
                    VendorId = 1,
                    VendorName = "React",
                    vendorLicense = "LA28123",
                    City = "Berlin",
                    Country = "Germany",
                    stateProvince = "test"
                },
                new Vendor
                {
                    VendorId = 2,
                    VendorName = "PharmaSupply",
                    vendorLicense = "LA23899",
                    City = "Berlin",
                    Country = "Germany",
                    stateProvince = "test"
                }
            };
            vendors = ps.ToList();
        }

    private void SeedVendorAdmin()
    {
    VendorAdmin[] va =
    {
            new VendorAdmin

            {
                VendorId = 1,
                Password = "lanext",
                Email = "a@react.com",
                LastName = "The Builder"
            },
            new VendorAdmin
                {
                VendorId = 2,
                Password = "pha123",
                Email = "a@pharmasupply.com",
                LastName = "Supply"
            }
            };
            vendorAdmins = va.ToList();
        }


        private void WriteVendorToFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendors);
            File.WriteAllText(vendorsFile, productsAsJson);
        }
        private void WriteVendorAdminToFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendorAdmins);
            File.WriteAllText(vendorAdminFile, productsAsJson);
        }
    }
}
