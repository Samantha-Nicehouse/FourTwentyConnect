using dk.via.ftc.businesslayer.Models;
using dk.via.ftc.businesslayer.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Persistence
{
<<<<<<< Updated upstream
    public class StrainContext
    {
        public StrainContext()
        {
            Strains = new List<StrainAPIObj>();
        }
        public List<StrainAPIObj> Strains;

        public StrainAPIObj GetStrainById(int id)
        {
            foreach (StrainAPIObj strain in Strains)
            {
                if (strain.id == id)
                {
                    return strain;
                }
            }

            return null;
        }
    }
=======
    public class StrainContext {
            public StrainContext()
            {
                Strains = new List<Root>();
            }
            public List<Root> Strains;

            public Root GetStrainById(int id)
            {
                foreach (Root strain in Strains)
                {
                    if (strain.strain.id == id)
                    {
                        return strain;
                    }
                }

                return null;
            }
        }
>>>>>>> Stashed changes
}
