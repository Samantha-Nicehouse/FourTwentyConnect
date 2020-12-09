using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;

namespace dk.via.ftc.businesslayer.Persistence
{
    public class DispensaryLicencesContext
    {
        public DispensaryLicencesContext()
        {
            Licenses = new List<DispensaryLicense>();
            populateLicenses();
            Console.WriteLine("Licenses Loaded For Dispensary");
        }
        public List<DispensaryLicense> Licenses;
        
        public DispensaryLicense GetLicense(string license)
        {
            foreach (DispensaryLicense lic in Licenses)
            {
                if (lic.license.Equals(license))
                {
                    return lic;
                }
            }

            return null;
        }

        public void populateLicenses()
        {
            DispensaryLicense dl = new DispensaryLicense();
            dl.license = "12345678";
            DispensaryLicense dl1 = new DispensaryLicense();
            dl1.license = "23456789";
            DispensaryLicense dl2 = new DispensaryLicense();
            dl2.license = "34567890";
            DispensaryLicense dl3 = new DispensaryLicense();
            dl3.license = "45678901";
            DispensaryLicense dl4 = new DispensaryLicense();
            dl4.license = "56789012";
            Licenses.Add(dl);
            Licenses.Add(dl1);
            Licenses.Add(dl2);
            Licenses.Add(dl3);
            Licenses.Add(dl4);
        }
    }
}