using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public class Effects
    {
<<<<<<< Updated upstream
        public List<string> Positive { get; set; }
        public List<string> Negative { get; set; }
        public List<string> Medical { get; set; }
=======
        [JsonPropertyName("positive")]
        public List<string> positive { get; set; }
        [JsonPropertyName("negative")]
        public List<string> negative { get; set; }
        [JsonPropertyName("medical")]
        public List<string> medical { get; set; }

>>>>>>> Stashed changes
        public Effects()
        {
            Positive = new List<string>();
            Negative = new List<string>();
            Medical = new List<string>();
        }
    }
}
