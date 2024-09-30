using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinalProject.Context
{
    public class CompanyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UE15045;Database= Final_Project;Trusted_Connection=True;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Categorys = new List<Category>
            {
                new Category {CategoryId = 1 , Name = "Fashion", Description = "Description of Category 1"},
                new Category {CategoryId = 2 , Name = "Food", Description = "Description of Category 2"},
                new Category {CategoryId = 3 , Name = "Social Media", Description = "Description of Category 3"},
                new Category {CategoryId = 4 , Name = "Casual Wear", Description = "Description of Category 4"},
                              
            };

            var _Products = new List<Product>
            {
                new Product {ProductId = 1, Title = "Product 1", Price = 1000, Description = "Description of product 1" , CategoryId = 1},
                new Product {ProductId = 2, Title = "Product 2", Price = 2000, Description = "Description of product 2" , CategoryId = 2},
                new Product {ProductId = 3, Title = "Product 3", Price = 3000, Description = "Description of product 3" , CategoryId = 3},
                new Product {ProductId = 4, Title = "Product 4", Price = 4000, Description = "Description of product 4" , CategoryId = 4}
            };

            modelBuilder.Entity<Category>().HasData(_Categorys);
            //modelBuilder.Entity<User>().HasData(_Users);
            modelBuilder.Entity<Product>().HasData(_Products);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}

