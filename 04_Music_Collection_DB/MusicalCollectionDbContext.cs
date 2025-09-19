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
        public DbSet<Playlist> PlayLists { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<TrackPlaylist> TrackPlaylists { get; set;}
    }
}
