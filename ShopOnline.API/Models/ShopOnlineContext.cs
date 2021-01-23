using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Models.Entities.UserModels;
using Models.Entities.Products;

namespace ShopOnline.API.Models
{
    public class ShopOnlineContext : DbContext
    {
        public ShopOnlineContext(DbContextOptions<ShopOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<User> Users { get; set; }

        //Seed data when Migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Type 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 1, Name = "Smart Phone" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 2, Name = "Laptop" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 3, Name = "Tablet" });

            //Brand
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 1, Name = "Iphone" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 2, Name = "Samsung" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 3, Name = "VinSmart" });

            //Product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Iphone 7 Plus",
                Description = $"The iPhone 7 and iPhone 7 Plus are smartphones designed, developed, and marketed by Apple Inc. They are the tenth generation of the iPhone. They were announced on September 7, 2016, at the Bill Graham Civic Auditorium in San Francisco by Apple CEO Tim Cook, and were released on September 16, 2016, succeeding the iPhone 6S and iPhone 6S Plus as the flagship devices in the iPhone series. Apple also released the iPhone 7 and iPhone 7 Plus in numerous countries worldwide throughout September and October 2016. They were succeeded as flagship devices by the iPhone 8 and iPhone 8 Plus on September 22, 2017. The iPhone 7's overall design is similar to iPhone 6S and iPhone 6. Changes introduced included new color options (matte black and jet black), water and dust resistance, a new capacitive, static home button, revised antenna bands, and the removal of the 3.5 mm headphone jack. The device's internal hardware received upgrades, including a heterogeneous quad-core system-on-chip with improved system and graphics performance, upgraded 12 megapixel rear-facing cameras with optical image stabilization on all models, and an additional telephoto lens exclusive to the iPhone 7 Plus to provide enhanced (2x) optical zoom capabilities and portrait mode. Reception of the iPhone 7 was mixed. Although reviewers noted improvements to the camera, especially the dual rear camera on the Plus model, the phone was criticized for the lack of innovation in its display and build quality. Many reviews panned the controversial removal of the 3.5 mm headphone jack; some critics argued that the change was meant to bolster licensing of the proprietary Lightning connector and the sales of Apple's own wireless headphone products, and questioned the effects of the change on audio quality. Apple was also mocked by critics for Phil Schiller's statement that such a drastic change required 'courage.' The iPhone 7 was discontinued and removed from Apple's website after its annual September hardware event on September 10, 2019, but is still available through third-party retailers.",
                Price = 400,
                PictureUri = "Pic1",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });


        }

    }
}
