using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    public partial class Strain
    {
        public Strain()
        {
            Effects = new HashSet<Effect>();
        }

        public int StrainId { get; set; }
        public string StrainName { get; set; }
        public string Race { get; set; }

        public virtual ICollection<Effect> Effects { get; set; }


    }
}