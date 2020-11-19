using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public class VendorAdmin : User
    {
        public int VendorId { get; set; }

        public void Update(VendorAdmin vendorToUpdate)
        {
            base.Update(vendorToUpdate);
        }
    }
}
