using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.businesslayer.Models
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