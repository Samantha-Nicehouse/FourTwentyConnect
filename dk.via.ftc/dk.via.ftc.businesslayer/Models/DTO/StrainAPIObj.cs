using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models.DTO
{
    public class StrainAPIObj
    {
        [JsonPropertyName("strainname")]
        public string strainname { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("race")]
        public string race { get; set; }
        [JsonPropertyName("flavors")]
        public virtual List<string> flavors { get; set; }
        [JsonPropertyName("effects")]
        public virtual Effects effects { get; set; }

        
    }
}
