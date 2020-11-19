using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Models
{
    public class VendorAdminView : UserView
    {
        [JsonPropertyName("vendorId")]
        public int VendorId { get; set; }

        public void Update(VendorAdminView vendorToUpdate)
        {
            base.Update(vendorToUpdate);
        }
    }
}
