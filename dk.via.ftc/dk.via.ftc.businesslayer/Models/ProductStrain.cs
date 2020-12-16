﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using dk.via.ftc.businesslayer.Models.DTO;

namespace dk.via.ftc.businesslayer.Models
{
    public class ProductStrain : Product
    {
        public string strainname { get; set; }
        public int id { get; set; }
        public string race { get; set; }
        public virtual List<string> flavors { get; set; }
        public virtual DTO.Effects effects { get; set; }
    }
}