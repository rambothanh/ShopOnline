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
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> Users { get; set; }

        //Seed data when Migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Type 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 1, Name = "Undifided" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 2, Name = "Laptop" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 3, Name = "Tablet" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 4, Name = "Smart Phone" });

            //Brand
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 1, Name = "Undifided" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 2, Name = "Samsung" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 3, Name = "VinSmart" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 4, Name = "Iphone" });

            //Product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Iphone 7 Plus",
                Description = $"The iPhone 7 and iPhone 7 Plus are smartphones designed, developed, and marketed by Apple Inc. They are the tenth generation of the iPhone. They were announced on September 7, 2016, at the Bill Graham Civic Auditorium in San Francisco by Apple CEO Tim Cook, and were released on September 16, 2016, succeeding the iPhone 6S and iPhone 6S Plus as the flagship devices in the iPhone series. Apple also released the iPhone 7 and iPhone 7 Plus in numerous countries worldwide throughout September and October 2016. They were succeeded as flagship devices by the iPhone 8 and iPhone 8 Plus on September 22, 2017. The iPhone 7's overall design is similar to iPhone 6S and iPhone 6. Changes introduced included new color options (matte black and jet black), water and dust resistance, a new capacitive, static home button, revised antenna bands, and the removal of the 3.5 mm headphone jack. The device's internal hardware received upgrades, including a heterogeneous quad-core system-on-chip with improved system and graphics performance, upgraded 12 megapixel rear-facing cameras with optical image stabilization on all models, and an additional telephoto lens exclusive to the iPhone 7 Plus to provide enhanced (2x) optical zoom capabilities and portrait mode. Reception of the iPhone 7 was mixed. Although reviewers noted improvements to the camera, especially the dual rear camera on the Plus model, the phone was criticized for the lack of innovation in its display and build quality. Many reviews panned the controversial removal of the 3.5 mm headphone jack; some critics argued that the change was meant to bolster licensing of the proprietary Lightning connector and the sales of Apple's own wireless headphone products, and questioned the effects of the change on audio quality. Apple was also mocked by critics for Phil Schiller's statement that such a drastic change required 'courage.' The iPhone 7 was discontinued and removed from Apple's website after its annual September hardware event on September 10, 2019, but is still available through third-party retailers.",
                Price = 400,
                PictureUri = "assets/images/product-single/product-5.jpg",
                ProductTypeRefId = 4,
                ProductBrandRefId = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Lity Majesty Palm",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 19,
                PictureUri = "assets/images/product-single/product-4.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Spring Snowflake",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 50,
                PictureUri = "assets/images/product-single/product-1.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Rock Soapwort",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 68,
                PictureUri = "assets/images/product-single/product-2.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Scarlet Sage",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 88,
                PictureUri = "assets/images/product-single/product-3.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Foxglove Flower",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 79,
                PictureUri = "assets/images/product-single/product-4.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Wild Roses",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 79,
                PictureUri = "assets/images/product-single/product-5.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Sweet Alyssum",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 79,
                PictureUri = "assets/images/product-single/product-6.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Lity Majesty Palm",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 79,
                PictureUri = "assets/images/product-single/product-7.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Majesty Palm",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                Price = 79,
                PictureUri = "assets/images/product-single/product-8.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1
            });


        }

    }
}
