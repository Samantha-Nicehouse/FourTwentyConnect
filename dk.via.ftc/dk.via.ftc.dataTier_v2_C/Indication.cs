﻿using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Indication
    {
        public Indication()
        {
            StrainIndications = new HashSet<StrainIndication>();
        }

        public int IndicationId { get; set; }
        public string MedicalName { get; set; }

        public virtual ICollection<StrainIndication> StrainIndications { get; set; }
    }
}
