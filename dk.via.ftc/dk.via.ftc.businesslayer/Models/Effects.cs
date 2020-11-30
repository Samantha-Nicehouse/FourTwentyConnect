using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public class Effects
    {
        List<string> Positive { get; set; }
        List<string> Negative { get; set; }
        List<string> Medical { get; set; }
        public Effects()
        {
            Positive = new List<string>();
            Negative = new List<string>();
            Medical = new List<string>();
        }
    }
}
