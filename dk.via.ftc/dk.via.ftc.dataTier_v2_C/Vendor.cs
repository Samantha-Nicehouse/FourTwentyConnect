using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    [Table("vendor", Schema = "SEP3")]
    public partial class Vendor
    {
        public Vendor()
        {
            Catalogs = new HashSet<Catalog>();
            Orderlines = new HashSet<Orderline>();
            Products = new HashSet<Product>();
            VendorAdmins = new HashSet<VendorAdmin>();
        }
        [JsonPropertyName("vendor_id"), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string VendorId { get; set; }
        [JsonPropertyName("vendorName")]
        public string VendorName { get; set; }
        [JsonPropertyName("vendorLicense")]
        public string VendorLicense { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("stateProvince")]
        public string State { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<VendorAdmin> VendorAdmins { get; set; }
    }
}
