
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Dispensary
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
        //[Remote("CheckLicense","Dispensary")]
        [Display(Name = "Dispensary License")]
        public string DispensaryLicense { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }

    
        public string CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
