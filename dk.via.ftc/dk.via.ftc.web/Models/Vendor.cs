using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
//using Microsoft.EntityFrameworkCore;


namespace dk.via.ftc.web.Models
{
   
    public class Vendor
    
    {
        

         public string VendorName { get; set; }

        
       
        public string vendorLicense { get; set; }
        
       
        public string City { get; set; }
        
       
        public string Country { get; set; }

        public string stateProvince { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public void Update(Vendor vendorToUpdate)
        {
            VendorName = vendorToUpdate.VendorName;
            vendorLicense = vendorToUpdate.vendorLicense;
            City = vendorToUpdate.City;
            Country = vendorToUpdate.Country;
            stateProvince = vendorToUpdate.stateProvince;
        }

        public byte[] ToBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(VendorName);
                bw.Write(vendorLicense);
                bw.Write(City);
                bw.Write(Country);
                bw.Write(stateProvince);
                return ms.ToArray();
            }
        }

        public static Vendor FromBytes(byte[] buffer)
        {
            Vendor retVal = new Vendor();

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                retVal.VendorName = br.ReadString();
                retVal.vendorLicense = br.ReadString();
                retVal.City = br.ReadString();
                retVal.Country = br.ReadString();
                retVal.stateProvince = br.ReadString();
            }

            return retVal;
        }

    }
}