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
        public string strainname { get; set; }
        [JsonPropertyName("id"),Key]
        public int id { get; set; }
        [JsonPropertyName("race")]
        public string race { get; set; }
        [JsonPropertyName("flavors")]
        public IList<string> flavors { get; set; }
        [JsonPropertyName("effects")]
        public Effects effects { get; set; }

        public string Test()
        {
            return "StrainName=" + strainname + " StrainId=" + id + "StrainRace=" + race + " Flavours=" + flavors + " Effects=" + effects;
        }
    }
}
