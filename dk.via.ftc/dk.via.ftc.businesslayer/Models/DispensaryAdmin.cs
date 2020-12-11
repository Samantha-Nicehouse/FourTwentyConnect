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
