using Microsoft.EntityFrameworkCore;
using ShopDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedCountry(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country()
                {
                    Id = 1,
                    Name = "The USA"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Canada"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Brasil"
                }

            });

        }
        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category()
                {
                    Id = 1,
                    Name = "Meat"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Dairy products"
                },
                new Category()
                {
                    Id = 3,
                    Name = "drink"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Snack"
                }


            });
        }
        public static void SeedCity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City()
                {
                    Id = 1,
                    Name = "Miami",
                    CountryId = 1
                },
                new City()
                {
                    Id = 2,
                    Name = "Las Vegas",
                    CountryId = 1
                },
                new City()
                {
                    Id = 3,
                    Name = "Toronto",
                    CountryId = 2
                },
                new City()
                {
                    Id = 4,
                    Name = "San Diego",
                    CountryId = 1
                }
            });
        }
        public static void SeedPosition(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                new Position()
                {
                    Id = 1,
                    Name = "Cashier"
                },
                new Position()
                {
                    Id = 2,
                    Name = "Mover"
                },
                new Position()
                {
                    Id = 3,
                    Name = "Security"
                },
                new Position()
                {
                    Id = 4,
                    Name = "Manager"
                },
                new Position()
                {
                    Id = 5,
                    Name = "Director"
                },
            });
        }
        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Coca Cola",
                    Price = 3.10m,
                    Discount = 10,
                    CategoryID = 3,
                    Quantity = 100,
                    IsinStock = true
                },
                new Product()
                {
                    Id = 2,
                    Name = "Pepsi Cola",
                    Price = 3.10m,
                    Discount = 10,
                    CategoryID = 3,
                    Quantity = 100,
                    IsinStock = true
                },
                new Product()
                {
                    Id = 3,
                    Name = "Chicken",
                    Price = 4.10m,
                    Discount = 10,
                    CategoryID = 1,
                    Quantity = 100,
                    IsinStock = true
                },
                new Product()
                {
                    Id = 4,
                    Name = "Pringles",
                    Price = 2.50m,
                    Discount = 30,
                    CategoryID = 4,
                    Quantity = 100,
                    IsinStock = true
                },
                new Product()
                {
                    Id = 5,
                    Name = "Milk",
                    Price = 2.10m,
                    Discount = 30,
                    CategoryID = 2,
                    Quantity = 100,
                    IsinStock = true
                }
            });
        }
        public static void SeedShop(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop[]
            {
                new Shop()
                {
                    Id = 1,
                    Name = "Walmart",
                    Address = "3200 NW 79th St, FL 33147",
                    CityID = 1,
                    ParkingArea = 1000,
                },
                new Shop()
                {
                    Id = 2,
                    Name = "Walmart",
                    Address = "4505 W Charleston Blvd, NV 89102",
                    CityID = 2,
                    ParkingArea = 1000,
                },
                new Shop()
                {
                    Id = 3,
                    Name = "Walmart",
                    Address = "3412 College Ave, CA 92115 (Walmart Supercenter)",
                    CityID = 4,
                    ParkingArea = 1000,
                },

            });
        }
        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(new Worker[]
            {
                new Worker()
                {
                    Id= 1,
                    Name = "Michael",
                    Surname = "Thompson",
                    Salary = 15m,
                    Email = "Michael@outlook.com",
                    PhoneNumber = "+1(213) 555-0198",
                    PositionID = 1,
                    ShopID = 1,
                },
                new Worker()
                {
                    Id= 2,
                    Name = "Sarah",
                    Surname = "Martinez",
                    Salary = 18.50m,
                    Email = "Martinez@outlook.com",
                    PhoneNumber = "+1(305) 555-4477",
                    PositionID = 3,
                    ShopID = 1,
                },
                new Worker()
                {
                    Id= 3,
                    Name = "Jonathan",
                    Surname = "Lee",
                    Salary = 38.50m,
                    Email = "Lee@outlook.com",
                    PhoneNumber = "+1(415) 555-7321",
                    PositionID = 4,
                    ShopID = 1,
                },
                new Worker()
                {
                    Id= 4,
                    Name = "Angela",
                    Surname = "Davis",
                    Salary = 14.50m,
                    Email = "Davis@outlook.com",
                    PhoneNumber = "+1(646) 555-1184",
                    PositionID = 1,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 5,
                    Name = "Christopher",
                    Surname = "Brown",
                    Salary = 24m,
                    Email = "Brown@outlook.com",
                    PhoneNumber = "+1(702) 555-9033",
                    PositionID = 2,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 6,
                    Name = "Jessica",
                    Surname = "Johnson",
                    Salary = 19m,
                    Email = "Brown@outlook.com",
                    PhoneNumber = "+1(312) 555-2765",
                    PositionID = 3,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 7,
                    Name = "Robert",
                    Surname = "Wilson",
                    Salary = 38.50m,
                    Email = "Wilson@outlook.com",
                    PhoneNumber = "+1(617) 555-8449",
                    PositionID = 4,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 8,
                    Name = "Emily",
                    Surname = "Garcia",
                    Salary = 15.50m,
                    Email = "Garcia@outlook.com",
                    PhoneNumber = "+1(818) 555-6620",
                    PositionID = 1,
                    ShopID = 3,
                },
                new Worker()
                {
                    Id= 9,
                    Name = "David",
                    Surname = "Miller",
                    Salary = 23m,
                    Email = "Miller@outlook.com",
                    PhoneNumber = "+1(480) 555-3917",
                    PositionID = 2,
                    ShopID = 3,
                },
                new Worker()
                {
                    Id= 10,
                    Name = "Ashley",
                    Surname = "Rodriguez",
                    Salary = 17.75m,
                    Email = "Rodriguez@outlook.com",
                    PhoneNumber = "+1(917) 555-0456",
                    PositionID = 3,
                    ShopID = 3,
                },
                new Worker()
                {
                    Id= 11,
                    Name = "Daniel",
                    Surname = "White",
                    Salary = 14.80m,
                    Email = "White@outlook.com",
                    PhoneNumber = "+1(214) 555-7832",
                    PositionID = 1,
                    ShopID = 1,
                },
                new Worker()
                {
                    Id= 12,
                    Name = "Megan",
                    Surname = "Lewis",
                    Salary = 38.80m,
                    Email = "Lewis@outlook.com",
                    PhoneNumber = "+1(503) 555-1290",
                    PositionID = 4,
                    ShopID = 1,
                },
                new Worker()
                {
                    Id= 13,
                    Name = "Benjamin",
                    Surname = "Harris",
                    Salary = 20m,
                    Email = "Harris@outlook.com",
                    PhoneNumber = "+1(404) 555-6814",
                    PositionID = 3,
                    ShopID = 1,
                },
                new Worker()
                {
                    Id= 14,
                    Name = "Rachel",
                    Surname = "Clark",
                    Salary = 16m,
                    Email = "Clark@outlook.com",
                    PhoneNumber = "+1(619) 555-2245",
                    PositionID = 1,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 15,
                    Name = "Anthony",
                    Surname = "Taylor",
                    Salary = 25m,
                    Email = "Taylor@outlook.com",
                    PhoneNumber = "+1(713) 555-9301",
                    PositionID = 2,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 16,
                    Name = "Lauren",
                    Surname = "Allen",
                    Salary = 18m,
                    Email = "Allen@outlook.com",
                    PhoneNumber = "+1(720) 555-5789",
                    PositionID = 3,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 17,
                    Name = "Brian",
                    Surname = "Young",
                    Salary = 38.18m,
                    Email = "Young@outlook.com",
                    PhoneNumber = "+1(323) 555-4472",
                    PositionID = 4,
                    ShopID = 2,
                },
                new Worker()
                {
                    Id= 18,
                    Name = "Stephanie",
                    Surname = "King",
                    Salary = 14.70m,
                    Email = "King@outlook.com",
                    PhoneNumber = "+1(801) 555-3640",
                    PositionID = 1,
                    ShopID = 3,
                },
                new Worker()
                {
                    Id= 19,
                    Name = "Joshua",
                    Surname = "Scott",
                    Salary = 19m,
                    Email = "Scott@outlook.com",
                    PhoneNumber = "+1(916) 555-7128",
                    PositionID = 3,
                    ShopID = 3,
                },
                new Worker()
                {
                    Id= 20,
                    Name = "Laura",
                    Surname = "Baker",
                    Salary = 22.50m,
                    Email = "Baker@outlook.com",
                    PhoneNumber = "+1(954) 555-2083",
                    PositionID = 3,
                    ShopID = 3,
                }

            });

        }
        public static void SeedProdutShop(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductShop>().HasData(new ProductShop[]
            {
                new ProductShop()
                {
                    ShopID = 1,
                    ProductID = 1
                },
                new ProductShop()
                {
                    ShopID = 1,
                    ProductID = 2
                },
                new ProductShop()
                {
                    ShopID = 1,
                    ProductID = 3
                },
                new ProductShop()
                {
                    ShopID = 1,
                    ProductID = 4
                },
                new ProductShop()
                {
                    ShopID = 1,
                    ProductID = 5
                },
                new ProductShop()
                {
                    ShopID = 2,
                    ProductID = 1
                },
                new ProductShop()
                {
                    ShopID = 2,
                    ProductID = 2
                },
                new ProductShop()
                {
                    ShopID = 2,
                    ProductID = 3
                },
                new ProductShop()
                {
                    ShopID = 2,
                    ProductID = 4
                },
                new ProductShop()
                {
                    ShopID = 2,
                    ProductID = 5
                },
                new ProductShop()
                {
                    ShopID = 3,
                    ProductID = 1
                },
                new ProductShop()
                {
                    ShopID = 3,
                    ProductID = 2
                },
                new ProductShop()
                {
                    ShopID = 3,
                    ProductID = 3
                },
                new ProductShop()
                {
                    ShopID = 3,
                    ProductID = 4
                },
                new ProductShop()
                {
                    ShopID = 3,
                    ProductID = 5
                },
            });

        }
    }
}
