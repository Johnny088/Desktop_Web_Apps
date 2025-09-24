using Microsoft.EntityFrameworkCore;
using ShopDB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB
{
    internal class ShopDBContext :DbContext
    {
        public string connectionString { get; set; }
        public ShopDBContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ShopDbConnection"].ConnectionString;
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //fluent API
            modelBuilder.Entity<Category>().Property(cat => cat.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<City>().Property(city => city.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Country>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Position>().Property(pos => pos.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(prod => prod.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Shop>().Property(s => s.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Shop>().Property(s => s.Address).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.Surname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.PhoneNumber).IsRequired().HasMaxLength(15);

            // Friendship with Fluent API
            modelBuilder.Entity<Category>().HasMany(cat => cat.Products).WithOne(prod => prod.Category);
            modelBuilder.Entity<City>().HasOne(city => city.Country).WithMany(c => c.Cities);
            modelBuilder.Entity<City>().HasMany(city => city.Shops).WithOne(shop => shop.City);
        }

        DbSet<Product> Products { get; set; }
        
    }
}
