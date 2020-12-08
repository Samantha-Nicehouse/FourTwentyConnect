using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Data;
using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    [Route("db/Countries")]
    [ApiController]
    public class CountryController: ControllerBase

    {

    private ICountryService countryService;

    public CountryController(ICountryService countryService)
    {
        this.countryService = countryService;
    }

    [HttpGet]
    [Route("All")]
    public async Task<ActionResult<IList<Country>>>
        GetCountries()

    {
        try
        {
            IList<Country> countries = await countryService.GetCountriesAsync();

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