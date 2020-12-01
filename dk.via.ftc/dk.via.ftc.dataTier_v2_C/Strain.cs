using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    [Table("strain", Schema = "SEP3")]
    public partial class Strain
    {
        public Strain()
        {
            Products = new HashSet<Product>();
            StrainIndications = new HashSet<StrainIndication>();
        }

        [JsonPropertyName("strain_name")]  
        public string StrainName { get; set; }
        [JsonPropertyName("race")]
        public string Race { get; set; }
        [JsonPropertyName("strain_id"), Key]
        public int StrainId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<StrainIndication> StrainIndications { get; set; }
    }
}
