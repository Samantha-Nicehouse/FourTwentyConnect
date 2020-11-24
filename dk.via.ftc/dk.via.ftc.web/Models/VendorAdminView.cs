using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Models
{
    public class VendorAdminView : VendorView ,UserView
    {
        [Key]
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")] 
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password has to be between 8 and 15 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        public void Update(VendorAdminView vendorToUpdate)
        {
            base.Update(vendorToUpdate);
        }
    }
}