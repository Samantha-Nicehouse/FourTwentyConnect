﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using dk.via.ftc.dataTier_v2_C.Models;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    [Table("orderline",Schema = "SEP3")]
    public partial class Orderline
    {
        [JsonPropertyName("orderline_id"), Key]
        public int OrderlineId { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }
        
        [JsonPropertyName("vendor_id")]
        public string VendorId { get; set; }
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        public virtual PurchaseOrder Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
