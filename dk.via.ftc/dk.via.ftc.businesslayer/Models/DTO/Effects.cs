using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models.DTO
{
    public class Effects
    {
        public List<string> Positive { get; set; }
        public List<string> Negative { get; set; }
        public List<string> Medical { get; set; }
        public Effects()
        {
            Positive = new List<string>();
            Negative = new List<string>();
            Medical = new List<string>();
        }
    }
}
