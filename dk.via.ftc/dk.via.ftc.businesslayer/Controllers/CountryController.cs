using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Data.Services;
using dk.via.ftc.businesslayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.businesslayer.Controllers
{
    [Route("api/Countries")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CountryController : ControllerBase
    {
        private ICountryService _service;
        // GET
        public CountryController(ICountryService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IList<Country>>> 
            GetCountriesAll()

        {
            try
            {
                IList<Country> countries = await _service.GetCountriesAsync();

                return Ok(countries);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}