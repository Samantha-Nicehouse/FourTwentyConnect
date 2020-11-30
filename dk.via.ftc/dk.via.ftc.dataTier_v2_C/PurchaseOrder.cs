using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            Orderlines = new HashSet<Orderline>();
        }

        public int OrderId { get; set; }
        public string DispensaryId { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalItems { get; set; }

        public virtual Dispensary Dispensary { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
    }
}
