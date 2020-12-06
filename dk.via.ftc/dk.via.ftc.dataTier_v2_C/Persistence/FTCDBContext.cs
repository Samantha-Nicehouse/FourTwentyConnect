using dk.via.ftc.dataTier_v2_C.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace dk.via.ftc.dataTier_v2_C.Persistence
{
    public class FTCDBContext: DbContext
    {

        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorAdmin> VendorAdmins{get;set;}
        public virtual DbSet<Effect> Effects { get; set; }
        public virtual DbSet<Strain> Strains { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public FTCDBContext(DbContextOptions<FTCDBContext> options) : base(options)
    {

    }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Console.WriteLine("NOT CONFIGURED");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Strain>(entity =>
            {
                entity.ToTable("strain", "SEP3");

                entity.Property(e => e.StrainId)
                    .ValueGeneratedNever()
                    .HasColumnName("strain_id");

                entity.Property(e => e.EffectsId).HasColumnName("effects_id");

                entity.Property(e => e.Race)
                    .HasMaxLength(10)
                    .HasColumnName("race");

                entity.Property(e => e.StrainName)
                    .HasMaxLength(20)
                    .HasColumnName("strain_name");

                entity.HasOne(d => d.Effects)
                    .WithMany(p => p.Strains)
                    .HasForeignKey(d => d.EffectsId)
                    .HasConstraintName("fk_effects_id");
            });
            modelBuilder.Entity<Effect>(entity =>
            {
                entity.HasKey(e => e.EffectsId)
                    .HasName("effects_pkey");

                entity.ToTable("effects", "SEP3");

                entity.Property(e => e.EffectsId)
                    .HasColumnName("effects_id")
                    .HasDefaultValueSql("('EFF'::text || nextval('\"SEP3\".effects_id'::regclass))");

                entity.Property(e => e.Medical)
                    .HasColumnType("character varying[]")
                    .HasColumnName("medical");

                entity.Property(e => e.Negative)
                    .HasColumnType("character varying[]")
                    .HasColumnName("negative");

                entity.Property(e => e.Positive)
                    .HasColumnType("character varying[]")
                    .HasColumnName("positive");
            });
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

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("state");

                entity.Property(e => e.VendorLicense)
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
                entity.HasKey(e => e.Username)
                    .HasName("vendor_admin_username_key");

                entity.ToTable("vendor_admin", "SEP3");

                entity.HasIndex(e => e.Email, "vendor_admin_email_uindex")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .HasColumnName("username");

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

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorAdmins)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("fk_vendor_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "SEP3");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.AvailableInventory).HasColumnName("available_inventory");

                entity.Property(e => e.GrowType)
                    .HasColumnType("character varying")
                    .HasColumnName("grow_type")
                    .HasDefaultValueSql("'flower'::bpchar");

                entity.Property(e => e.IsAvailable)
                    .HasColumnName("is_available")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .HasColumnName("product_name");

                entity.Property(e => e.ReservedInventory).HasColumnName("reserved_inventory");

                entity.Property(e => e.StrainId).HasColumnName("strain_id");

                entity.Property(e => e.ThcContent).HasColumnName("thc_content");

                entity.Property(e => e.Unit)
                    .HasColumnType("character varying")
                    .HasColumnName("unit")
                    .HasDefaultValueSql("'gm'::bpchar");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasColumnName("vendor_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vendor_id");
            });

        }
    }
}