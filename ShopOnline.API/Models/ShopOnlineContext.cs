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
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        //Seed data when Migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Type 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 1, Name = "Undifided" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 2, Name = "Laptop" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 3, Name = "Tablet" });
            modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 4, Name = "Smart Phone" });
            #endregion
            #region Seed Brand
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 1, Name = "Undifided" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 2, Name = "Samsung" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 3, Name = "VinSmart" });
            modelBuilder.Entity<ProductBrand>().HasData(
            new ProductBrand { Id = 4, Name = "Iphone" });
            #endregion
            #region Seed Price
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 1, OldPrice = 500, CurrentPrice = 488, SalePercent = 3 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 2, OldPrice = 100, CurrentPrice = 78, SalePercent = 22 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 3, OldPrice = 188, CurrentPrice = 166, SalePercent = 12 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 4, OldPrice = 88, CurrentPrice = 66, SalePercent = 25 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 5, OldPrice = 168, CurrentPrice = 136, SalePercent = 19 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 6, OldPrice = 179, CurrentPrice = 168, SalePercent = 6 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 7, OldPrice = 268, CurrentPrice = 238, SalePercent = 11 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 8, OldPrice = 158, CurrentPrice = 133, SalePercent = 16 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 9, OldPrice = 208, CurrentPrice = 188, SalePercent = 10 });
            modelBuilder.Entity<ProductPrice>().HasData(
            new ProductPrice { Id = 10, OldPrice = 206, CurrentPrice = 166, SalePercent = 19 });
            #endregion
            #region Seed Product Image
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =1, 
                PictureUri = "assets/images/product/product-2.jpg",
                IsMainPicture = true,
                ProductRefId=1
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =2, 
                PictureUri = "assets/images/product/product-2.jpg",
                IsMainPicture = true,
                ProductRefId=2
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =3, 
                PictureUri = "assets/images/product/product-3.jpg",
                IsMainPicture = true,
                ProductRefId=3
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =4, 
                PictureUri = "assets/images/product/product-4.jpg",
                IsMainPicture = true,
                ProductRefId=4
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =5, 
                PictureUri = "assets/images/product/product-5.jpg",
                IsMainPicture = true,
                ProductRefId=5
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =6, 
                PictureUri = "assets/images/product/product-6.jpg",
                IsMainPicture = true,
                ProductRefId=6
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =7, 
                PictureUri = "assets/images/product/product-7.jpg",
                IsMainPicture = true,
                ProductRefId=7
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =8, 
                PictureUri = "assets/images/product/product-8.jpg",
                IsMainPicture = true,
                ProductRefId=8
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =9, 
                PictureUri = "assets/images/product/product-9.jpg",
                IsMainPicture = true,
                ProductRefId=9
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =10, 
                PictureUri = "assets/images/product/product-10.jpg",
                IsMainPicture = true,
                ProductRefId=10
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =11, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=1
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =12, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=2
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =13, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=3
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =14, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=4
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =15, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=5
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =16, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=6
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =17, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=7
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =18, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=8
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =19, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=9
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =20, 
                PictureUri = "assets/images/product-single/product-1.jpg",
                IsMainPicture = false,
                ProductRefId=10
            });
             modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =21, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=1
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =22, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=2
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =23, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=3
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =24, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=4
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =25, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=5
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =26, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=6
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =27, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=7
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =28, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=8
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =29, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=9
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =30, 
                PictureUri = "assets/images/product-single/product-2.jpg",
                IsMainPicture = false,
                ProductRefId=10
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =31, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=1
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =32, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=2
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =33, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=3
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =34, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=4
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =35, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=5
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =36, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=6
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =37, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=7
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =38, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=8
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =39, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=9
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =40, 
                PictureUri = "assets/images/product-single/product-3.jpg",
                IsMainPicture = false,
                ProductRefId=10
            });
             modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =41, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=1
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =42, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=2
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =43, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=3
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =44, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=4
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =45, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=5
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =46, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=6
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =47, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=7
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =48, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=8
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =49, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=9
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage
            { 
                Id =50, 
                PictureUri = "assets/images/product-single/product-4.jpg",
                IsMainPicture = false,
                ProductRefId=10
            });
            #endregion
            #region Seed Product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Iphone 7 Plus",
                Description = $"The iPhone 7 and iPhone 7 Plus are smartphones designed, developed, and marketed by Apple Inc. They are the tenth generation of the iPhone. They were announced on September 7, 2016, at the Bill Graham Civic Auditorium in San Francisco by Apple CEO Tim Cook, and were released on September 16, 2016, succeeding the iPhone 6S and iPhone 6S Plus as the flagship devices in the iPhone series. Apple also released the iPhone 7 and iPhone 7 Plus in numerous countries worldwide throughout September and October 2016. They were succeeded as flagship devices by the iPhone 8 and iPhone 8 Plus on September 22, 2017. The iPhone 7's overall design is similar to iPhone 6S and iPhone 6. Changes introduced included new color options (matte black and jet black), water and dust resistance, a new capacitive, static home button, revised antenna bands, and the removal of the 3.5 mm headphone jack. The device's internal hardware received upgrades, including a heterogeneous quad-core system-on-chip with improved system and graphics performance, upgraded 12 megapixel rear-facing cameras with optical image stabilization on all models, and an additional telephoto lens exclusive to the iPhone 7 Plus to provide enhanced (2x) optical zoom capabilities and portrait mode. Reception of the iPhone 7 was mixed. Although reviewers noted improvements to the camera, especially the dual rear camera on the Plus model, the phone was criticized for the lack of innovation in its display and build quality. Many reviews panned the controversial removal of the 3.5 mm headphone jack; some critics argued that the change was meant to bolster licensing of the proprietary Lightning connector and the sales of Apple's own wireless headphone products, and questioned the effects of the change on audio quality. Apple was also mocked by critics for Phil Schiller's statement that such a drastic change required 'courage.' The iPhone 7 was discontinued and removed from Apple's website after its annual September hardware event on September 10, 2019, but is still available through third-party retailers.",
                ShortDescription = "we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of...",
                //PictureUri = "assets/images/product/product-5.jpg",
                ProductTypeRefId = 4,
                ProductBrandRefId = 4,
                Quantity = 1

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Lity Majesty Palm",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                ShortDescription = "we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of...",
                //PictureUri = "assets/images/product/product-4.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Spring Snowflake",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                ShortDescription = "we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of...",
                //PictureUri = "assets/images/product/product-1.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Rock Soapwort",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                ShortDescription = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will",
                //PictureUri = "assets/images/product/product-2.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 0
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Scarlet Sage",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                ShortDescription = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus.",
                //PictureUri = "assets/images/product/product-3.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Foxglove Flower",
                ShortDescription = "we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of...",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                //PictureUri = "assets/images/product/product-4.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Wild Roses",
                ShortDescription = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                //PictureUri = "assets/images/product/product-5.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Sweet Alyssum",
                ShortDescription = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                //PictureUri = "assets/images/product/product-6.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Lity Majesty Palm",
                ShortDescription = "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur.",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
               // PictureUri = "assets/images/product/product-7.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Majesty Palm",
                ShortDescription = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will",
                Description = @"At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.
In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.",
                //PictureUri = "assets/images/product/product-8.jpg",
                ProductTypeRefId = 1,
                ProductBrandRefId = 1,
                Quantity = 0
            });
            #endregion

        }

    }
}
