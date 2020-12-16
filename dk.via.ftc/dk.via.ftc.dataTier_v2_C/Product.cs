using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Product
    {
        public Product()
        {
            Orderlines = new HashSet<Orderline>();
        }
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string GrowType { get; set; }
        public string Unit { get; set; }
        public double? ThcContent { get; set; }
        public int StrainId { get; set; }
        public string VendorId { get; set; }
        [ForeignKey(nameof(VendorId))]
        public int? ReservedInventory { get; set; }
        public int? AvailableInventory { get; set; }
        public bool? IsAvailable { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
    }
}