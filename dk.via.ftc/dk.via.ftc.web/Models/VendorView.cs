using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace dk.via.ftc.web.Models
{
    public class VendorView
    
    {
        [Key]
        [JsonPropertyName("vendorId")]
        public int VendorId { get; set; }

        [JsonPropertyName("vendorName")] public string VendorName { get; set; }

        
        [Required]
        [JsonPropertyName("vendorLicense")]
        public string vendorLicense { get; set; }
        
        [Required]
        [JsonPropertyName("city")]
        public string City { get; set; }
        
        [Required]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [Required]
        [JsonPropertyName("stateProvince")]
        public string stateProvince { get; set; }
        
        public void Update(VendorView vendorToUpdate)
        {
            VendorId = vendorToUpdate.VendorId;
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
                bw.Write(VendorId);
                bw.Write(VendorName);
                bw.Write(vendorLicense);
                bw.Write(City);
                bw.Write(Country);
                bw.Write(stateProvince);
                return ms.ToArray();
            }
        }

        public static VendorView FromBytes(byte[] buffer)
        {
            VendorView retVal = new VendorView();

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                retVal.VendorId = br.ReadInt32();
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