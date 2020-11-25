using dk.via.ftc.businesslayer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.web.Data
{
    public class AdminService : IAdminService
    {
        private string vendorsFile = "vendors.json";
        private IList<Vendor> vendors;

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
            
        }
        public async Task AddVendorAsync(Vendor vendor)
        {
            vendors.Add(vendor);
        }

        public Task AddVendorAdminAsync(VendorAdmin vendorAdmin)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<string>> AddVendorVendorAdminAsync(VendorVendorAdmin vendorVendorAdmin)
        {
            throw new System.NotImplementedException();
        }

        private void SeedVendor()
        {
            Vendor[] ps =
            {
                new Vendor
                {
                    VendorName = "React",
                    vendorLicense = "LA28123",
                    City = "Berlin",
                    Country = "Germany",
                    stateProvince = "test"
                },
                new Vendor
                {
                    VendorName = "PharmaSupply",
                    vendorLicense = "LA23899",
                    City = "Berlin",
                    Country = "Germany",
                    stateProvince = "test"
                }
            };
            vendors = ps.ToList();
        }

        private void WriteVendorToFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendors);
            File.WriteAllText(vendorsFile, productsAsJson);
        }
    }
}