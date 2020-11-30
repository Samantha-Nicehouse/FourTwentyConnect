using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Product
    {
        public Product()
        {
            Catalogs = new HashSet<Catalog>();
            Orderlines = new HashSet<Orderline>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public char? GrowType { get; set; }
        public char? Unit { get; set; }
        public double? ThcContent { get; set; }
        public int StrainId { get; set; }
        public string VendorId { get; set; }

        public virtual Strain Strain { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
    }
}
