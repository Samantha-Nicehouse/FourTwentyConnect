using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using dk.via.ftc.businesslayer.Models;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    [Table("dispensary_admin",Schema = "SEP3")]
    public partial class DispensaryAdmin
    {
        [Display(Name = "username"),Key]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("DispensaryId")]
        [Display(Name = "DispensaryId")]
        [ForeignKey(nameof(DispensaryId))]
        public string DispensaryId { get; set; }
        [JsonPropertyName("pass")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Pass { get; set; }
        [JsonPropertyName("email")]
        [EmailAddress]
        public string Email { get; set; }
        [JsonPropertyName("FirstName")]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }
   
        [JsonPropertyName("Dispensary")]
        public virtual Dispensary Dispensary { get; set; }
    }
}
