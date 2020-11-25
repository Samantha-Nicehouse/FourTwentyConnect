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
using Vendor = dk.via.ftc.businesslayer.Models.Vendor;
using VendorAdmin = dk.via.ftc.businesslayer.Models.VendorAdmin;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    [Route("db/[controller]")]
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
        public async Task<ActionResult> PutVendorRegistration(VendorVendorAdmin vvA)
         {
             return new OkObjectResult(new{message=await service.AddVendorVendorAdmin(vvA)});
         }




        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
        