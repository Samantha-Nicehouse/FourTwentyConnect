using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    [Table("dispensary",Schema = "SEP3")]
    public partial class Dispensary
    {
        public Dispensary()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }
        
        [JsonPropertyName("dispensary_id"), Key]
        public string DispensaryId { get; set; }
        [JsonPropertyName("dispensary_name")]
        public string DispensaryName { get; set; }
        [JsonPropertyName("dispensary_license")]
        public string DispensaryLicense { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
