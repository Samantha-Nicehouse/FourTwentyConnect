﻿using System;
using System.Threading.Tasks;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.dataTier_v2_C.Persistence;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace dk.via.ftc.dataTier_v2_C.Data
{
    public class VendorService : IVendorService
    {
        private FTCDBContext fTCDBContext;
        public VendorService(FTCDBContext context)
        {
            fTCDBContext = context;
        }
        public async Task AddVendorAsync(Vendor vendor)
        {
                await fTCDBContext.Vendors.AddAsync(vendor);
                await fTCDBContext.SaveChangesAsync();
        }
        public async Task AddVendorVendorAdmin(VendorVendorAdmin vvA)
        {
            Vendor vendor = new Vendor();
            vendor.City = vvA.vendor.City;
            vendor.Country = vvA.vendor.Country;
            vendor.State = vvA.vendor.stateProvince;
            vendor.VendorLicense = vvA.vendor.vendorLicense;
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
                
                    await fTCDBContext.Vendors.AddAsync(vendor);
                    vendorAdmin.VendorId = vendor.VendorId;
                    await fTCDBContext.VendorAdmins.AddAsync(vendorAdmin);
                    await fTCDBContext.SaveChangesAsync();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}