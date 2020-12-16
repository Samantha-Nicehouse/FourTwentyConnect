using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
{
    public class Dispensary
    {
    
        
            public Dispensary()
            {
                PurchaseOrders = new HashSet<PurchaseOrder>();
            }
        
            [JsonPropertyName("DispensaryId")]
            [Display(Name = "DispensaryId")]
            public string DispensaryId { get; set; }
            [JsonPropertyName("DispensaryName")]
            [Display(Name = "Dispensary Name")]
            
            
            public string DispensaryName { get; set; }
            [JsonPropertyName("DispensaryLicense")]
            
            [Display(Name = "Dispensary License")]
         
            [Required]
            
            //Using Remote validation attribute   
            [Remote("CheckLicense", "DispensaryController",HttpMethod ="POST", ErrorMessage = "Not a valid license.")]
            public string DispensaryLicense { get; set; }
            [JsonPropertyName("city")]
            [Required]
            
           
            public string City { get; set; }
            [JsonPropertyName("state")]
            [Required]
            
            
            public string State { get; set; }
            [JsonPropertyName("country")]
            public string Country { get; set; }

            public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        }
    }

