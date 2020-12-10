﻿using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C.Models
{
    public partial class Effect
    {
        public string EffectsId { get; set; }
        public string[] Positive { get; set; }
        public string[] Negative { get; set; }
        public string[] Medical { get; set; }
        public int? StrainId { get; set; }

    }
}
