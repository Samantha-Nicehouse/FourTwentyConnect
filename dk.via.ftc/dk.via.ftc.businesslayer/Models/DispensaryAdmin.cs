using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using dk.via.ftc.businesslayer.Models;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    public partial class DispensaryAdmin
    {
        [Display(Name = "Username"),Key]
        public string Username { get; set; }
        [JsonPropertyName("DispensaryId")]
        [Display(Name = "DispensaryId")]
        public string DispensaryId { get; set; }
        [JsonPropertyName("pass")]
        public string Pass { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
   
        [JsonPropertyName("Dispensary")]
        public virtual Dispensary Dispensary { get; set; }
    }
}
