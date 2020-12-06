using dk.via.ftc.businesslayer.Models.DTO;
using dk.via.ftc.dataTier_v2_C.Data;
using dk.via.ftc.dataTier_v2_C.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    [Route("db/Strains")]
    [ApiController]
    public class StrainController : ControllerBase
    {
        IStrainDBService _strainDBService;
        public StrainController(IStrainDBService strainDBService)
        {
            _strainDBService = strainDBService;
        }

        [HttpGet]
        [Route("Strain/{strain_id}")]
        public async Task<ActionResult<Strain>> GetProductByStrain([FromQuery]int strain_id)
        {
            try
            {
                Console.WriteLine(strain_id + " GET REQUEST");
                Strain strain = await _strainDBService.GetStrainByIDAsync(strain_id);
                if (strain != null)
                    return Ok(strain);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IList<Strain>>> GetAllStrains()
        {
            try
            {
                Console.WriteLine("All Strain GET REQUEST");
                IList<Strain> strains = await _strainDBService.GetStrainsAsync();
                if (strains != null)
                    return Ok(strains);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task PutStrain([FromBody]StrainAPIObj strainapi)
        {
            try
            {
                Console.WriteLine("RECIEVED PUT REQUEST: Add" + strainapi.strainname);
                Strain strain = new Strain();
                Effect effect = new Effect();
                strain.Race = strainapi.race;
                strain.StrainName = strainapi.strainname;
                strain.StrainId = strainapi.id;
                if (strainapi.effects != null)
                {
                    if (strainapi.effects.medical != null)
                    {
                        effect.Medical = strainapi.effects.medical.ToArray();
                    }
                    if (strainapi.effects.negative != null)
                    {
                        effect.Negative = strainapi.effects.negative.ToArray();
                    }
                    if (strainapi.effects.positive != null)
                    {
                        effect.Positive = strainapi.effects.positive.ToArray();
                    }
                }
                strain.Effects = effect;
                await _strainDBService.AddStrainAsync(strain);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
