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
            Products = new HashSet<Product>();
        }
        [JsonPropertyName("strainname")]
        public string StrainName { get; set; }
        [JsonPropertyName("id")]
        public int StrainId { get; set; }
        [JsonPropertyName("race")]
        public string Race { get; set; }
        [JsonPropertyName("flavors")]
        public List<string> Flavors { get; set; }
        [JsonPropertyName("effects")]
        public Effects Effects { get; set; }
        
        

        public virtual ICollection<Product> Products { get; set; }

        
    }
}
