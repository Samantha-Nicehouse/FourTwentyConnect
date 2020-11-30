using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Orderline
    {
        public int OrderlineId { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public string VendorId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual PurchaseOrder Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
