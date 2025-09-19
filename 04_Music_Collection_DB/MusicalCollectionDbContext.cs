using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;

namespace _04_Music_Collection_DB
{
    // first we need to add a class by using "add new item"
    //we need to set up Entity Framework core and Entity Framework COre SqlServer
    internal class MusicalCollectionDbContext :DbContext //to connect to our Base
    {
        public string connectionString { get; set; }
        public MusicalCollectionDbContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MusicDBConnection"].ConnectionString;
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // we need it too connect to data base
        {
            //we need to set up configuration manager from NuGet
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        //Band   a Band has one Country, one Country has many Bands
        //Albom
        //track
        //Playlist
        public DbSet<Band> Bands { get; set;}
        public DbSet<Country> Countries { get; set;}
        public DbSet<Albom> Alboms { get; set;}
        public DbSet<Genre> Genres { get; set;}
        public DbSet<Track> Tracks { get; set;}
        public DbSet<PlayList> PlayLists { get; set;}
        public DbSet<Category> Categories { get; set;}
    }
}
class Band
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; } // one Band to one Country
    public int CountryID { get; set; }
    public ICollection<Albom> Alboms { get; set; }


}

class Country
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Band> Bands { get; set; }
}

class Albom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Band Band { get; set; }
    public int BandID { get; set; }
    public DateTime Year { get; set; }
    public Genre Genre { get; set; }
    public int GenreID { get; set; }
    public ICollection<Track> Tracks { get; set; }

}

class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Albom> Alboms { get; set; }
}

class Track
{
    public  int Id { get; set; }
    public string Name { get; set; }
    public Albom Albom { get; set; }
    public int AlbomID { get; set; }
    public TimeSpan Duration { get; set; }
}

class PlayList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public int CategoryID { get; set; }

}
class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<PlayList> PlayLists { get; set; }
}