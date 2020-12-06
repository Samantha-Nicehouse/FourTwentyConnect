using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    
    public partial class VendorAdmin
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("vendor_id")]
        public string VendorId { get; set; }

        [JsonPropertyName("pass")]
        public string Pass { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
