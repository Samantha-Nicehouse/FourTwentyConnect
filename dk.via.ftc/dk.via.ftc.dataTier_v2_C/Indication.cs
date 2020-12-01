using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    [Table("indication",Schema = "SEP3")]
    public partial class Indication
    {
      
        public Indication()
        {
            StrainIndications = new HashSet<StrainIndication>();
        }
        [JsonPropertyName("indication_id")]
        public int IndicationId { get; set; }
        [JsonPropertyName("medical_name")]
        public string MedicalName { get; set; }

        public virtual ICollection<StrainIndication> StrainIndications { get; set; }
    }
}
