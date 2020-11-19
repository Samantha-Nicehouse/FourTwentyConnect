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
        private IList<VendorView> vendors;
        private IList<VendorAdminView> vendorAdmins;

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
                vendors = JsonSerializer.Deserialize<List<VendorView>>(content);
            }
            if (!File.Exists(vendorAdminFile))
            {
                SeedVendorAdmin();
                WriteVendorAdminToFile();
            }
            else
            {
                var content = File.ReadAllText(vendorAdminFile);
                vendorAdmins = JsonSerializer.Deserialize<List<VendorAdminView>>(content);
            }
        }
        public async Task AddVendorAdminAsync(VendorAdminView vendorAdmin)
        {
            vendorAdmins.Add(vendorAdmin);
            WriteVendorAdminToFile();
        }
        public async Task AddVendorAsync(VendorView vendor)
        {
            vendors.Add(vendor);
            WriteVendorAdminToFile();
        }
        private void SeedVendor()
        {
            VendorView[] ps =
            {
                new VendorView
                {
                    VendorId = 1,
                    VendorName = "React",
                    vendorLicense = "LA28123",
                    City = "Berlin",
                    Country = "Germany",
                    stateProvince = "test"
                },
                new VendorView
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
    VendorAdminView[] va =
    {
            new VendorAdminView

            {
                VendorId = 1,
                Password = "lanext",
                Email = "a@react.com",
                LastName = "The Builder"
            },
            new VendorAdminView
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
