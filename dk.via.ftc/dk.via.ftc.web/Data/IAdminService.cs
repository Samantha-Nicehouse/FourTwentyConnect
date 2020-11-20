using dk.via.ftc.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Data
{
    public interface IAdminService
    {
        Task AddVendorAdminAsync(VendorAdminView vendorAdmin);
        Task AddVendorAsync(VendorView vendor);
    }
}
