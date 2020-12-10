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
                IList<Dispensary> dispensaries = await _dispensaryService.GetDispensariesAsync();
                string s = JsonConvert.SerializeObject(dispensaries);
                Console.WriteLine(s);
                return Ok(dispensaries);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(200, e.Message);
            }
        }
        [HttpGet]
        [Route("Dispensary/{username}")]
        public async Task<ActionResult<IList<Dispensary>>> GetDispensaryAdmin([FromRoute] string username)

        {
            try
            {
                DispensaryAdmin dispensaryAdmin = await _dispensaryService.GetDispensaryByUsername(username);
                string s = JsonConvert.SerializeObject(dispensaryAdmin);
                Console.WriteLine(s);
                return Ok(s);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(200, e.Message);
            }
        }



        [HttpPut]
        [Route("DispensaryAdmin")]
        public async Task PutDispensaryAdminRegistration(DispensaryAdmin dispensaryAdmin)
        {
            string s = JsonConvert.SerializeObject(dispensaryAdmin);
            Console.WriteLine(s);
            await _dispensaryService.AddDispensaryAdmin(dispensaryAdmin);
        }

    }
}