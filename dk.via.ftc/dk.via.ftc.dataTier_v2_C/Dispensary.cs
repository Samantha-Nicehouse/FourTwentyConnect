using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Dispensary
    {
        public Dispensary()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string DispensaryId { get; set; }
        public string DispensaryName { get; set; }
        public string DispensaryLicense { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
