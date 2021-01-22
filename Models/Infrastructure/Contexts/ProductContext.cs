using Microsoft.EntityFrameworkCore;
using Models.Entities.Products;

namespace Models.Infrastructure.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Type> Types { get; set; }

        //Seed data when Migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Type 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Type>().HasData(
            new Type { Id = 1, Name = "Smart Phone" });
            modelBuilder.Entity<Type>().HasData(
            new Type { Id = 2, Name = "Laptop" });
            modelBuilder.Entity<Type>().HasData(
            new Type { Id = 3, Name = "Tablet" });

            //Brand
            modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 1, Name = "Iphone" });
            modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 2, Name = "Samsung" });
            modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 3, Name = "VinSmart" });

            //Product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Iphone 7 Plus",
                Name = "John",
                Name = "John",
                Name = "John",
                Name = "John",
                Name = "John",
                Name = "John",
                Name = "John",
                Name = "John",


            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 2,
                EmployeeName = "Matt",
                DateOfBirth = new DateTime(1989, 01, 01),
                Gender = Gender.Male,
                DepartmentID = 2

            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 3,
                EmployeeName = "Carol",
                DateOfBirth = new DateTime(1989, 01, 01),
                Gender = Gender.Female,
                DepartmentID = 3

            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 4,
                EmployeeName = "Tony",
                DateOfBirth = new DateTime(1989, 01, 01),
                Gender = Gender.Male,
                DepartmentID = 3

            });
        }

    }
}