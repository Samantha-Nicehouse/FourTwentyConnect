using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public class User
    {
        [Key]
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password has to be between 8 and 15 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [Required]
        [JsonPropertyName("securityLevel")]
        public int SecurityLevel { get; set; }





        public void Update(User userToUpdate)
        {
            Password = userToUpdate.Password;
        }
    }
}
