using dk.via.ftc.businesslayer.Models;
using Microsoft.EntityFrameworkCore;

namespace dk.via.ftc.dataTier_v2_C.Persistence
{
    public class FTCDBContext: DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorAdmin> VendorAdmins{get;set;}
        
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=b8zxgsmnlkoj6ypd21ro-postgresql.services.clever-cloud.com;Database=b8zxgsmnlkoj6ypd21ro;Username=u1qvxb47lih4lpp0hmzp;Password=L9CBWOWE3tlB0kpuncgG;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor", "SEP3");

                entity.Property(e => e.VendorId)
                    .HasColumnName("vendor_id")
                    .HasDefaultValueSql("('V'::text || nextval('\"SEP3\".vendor_id'::regclass))");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.stateProvince)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("state");

                entity.Property(e => e.vendorLicense)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("vendor_license");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vendor_name");
            });
            modelBuilder.Entity<VendorAdmin>(entity =>
            {
                entity.ToTable("vendor_admin", "SEP3");

                entity.HasIndex(e => e.Username, "vendor_admin_username_key")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("last_name");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("pass");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("username");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany()
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("fk_vendor_id");
            });
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "SEP3");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.GrowType)
                    .HasMaxLength(1)
                    .HasColumnName("grow_type")
                    .HasDefaultValueSql("'flower'::bpchar");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .HasColumnName("product_name");

                entity.Property(e => e.StrainId).HasColumnName("strain_id");

                entity.Property(e => e.ThcContent).HasColumnName("thc_content");

                entity.Property(e => e.Unit)
                    .HasMaxLength(1)
                    .HasColumnName("unit")
                    .HasDefaultValueSql("'gm'::bpchar");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasColumnName("vendor_id");

                entity.HasOne(d => d.Strain)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_strain_id_fkey");

                /*entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_vendor_id_fkey");*/
            });

        }
    }
}