﻿using dk.via.ftc.businesslayer.Data.FTCAPI;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Controllers.FTCAPI
{
    [Route("api/Strains")]
    [ApiController]
    public class StrainController : ControllerBase
    {
        IAPIStrainService _strainService;
        public StrainController(IAPIStrainService strainService)
        {
            _strainService = strainService;
        }

        [HttpGet]
        [Route("Strain/{strain_id}")]
        public async Task<ActionResult<Strain>> GetProductByStrain([FromQuery] int strain_id)
        {
            try
            {
                Console.WriteLine(strain_id + " GET REQUEST");
                Strain strain = await _strainService.GetStrainByIDAsync(strain_id);
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
                IList<Strain> strains = await _strainService.GetStrainsAsync();
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
        [Route("Strain/{strain_id}")]
        public async Task<ActionResult> PutStrain([FromRoute] StrainAPIObj strain)
        {
            try
            {
                await _strainService.AddStrainAsync(strain);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
