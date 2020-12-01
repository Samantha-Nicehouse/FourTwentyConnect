using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using dk.via.ftc.dataTier_v2_C.Models;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public class Product
    {
        public Product()
        {
            Catalogs = new HashSet<Catalog>();
            Orderlines = new HashSet<Orderline>();
        }

        [JsonPropertyName("product_id"), Key]
        public int ProductId { get; set; }
        
        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }
        [JsonPropertyName("grow_type")]
        public char? GrowType { get; set; }
        [JsonPropertyName("unit")]
        public char? Unit { get; set; }
        [JsonPropertyName("thc_content")]
        public double? ThcContent { get; set; }
        [JsonPropertyName("strain_id")]
        public int StrainId { get; set; }
        [JsonPropertyName("vendor_id")]
        public string VendorId { get; set; }

        public virtual Strain Strain { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
    }
}
