using dk.via.ftc.businesslayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Data.Sockets.SocketModels
{
    public class Drug
    {
        public String productName { get; set; }
        public String strain { get; set; }
        public String indications { get; set; }
        public int product_id { get; set; }

        public void FromProduct(ProductStrain product)
        {
            productName = product.ProductName;
            strain = product.strainname;
            int medicalCount = product.effects.medical.Count;
            indications = "";
            foreach(string indication in product.effects.medical)
            {
                medicalCount--;
                if(medicalCount == 0)
                {
                    indications += indication + ", ";
                }
                else { indications += indication; }
            }
            product_id = product.ProductId;
        }

    }
}
