using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Music_Collection_DB
{
    // first we need to add a class by using "add new item"
    //we need to set up Entity Framework core and Entity Framework COre SqlServer
    internal class MusicalCollectionDbContext :DbContext //to connect to our Base
    {
        public MusicalCollectionDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // we need it too connect to data base
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }
        //Band   a Band has one Country, one Country has many Bands
        //Albom
        //track
        //Playlist
        public DbSet<Band> Bands { get; set; }
    }
}
class Band
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; } // one Band to one Country
    public int CountryID { get; set; }

}

class Country
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Country> Bands { get; set; }
}

class Albom
{

}

class Track
{

}

class PlayList
{

}