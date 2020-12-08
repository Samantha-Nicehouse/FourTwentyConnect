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
            [Display(Name = "Vendor License")]
            [StringLength(8, ErrorMessage = "License number is a maximum of 8 characters")]
            public string vendorLicense { get; set; }
            [JsonPropertyName("city")]
            public string City { get; set; }
            [JsonPropertyName("stateProvince")]
            public string stateProvince { get; set; }
            [JsonPropertyName("country")]
            public string Country { get; set; }
            
            public virtual Country CountryCodeNavigation { get; set; }
            
            public Vendor()
            {
                Orderlines = new HashSet<Orderline>();
                Products = new HashSet<Product>();
                VendorAdmins = new HashSet<VendorAdmin>();
            }
            [JsonPropertyName("countryCode")]
            public string CountryCode { get; set; }
            public virtual ICollection<Orderline> Orderlines { get; set; }
            public virtual ICollection<Product> Products { get; set; }
            public virtual ICollection<VendorAdmin> VendorAdmins { get; set; }
        }
    }

