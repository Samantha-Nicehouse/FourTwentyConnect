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
            
           
            public string VendorId { get; set; }
            
            [Required]
            public string VendorName { get; set; }
            [Display(Name = "Vendor License")]
            [Required]
            public string VendorLicense { get; set; }
           
            [Required]
            public string City { get; set; }
           
            [Required]
            public string State { get; set; }
          
            [Required]
            public string Country { get; set; }
            
            public virtual Country CountryCodeNavigation { get; set; }
            
            public Vendor()
            {
                Orderlines = new HashSet<Orderline>();
                Products = new HashSet<Product>();
                VendorAdmins = new HashSet<VendorAdmin>();
            }
           
            public string CountryCode { get; set; }
            public virtual ICollection<Orderline> Orderlines { get; set; }
            public virtual ICollection<Product> Products { get; set; }
            public virtual ICollection<VendorAdmin> VendorAdmins { get; set; }
        }
    }

