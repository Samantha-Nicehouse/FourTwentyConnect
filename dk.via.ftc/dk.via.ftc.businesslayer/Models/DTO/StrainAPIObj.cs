using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models.DTO
{
    public class StrainAPIObj
    {
        public string strainname { get; set; }
        public int id { get; set; }
        public string race { get; set; }
        public virtual List<string> flavors { get; set; }
        public virtual Effects effects { get; set; }

    }
}
