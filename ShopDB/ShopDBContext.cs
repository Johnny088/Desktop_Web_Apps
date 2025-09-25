using Microsoft.EntityFrameworkCore;
using ShopDB.Entities;
using ShopDB.Helpers;
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
            modelBuilder.Entity<ProductShop>().HasKey(item => new { item.ProductID, item.ShopID });
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
            modelBuilder.Entity<Worker>().Property(w => w.PhoneNumber).IsRequired().HasMaxLength(25);

            // Friendship with Fluent API
            modelBuilder.Entity<Category>().HasMany(cat => cat.Products).WithOne(prod => prod.Category).HasForeignKey(prod => prod.CategoryID); //category <===>Products    many to one
            modelBuilder.Entity<City>().HasOne(city => city.Country).WithMany(c => c.Cities).HasForeignKey(city => city.CountryId);            //city <===> Country        many to one
            modelBuilder.Entity<City>().HasMany(city => city.Shops).WithOne(shop => shop.City).HasForeignKey(shop => shop.CityID);          //city <===> Shops          many to one
            modelBuilder.Entity<Position>().HasMany(pos => pos.Workers).WithOne(worker => worker.Position).HasForeignKey(w => w.PositionID); //Position <===>Workers  many to one
            modelBuilder.Entity<Product>().HasMany(prod => prod.Shops).WithMany(s => s.Products);        //Product <===>Shops        many to many
            modelBuilder.Entity<Shop>().HasMany(s => s.Workers).WithOne(w => w.Shop).HasForeignKey(w => w.ShopID);                    //Shop <===> workers        many to one

            // Seeders Initialization
            modelBuilder.SeedCountry();
            modelBuilder.SeedCategory();
            modelBuilder.SeedCity();
            modelBuilder.SeedPosition();
            modelBuilder.SeedProduct();
            modelBuilder.SeedShop();
            modelBuilder.SeedWorkers();
            modelBuilder.SeedProdutShop();
           
        }
        
        DbSet<Category> Category { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Shop> Shops { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<ProductShop> ProdustsShops { get; set; }


        
    }
}
