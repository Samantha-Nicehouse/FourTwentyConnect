using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using dk.via.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using Microsoft.EntityFrameworkCore;
using Vendor = dk.via.ftc.businesslayer.Models.Vendor;
using VendorAdmin = dk.via.ftc.businesslayer.Models.VendorAdmin;
using dk.via.ftc.businesslayer.Data;
using Newtonsoft.Json;

namespace dk.via.ftc.businesslayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class VendorController : ControllerBase
    {
        private IVendorService_v2 service;

        public VendorController(IVendorService_v2 vendorService)
        {
            this.service = vendorService;
        }

    /*   [HttpPut]
        public async Task RegisterVendorVendorAdmin(VendorVendorAdmin vvA)
        {
            vvA.vendorAdmin.Pass = FTCEncrypt.EncryptString(vvA.vendorAdmin.Pass);
            await service.AddVendorVendorAdminAsync(vvA);
            
        }
        */
        [HttpPut]
        public async Task RegisterVendor([FromBody]Vendor vendor)
        {
            string s = JsonConvert.SerializeObject(vendor);
            Console.WriteLine(s);
            await service.AddVendorAsync(vendor);
            
        }
        [HttpPut]
        [Route("VendorAdmin")]
        public async Task RegisterVendorAdmin([FromBody]VendorAdmin vendorAdmin)
        {
            string s = JsonConvert.SerializeObject(vendorAdmin);
            Console.WriteLine(s);
            await service.AddVendorAdminAsync(vendorAdmin);
            
        }
        
        [HttpGet, HttpPost]
        [Route("VendorLic/{license}")]
        public async Task<ActionResult<string>> 
            GetVendorId([FromRoute]string license)

        {
            try
            {
                Console.WriteLine(license + " Is the retrieved license");
                string vendor = await service.GetVendorByLicense(license);
                return Ok(vendor);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, false);
            }
        }
    }
}
