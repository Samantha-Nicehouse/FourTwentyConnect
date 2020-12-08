using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
 
   
    public class VendorAdmin
    {
        [JsonPropertyName("username")]
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [JsonPropertyName("vendor_id")]
        public string VendorId { get; set; }

        [JsonPropertyName("pass")]
        public string Pass { get; set; }
      
     
        [Required]
        [JsonPropertyName("email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        
        [Required]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        [Required]
        public string LastName { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
