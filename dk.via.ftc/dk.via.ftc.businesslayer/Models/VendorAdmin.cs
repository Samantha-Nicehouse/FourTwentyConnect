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
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
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
