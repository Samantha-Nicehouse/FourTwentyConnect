using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class StrainIndication
    {
        [JsonPropertyName("indication_id"), Key]
        public int IndicationId { get; set; }
        [JsonPropertyName("strain_id"), Key]
        public int StrainId { get; set; }

        public virtual Indication Indication { get; set; }
        public virtual Strain Strain { get; set; }
    }
}
