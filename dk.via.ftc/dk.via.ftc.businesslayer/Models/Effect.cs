using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    public partial class Effect
    {
        public Effect()
        {
            Strains = new HashSet<Strain>();
        }

        public string EffectsId { get; set; }
        public string[] Positive { get; set; }
        public string[] Negative { get; set; }
        public string[] Medical { get; set; }

        public virtual ICollection<Strain> Strains { get; set; }
    }
}
