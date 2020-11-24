using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public class VendorAdmin : Vendor, User
    {
        public int VendorId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Update(VendorAdmin vendorToUpdate)
        {
            base.Update(vendorToUpdate);
        }
    }
}