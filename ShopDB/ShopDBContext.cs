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

        DbSet<Product> Products { get; set; }
        
    }
}
