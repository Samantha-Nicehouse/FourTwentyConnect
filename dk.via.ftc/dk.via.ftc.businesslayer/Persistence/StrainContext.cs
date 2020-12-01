﻿using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Persistence
{
    public class StrainContext
    {
        public StrainContext()
        {
            Strains = new List<StrainAPIObj>();
        }
        public List<StrainAPIObj> Strains;
    }
}
