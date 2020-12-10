using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C.Models
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
