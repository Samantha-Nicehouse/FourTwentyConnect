using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.dataTier_v2_C.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Vendor = dk.via.ftc.businesslayer.Models.Vendor;
using VendorAdmin = dk.via.ftc.businesslayer.Models.VendorAdmin;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    [Route("db/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private IVendorService service;

        public VendorController(IVendorService vendorService)
        {
            this.service = vendorService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            return null;
        }

        // POST api/<ValuesController>
    

        [HttpPut]
        public async Task PutVendorRegistration(VendorVendorAdmin vvA)
         {

             //await service.AddVendorVendorAdmin(vvA);
         }
        
        [HttpPut]
        [Route("Vendor")]
        public async Task AddVendorRegistration([FromBody]Vendor vendor)
        {
            string s = JsonConvert.SerializeObject(vendor);
            Console.WriteLine(s);
            await service.AddVendorAsync(vendor);
        }
        [HttpPut]
        [Route("VendorAdmin")]
        public async Task AddVendorAdminRegistration([FromBody]VendorAdmin vendorAdmin)
        {
            string s = JsonConvert.SerializeObject(vendorAdmin);
            Console.WriteLine(s);
            await service.AddVendorAdminAsync(vendorAdmin);
        }
        
        [HttpGet]
        [Route("License/{license}")]
        public async Task<ActionResult<string>> GetVendorByLicense([FromRoute]string license)
        {
            try
            {
                Console.WriteLine(license+" GET REQUEST");
                string vendor = await service.GetVendorByLicense(license);
                if(vendor != null)
                    return Ok(vendor);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}
        