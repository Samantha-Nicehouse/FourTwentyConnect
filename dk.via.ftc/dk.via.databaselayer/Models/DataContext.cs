using Microsoft.EntityFrameworkCore;
using dk.via.ftc.web.Models;
namespace dk.via.databaselayer.Models
{
    public partial class DataContext : DbContext
    {
        public virtual DbSet<Vendor> Item { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql(@"Host=localhost;Database=entitycore;Username=postgres;Password=mypassword");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>(entity =>
            {
                object p = entity.ToTable("vendorId");
                entity.Property(e => e.VendorId)
                                    .HasColumnName("id")
                                    .HasDefaultValueSql("nextval('account.item_id_seq'::regclass)");
            });
            modelBuilder.HasSequence("item_id_seq", "account");
        }
}
