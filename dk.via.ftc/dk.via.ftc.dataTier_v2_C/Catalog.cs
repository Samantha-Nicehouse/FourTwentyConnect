using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Catalog
    {
        public int CatalogId { get; set; }
        public int? ReservedInventory { get; set; }
        public int? AvailableInventory { get; set; }
        public int? PackageSize { get; set; }
        public decimal? PricePerPackage { get; set; }
        public string VendorId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
