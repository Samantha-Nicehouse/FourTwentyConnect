using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.via.ftc.web.Models;
using System.Diagnostics;
using dk.via.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using Microsoft.EntityFrameworkCore;
using Vendor = dk.via.ftc.businesslayer.Models.Vendor;

namespace dk.via.ftc.businesslayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private VendorService service;

        public VendorController(IVendorService vendorService)
        {
            this.service = new VendorService();
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
        public async Task PutVendor(Vendor vendor)
        {
            await service.AddVendorDbAsync(vendor);
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
