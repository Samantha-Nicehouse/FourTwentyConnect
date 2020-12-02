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

namespace dk.via.ftc.businesslayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private VendorService_v2 service;

        public VendorController(IVendorService_v2 vendorService)
        {
            this.service = new VendorService_v2();
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
       [HttpPut]
        public async Task RegisterVendorVendorAdmin(VendorVendorAdmin vvA)
        {
            await service.AddVendorVendorAdminAsync(vvA);
            
        }
        
    
        
      
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
