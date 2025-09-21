using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace _04_Music_Collection_DB
{
    // first we need to add a class by using "add new item"
    //we need to set up Entity Framework core and Entity Framework COre SqlServer
    internal class MusicalCollectionDbContext :DbContext //to connect to DBContext class it responses for connecting to databases
    {
        public string connectionString { get; set; } //future path
        public MusicalCollectionDbContext()  // constructor
        {
            connectionString = ConfigurationManager.ConnectionStrings["MusicDBConnection"].ConnectionString; //getting path from App.config
            this.Database.EnsureCreated();      //creating the database if it doesn't exist
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // we need it too connect to data base
        {
            //we need to set up configuration manager from NuGet
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);   //sending our path to the database and opening it
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // <====== we only need it when we use IdentityDbContext

            modelBuilder.Entity<TrackPlaylist>().HasKey(i => new { i.TrackID, i.PlaylistID }); // making composite key

            // filling out default data to the tables
            //-------------------------------------------------------------Countries------------------------------------------------
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
                    Name = "The United Kingdom"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Canada"
                },
                new Country()
                {
                    Id = 4,
                    Name = "Spain"
                }
            });
            //------------------------------------------------------------------bands-------------------------------------------------
            modelBuilder.Entity<Band>().HasData(new Band[]
            {
                new Band()
                {
                    Id = 1,
                    Name = "Metallica",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 2,
                    Name = "Red Hot Chili Peppers",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 3,
                    Name = "P!nk",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 4,
                    Name = "Miley Cyrus",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 5,
                    Name = "Twenty One Pilots",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 6,
                    Name = "Queen",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 7,
                    Name = "Eminem",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 8,
                    Name = "Bon Jovi",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 9,
                    Name = "Ed Sheeran",
                    CountryID = 1
                },
                new Band()
                {
                    Id = 10,
                    Name = "Benson Boone",
                    CountryID = 1
                }
            });
            //----------------------------------------------------------------------------------Genres--------------------------------------
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Hard Rock"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Alternative Rock"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Pop"
                },
                new Genre()
                {
                    Id = 4,
                    Name = "Pop Rock"
                },
                new Genre()
                {
                    Id = 5,
                    Name = "Progressive Rock"
                },
                new Genre()
                {
                    Id = 6,
                    Name = "Hip Hop"
                }
            }); 

            //------------------------------------------------------------------------Albums----------------------------------------
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album()
                {
                    Id = 1,
                    Name = "Master of Puppets",
                    BandID = 1,
                    Year = new DateTime(1986-03-03),
                    GenreID = 1
                },
                new Album()
                {
                    Id = 2,
                    Name = "Californication",
                    BandID = 2,
                    Year = new DateTime(1986-03-03),
                    GenreID = 2
                },
                new Album()
                {
                    Id = 3,
                    Name = "Beautiful Trauma",
                    BandID = 3,
                    Year = new DateTime(1986-03-03),
                    GenreID = 3
                },
                new Album()
                {
                    Id = 4,
                    Name = "Bangerz",
                    BandID = 4,
                    Year = new DateTime(1986-03-03),
                    GenreID = 3
                },
                new Album()
                {
                    Id = 5,
                    Name = "Blurryface",
                    BandID = 5,
                    Year = new DateTime(1986-03-03),
                    GenreID = 2
                },
                new Album()
                {
                    Id = 6,
                    Name = "A Night at the Opera",
                    BandID = 6,
                    Year = new DateTime(1986-03-03),
                    GenreID = 5
                },
                new Album()
                {
                    Id = 7,
                    Name = "The Eminem Show",
                    BandID = 7,
                    Year = new DateTime(1986-03-03),
                    GenreID = 6
                },
                new Album()
                {
                    Id = 8,
                    Name = "Slippery When Wet",
                    BandID = 8,
                    Year = new DateTime(1986-03-03),
                    GenreID = 1
                },
                new Album()
                {
                    Id = 9,
                    Name = "Divide",
                    BandID = 9,
                    Year = new DateTime(1986-03-03),
                    GenreID = 3
                },
                new Album()
                {
                    Id = 10,
                    Name = "Fireworks & Rollerblades",
                    BandID = 10,
                    Year = new DateTime(1986-03-03),
                    GenreID = 4
                }
            });

            //-----------------------------------------------------------------------------------------tracks---------------------------------

            //---Metallica-- Master of Puppets
            modelBuilder.Entity<Track>().HasData(new Track[]
            {
                new Track()
                {
                    Id = 1,
                    Name = "Battery",
                    AlbumID = 1,
                    Duration = new TimeSpan(0,5,13)
                },
                new Track()
                {
                    Id = 2,
                    Name = "Master of Puppets",
                    AlbumID = 1,
                    Duration = new TimeSpan(0,8,36)
                },
                new Track()
                {
                    Id = 3,
                    Name = "Welcome Home (Sanitarium)",
                    AlbumID = 1,
                    Duration = new TimeSpan(0,6,27)
                },
                new Track()
                {
                    Id = 4,
                    Name = "Disposable Heroes",
                    AlbumID = 1,
                    Duration = new TimeSpan(0,8,16)
                },
                new Track()
                {
                    Id = 5,
                    Name = "Leper Messiah",
                    AlbumID = 1,
                    Duration = new TimeSpan(0,5,39)
                },
                new Track()
                {
                    Id = 6,
                    Name = "Orion",
                    AlbumID = 1,
                    Duration = new TimeSpan(0,8,27)
                },
                new Track()
                {
                    Id = 7,
                    Name = "Damage, Inc.",
                    AlbumID = 1,
                    Duration = new TimeSpan(0,5,32)
                },

                // -------- Red Hot Chili Peppers------------
                new Track()
                {
                    Id = 8,
                    Name = "Around the World",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,3,58)
                },
                new Track()
                {
                    Id = 9,
                    Name = "Parallel Universe",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,4,30)
                },
                new Track()
                {
                    Id = 10,
                    Name = "Scar Tissue",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,3,37)
                },
                new Track()
                {
                    Id = 11,
                    Name = "Otherside",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,4,15)
                },
                new Track()
                {
                    Id = 12,
                    Name = "Get on Top",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,3,18)
                },
                new Track()
                {
                    Id = 13,
                    Name = "Californication",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,5,20)
                },
                new Track()
                {
                    Id = 14,
                    Name = "Easily",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,3,51)
                },
                new Track()
                {
                    Id = 15,
                    Name = "Porcelain",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,2,43)
                },
                new Track()
                {
                    Id = 16,
                    Name = "Emit Remus",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,4,0)
                },
                new Track()
                {
                    Id = 17,
                    Name = "I Like Dirt",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,2,37)
                },
                new Track()
                {
                    Id = 18,
                    Name = "This Velvet Glove",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,3,45)
                },
                new Track()
                {
                    Id = 19,
                    Name = "Savior",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,4,52)
                },
                new Track()
                {
                    Id = 20,
                    Name = "Purple Stain",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,4,13)
                },
                new Track()
                {
                    Id = 21,
                    Name = "Right on Time",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,1,52)
                },
                new Track()
                {
                    Id = 22,
                    Name = "Road Trippin",
                    AlbumID = 2,
                    Duration = new TimeSpan(0,3,25)
                }

            });



                

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DbSet<Band> Bands { get; set;}
        public DbSet<Country> Countries { get; set;}
        public DbSet<Album> Albums { get; set;}
        public DbSet<Genre> Genres { get; set;}
        public DbSet<Track> Tracks { get; set;}
        public DbSet<Playlist> PlayLists { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<TrackPlaylist> TrackPlaylists { get; set;}
    }
}
