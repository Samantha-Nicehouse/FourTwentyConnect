using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models.DTO
{
    public class Effects
    {
        [JsonPropertyName("positive")]
        List<string> Positive { get; set; }
        [JsonPropertyName("negative")]
        List<string> Negative { get; set; }
        [JsonPropertyName("medical")]
        List<string> Medical { get; set; }
        public Effects()
        {
            Positive = new List<string>();
            Negative = new List<string>();
            Medical = new List<string>();
        }
    }
}
