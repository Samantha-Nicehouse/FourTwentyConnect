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
        public int id { get; set; }
        public string race { get; set; }
<<<<<<< Updated upstream
        public virtual List<string> flavors { get; set; }
=======
        [JsonPropertyName("flavors")]
        public virtual IEnumerable<string> flavors { get; set; }
        [JsonPropertyName("effects")]
>>>>>>> Stashed changes
        public virtual Effects effects { get; set; }

        
    }
}
