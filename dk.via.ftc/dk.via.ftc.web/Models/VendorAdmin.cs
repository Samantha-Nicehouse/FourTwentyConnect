using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Models
{
    public class VendorAdmin : User
    {
        [JsonPropertyName("vendorId")]
        public int VendorId { get; set; }

        public void Update(Vendor vendorToUpdate)
        {
            base.Update(vendorToUpdate);
        }
    }
}
