using System;
using System.Collections.Generic;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C
{
    public partial class Strain
    {
        public Strain()
        {
            Products = new HashSet<Product>();
            StrainIndications = new HashSet<StrainIndication>();
        }

        public string StrainName { get; set; }
        public string Race { get; set; }
        public int StrainId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<StrainIndication> StrainIndications { get; set; }
    }
}
