using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    public class Vendor
    {
        [JsonPropertyName("vendorId")]
        public string VendorId { get; set; }
        [JsonPropertyName("vendorName")]
        public string VendorName { get; set; }
        [JsonPropertyName("vendorLicense")]
        public string vendorLicense { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("stateProvince")]
        public string stateProvince { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
