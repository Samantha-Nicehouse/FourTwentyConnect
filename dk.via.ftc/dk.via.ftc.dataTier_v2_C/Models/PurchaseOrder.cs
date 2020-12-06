﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            Orderlines = new HashSet<Orderline>();
        }
        [JsonPropertyName("order_id"), Key]
        public int OrderId { get; set; }
        [JsonPropertyName("dispensary_id")]
        public string DispensaryId { get; set; }
        [JsonPropertyName("total_price")]
        public decimal TotalPrice { get; set; }
        [JsonPropertyName("total_items")]
        public int TotalItems { get; set; }

        public virtual Dispensary Dispensary { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
    }
}
