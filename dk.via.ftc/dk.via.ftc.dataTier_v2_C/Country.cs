using System;
using System.Collections.Generic;
using dk.via.ftc.dataTier_v2_C;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Country
    {
        public Country()
        {
            Dispensaries = new HashSet<Dispensary>();
            Vendors = new HashSet<Vendor>();
        }

        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Dispensary> Dispensaries { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}