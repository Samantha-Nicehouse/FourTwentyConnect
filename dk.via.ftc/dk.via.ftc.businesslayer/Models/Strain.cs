using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public class Strain
    {
        public string strainName { get; set; }
        public int id { get; set; }
        public string race { get; set; }
        public List<string> flavors { get; set; }
        public Effects effects { get; set; }
    }
}
