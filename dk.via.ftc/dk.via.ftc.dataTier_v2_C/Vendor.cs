using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using dk.via.ftc.dataTier_v2_C;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Vendor
    {
        public Vendor()
        {
            Orderlines = new HashSet<Orderline>();
            Products = new HashSet<Product>();
            VendorAdmins = new HashSet<VendorAdmin>();
        }

        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorLicense { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
       
        public string CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual ICollection<Orderline> Orderlines { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<VendorAdmin> VendorAdmins { get; set; }
    }
}