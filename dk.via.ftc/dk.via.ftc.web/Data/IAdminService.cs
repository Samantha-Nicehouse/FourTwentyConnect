using dk.via.ftc.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Data
{
    interface IAdminService
    {
        Task AddVendorAdminAsync(VendorAdmin vendorAdmin);
        Task AddVendorAsync(Vendor vendor);
    }
}
