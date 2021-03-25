using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogContext :DbContext 
    {
        public CatalogContext(DbContextOptions dbContextOptions) : base (dbContextOptions)
        {
                
        }

        public DbSet <CatalogSize>  CatalogSizes   { get; set; }
        public DbSet<CatalogItem>  CatalogItems   { get; set; }
        public DbSet< CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(b =>
           {
               b.Property(b => b.Id)
               .IsRequired()
               .ValueGeneratedOnAdd();

               b.Property(b => b.Brand)
               .IsRequired()
               .HasMaxLength(100);
           });
            modelBuilder.Entity<CatalogSize>(s =>
            {
                s.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
                s.Property(s => s.Size)
                 .IsRequired();

            });
            modelBuilder.Entity<CatalogType>(c =>
            {
                c.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
                c.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(100);
            });
            modelBuilder.Entity<CatalogItem>(t =>
            {
                t.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
                t.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
                t.Property(t => t.Description);
                t.Property(t => t.Price)
                .IsRequired()
                .GetType();
                t.Property(t => t.PictureUrl)
                .IsRequired()
                .HasMaxLength(100);
                t.HasOne(t => t.CatalogBrand)
                .WithMany()
                .HasForeignKey(t => t.BrandId);
                t.HasOne(t => t.CatalogType)
                .WithMany()
                .HasForeignKey(t => t.TypeId);
                t.HasOne(t => t.CatalogSize)
                .WithMany()
                .HasForeignKey(t => t.SizeId);
            });


        }
    }
}
