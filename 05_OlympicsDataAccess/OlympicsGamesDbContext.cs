using _05_OlympicsDataAccess.Entities;
using _05_OlympicsDataAccess.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Final_work
{


     class OlympicsGamesDbContext: DbContext
    {
        public string connectionString { get; set; }
        public OlympicsGamesDbContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["OlympicsDbConnection"].ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Required properties.
            modelBuilder.Entity<CountryHost>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CountryTeam>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<NameOfGame>().Property(n => n.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Player>().Property(p =>p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Player>().Property(p =>p.Surname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Season>().Property(s =>s.Type).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Medal>().Property(m =>m.TypeOfMedal).IsRequired().HasMaxLength(100);

            //friendship.
            modelBuilder.Entity<Award>().HasOne(a => a.Medal).WithMany(m => m.Awards).HasForeignKey(a =>a.MedalID);
            modelBuilder.Entity<Award>().HasOne(a => a.Olympic).WithMany(o => o.Awards).HasForeignKey(a => a.OlympicID);
            modelBuilder.Entity<Award>().HasOne(a => a.Player).WithMany(p => p.Awards).HasForeignKey(a => a.PlayerID);

            modelBuilder.Entity<CountryHost>().HasMany(c => c.Olympics).WithOne(o => o.CountryHost).HasForeignKey(o => o.CountyHostID);   // Country - Olympics
            modelBuilder.Entity<CountryTeam>().HasMany(c => c.Players).WithOne(p => p.CountryTeam).HasForeignKey(p => p.CountyTeamID);    //Country - Players

            modelBuilder.Entity<NameOfGame>().HasMany(n => n.Players).WithOne(p => p.NameOfGame).HasForeignKey(p => p.NameOfGameID);  //Type of game - Players

            modelBuilder.Entity<Olympic>().HasOne(o => o.Season).WithMany(s => s.Olympics).HasForeignKey(o => o.SeasonID);      // Olympic - Seasons

            //DbInitialized
            modelBuilder.SeedCountryHost();
            modelBuilder.SeedCountryTeam();
            modelBuilder.SeedSeason();
            modelBuilder.SeedMedal();
            modelBuilder.SeedNameOfTheGame();
            modelBuilder.SeedOlympic();
            modelBuilder.SeedPlayer();
            modelBuilder.SeedAward();
        }
        DbSet<CountryHost> CountryHosts { get; set; }
        DbSet<CountryTeam> CountryTeams { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Medal> Medals { get; set; }
        DbSet<NameOfGame> NameOfGames { get; set; }
        DbSet<Olympic> Olympics { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Award> Awards { get; set; }

    }

}
