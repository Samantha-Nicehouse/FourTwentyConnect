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

namespace dk.via.ftc.businesslayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorAdminController : ControllerBase
    {
        private VendorService service;

        public VendorAdminController(IVendorService vendorService)
        {
            this.service = new VendorService();
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorAdmin>>> GetVendors()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendorAdmin>> GetVendor(int id)
        {
            return null;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        public async Task PutVendor(VendorAdmin vendorAdmin)
        {
            await service.AddVendorDbAsync(vendorAdmin);
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}