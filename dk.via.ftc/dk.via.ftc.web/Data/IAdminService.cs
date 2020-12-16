using dk.via.ftc.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.web.Data
{
    public interface IAdminService
    {
        Task AddVendorAsync(Vendor vendor);
      //  Task AddVendorAdminAsync(VendorAdmin vendorAdmin);

       // Task AddVendorVendorAdminAsync(VendorVendorAdmin vendorVendorAdmin);
       public Task<string> GetVendorByLicense(string license);
        Task AddDispensaryAdminAsync(DispensaryAdmin aD);
        public Task AddVendorAdminAsync(VendorAdmin vendorAdmin);
    }
}