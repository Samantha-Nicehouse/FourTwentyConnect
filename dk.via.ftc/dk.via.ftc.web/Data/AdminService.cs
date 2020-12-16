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
            throw new System.NotImplementedException();
        }

        public async Task<string> GetVendorByLicense(string license)
        {
            throw new System.NotImplementedException();
        }

        public Task AddVendorAdminAsync(VendorAdmin vendorAdmin)
        {
            throw new System.NotImplementedException();
        }

      /*  public Task<ActionResult<string>> AddVendorVendorAdminAsync(VendorVendorAdmin vendorVendorAdmin)
        {
            throw new System.NotImplementedException();
        }*/
        public Task<ActionResult<string>> AddVendorAsync(VendorVendorAdmin vendorVendorAdmin)
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
                    VendorLicense = "LA28123",
                    City = "Berlin",
                    Country = "Germany",
                    State = "test"
                },
                new Vendor
                {
                    VendorName = "PharmaSupply",
                    VendorLicense = "LA23899",
                    City = "Berlin",
                    Country = "Germany",
                    State = "test"
                }
            };
            vendors = ps.ToList();
        }

        private void WriteVendorToFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendors);
            File.WriteAllText(vendorsFile, productsAsJson);
        }

      /*  Task IAdminService.AddVendorVendorAdminAsync(VendorVendorAdmin vendorVendorAdmin)
        {
            throw new System.NotImplementedException();
        }*/

        public async Task AddDispensaryAdminAsync(DispensaryAdmin aD)
        {
            throw new System.NotImplementedException();
        }
    }
}