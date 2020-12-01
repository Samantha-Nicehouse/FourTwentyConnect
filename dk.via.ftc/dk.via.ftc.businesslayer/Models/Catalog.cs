using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


#nullable disable

namespace dk.via.ftc.businesslayer.Models

{
  
    public class Catalog
        

        
    {
        public Catalog()
        {
           
        }
        [JsonPropertyName("catalog_id"), Key]
        public int CatalogId { get; set; }
        [JsonPropertyName("reserved_inventory")]
        public int? ReservedInventory { get; set; }
        [JsonPropertyName("available_inventory")]
        public int? AvailableInventory { get; set; }
        [JsonPropertyName("package_size")]
        public int? PackageSize { get; set; }
        [JsonPropertyName("price_per_package")]
        public decimal? PricePerPackage { get; set; }
        [JsonPropertyName("vendor_id")]
        public string VendorId { get; set; }
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
