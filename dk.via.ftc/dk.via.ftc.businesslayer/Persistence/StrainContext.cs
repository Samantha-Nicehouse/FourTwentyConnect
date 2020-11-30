using dk.via.ftc.businesslayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Persistence
{
    public class StrainContext : DbContext
    {
        public StrainContext(DbContextOptions<StrainContext> options)
        : base(options) { }

        public DbSet<Strain> Strains { get; set; }
    }
}
