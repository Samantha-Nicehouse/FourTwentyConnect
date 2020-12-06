using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public class Effects
    {
        [JsonPropertyName("positive")]
        public List<string> positive { get; set; }
        [JsonPropertyName("negative")]
        public List<string> negative { get; set; }
        [JsonPropertyName("medical")]
        public List<string> medical { get; set; }
        public Effects()
        {
            positive = new List<string>();
            negative = new List<string>();
            medical = new List<string>();
        }
    }
}
