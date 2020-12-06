using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    public partial class StrainIndication
    {
        public int IndicationId { get; set; }
        public int StrainId { get; set; }

        public virtual Indication Indication { get; set; }
        //public virtual Strain Strain { get; set; }
    }
}
