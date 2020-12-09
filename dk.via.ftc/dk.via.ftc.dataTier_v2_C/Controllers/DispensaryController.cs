using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via.ftc.dataTier_v2_C.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dk.via.ftc.dataTier_v2_C.Controllers

{
    [Route("db/[controller]")]
    [ApiController]
    public class DispensaryController : ControllerBase

    {
        private IDispensaryService _dispensaryService;

        public DispensaryController(IDispensaryService dispensaryService)
        {
            this._dispensaryService = dispensaryService;
        }

        [HttpPut]
        [Route("Dispensary")]
        public async Task PutDispensaryRegistration(Dispensary dispensary)
        {
            string s = JsonConvert.SerializeObject(dispensary);
            Console.WriteLine(s);
            await _dispensaryService.AddDispensary(dispensary);
        }

       
        

        [HttpGet]
        [Route("Dispensary/All")]
        public async Task<ActionResult<IList<Dispensary>>> GetDispensariesAll()

        {
            try
            {
                IList<Dispensary> dispensaries= await _dispensaryService.GetDispensariesAsync();

                return Ok(dispensaries);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(200, e.Message);
            }
        }

    }
}