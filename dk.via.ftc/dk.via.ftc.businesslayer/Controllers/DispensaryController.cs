using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using dk.via.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Persistence;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dk.via.ftc.businesslayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispensaryController : ControllerBase
    {
        private DispensaryLicencesContext context; 
        private IDispensaryService _dispensaryService;
        // GET
        public DispensaryController(DispensaryLicencesContext context1, IDispensaryService _dispensaryService
        )
        {
            context = context1;
            this._dispensaryService = _dispensaryService;
        }
        
        
        [HttpGet, HttpPost]
        [Route("License/{license}")]
        public async Task<ActionResult<bool>> 
            CheckLicense([FromRoute]string license)

        {
            try
            {
                Console.WriteLine(license);
                DispensaryLicense retrieved = context.GetLicense(license);
                Console.WriteLine(retrieved.active);
                if (retrieved.active == false)
                {
                    return Ok(true);
                    
                }
                return Ok(false);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, false);
            }
        }
        
        [HttpGet, HttpPost]
        [Route("DispensaryLic/{license}")]
        public async Task<ActionResult<string>> 
            GetDispensary([FromRoute]string license)

        {
            try
            {
                Console.WriteLine(license + " Is the retrieved license");
                IList<Dispensary> dispensaries = await _dispensaryService.GetDispensariesAsync();
                Console.WriteLine(dispensaries.Count+" Retrieved Dispensaries");
                foreach (Dispensary disp in dispensaries)
                {
                    string s = JsonConvert.SerializeObject(disp);
                    Console.WriteLine(s);
                    if (disp.DispensaryLicense.Equals(license))
                    {
                        Console.WriteLine(disp.DispensaryId + " is the found ID");
                        return Ok(disp.DispensaryId);
                    }
                }
                return Ok("NotFound");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, false);
            }
        }
        
        [HttpPut]
        public async Task RegisterDispensary([FromBody]Dispensary dispensary)
        {
            string s = JsonConvert.SerializeObject(dispensary);
            Console.WriteLine(s);
            await _dispensaryService.AddDispensaryAsync(dispensary);
            
        }
        
        [HttpPut]
        [Route("DispensaryAdmin")]
        public async Task RegisterDispensaryAdmin([FromBody]DispensaryAdmin dispensaryAdmin)
        {
            string s = JsonConvert.SerializeObject(dispensaryAdmin);
            Console.WriteLine(s);
            await _dispensaryService.AddDispensaryAdminAsync(dispensaryAdmin);
            
        }
        
    }
}