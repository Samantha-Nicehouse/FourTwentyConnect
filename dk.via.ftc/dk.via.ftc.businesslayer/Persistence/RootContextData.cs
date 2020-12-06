using dk.via.ftc.businesslayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Persistence
{
    public class RootContextData : DbContext
    {

        public RootContextData(DbContextOptions<RootContextData> options)
            : base(options)
        {
        }
        public DbSet<Root> roots { get; set; }
        public DbSet<Models.Effects> Effects { get; set; }
    }
}
