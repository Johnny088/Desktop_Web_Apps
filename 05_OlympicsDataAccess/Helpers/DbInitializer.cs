using _05_OlympicsDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _05_OlympicsDataAccess.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedCountryHost(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryHost>().HasData(new CountryHost[]
            {
                new CountryHost()
                {
                    Id = 1,
                    Name = "France"
                },
                new CountryHost()
                {
                    Id = 2,
                    Name = "Japan"
                },
                new CountryHost()
                {
                    Id = 3,
                    Name = "Canada"
                },
                new CountryHost()
                {
                    Id = 4,
                    Name = "The USA"
                },
                new CountryHost()
                {
                    Id = 5,
                    Name = "England"
                }
            });

        }
        public static void SeedCountryTeam(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryTeam>().HasData(new CountryTeam[]
            {
                new CountryTeam()
                {
                    Id = 1,
                    Name = "The USA"
                },
                new CountryTeam()
                {
                    Id = 2,
                    Name = "France"
                },
                new CountryTeam()
                {
                    Id = 3,
                    Name = "Japan"
                },
                new CountryTeam()
                {
                    Id = 4,
                    Name = "England"
                },
                new CountryTeam()
                {
                    Id = 5,
                    Name = "Canada"
                },
            });
        }
        public static void SeedMedal(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medal>().HasData(new Medal[] 
            {
                new Medal()
                {
                    Id = 1,
                    TypeOfMedal = "Gold"
                },
                new Medal()
                {
                    Id = 2,
                    TypeOfMedal = "Silver"
                },
                new Medal()
                {
                    Id = 3,
                    TypeOfMedal = "Bronze"
                },
            });
        }
        public static void SeedNameOfTheGame(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NameOfGame>().HasData(new NameOfGame[]
            {
                new NameOfGame()
                {
                    Id = 1,
                    Name ="Surfing"   //Japan 2020 Paris 2024 
                },
                new NameOfGame()
                {
                    Id = 2,
                    Name ="Skateboarding" // Japan 2020 Paris 2024 Japan 2020
                },
                new NameOfGame()
                {
                    Id = 3,
                    Name = "BMX Freestyle" //Paris 2024
                },
                new NameOfGame()
                {
                    Id = 4,
                    Name ="Snowboarding" //USA 2002  Canada 2010
                },
                new NameOfGame()
                {
                    Id = 5,
                    Name ="Snowboarding Halfpipe" //USA 2002  Canada 2010
                },
            });
        }
        public static void SeedSeason(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>().HasData(new Season[]
            {
                new Season()
                {
                    Id = 1,
                    Type = "Summer"
                },
                new Season()
                {
                    Id = 2,
                    Type = "Winter"
                }
            });
        }
        public static void SeedOlympic(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Olympic>().HasData(new Olympic[]
            {
                new Olympic()
                {
                    Id = 1,
                    StartDate = new DateTime(2024,7,24),
                    EndDate = new DateTime(2024,8,11),
                    CountyHostID = 1,
                    SeasonID = 1
                },
                new Olympic()
                {
                    Id = 2,
                    StartDate = new DateTime(2021,7,23),
                    EndDate = new DateTime(2021,8,8),
                    CountyHostID = 2,
                    SeasonID = 1
                },
                new Olympic()
                {
                    Id = 3,
                    StartDate = new DateTime(2010,2,12),
                    EndDate = new DateTime(2010,2,28),
                    CountyHostID = 3,
                    SeasonID = 2
                },
                new Olympic()
                {
                    Id = 4,
                    StartDate = new DateTime(2002,2,8),
                    EndDate = new DateTime(2002,2,24),
                    CountyHostID = 4,
                    SeasonID = 2
                },
                new Olympic()
                {
                    Id = 5,
                    StartDate = new DateTime(2012,7,27),
                    EndDate = new DateTime(2012,8,12),
                    CountyHostID = 5,
                    SeasonID = 2
                }

            });
        }

        public static void SeedPlayer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(new Player[]
            {
                //-------------------------------------------------France 2024----------------------------------------------------
                new Player()
                {
                    Id = 1,
                    Name = "Kauli",
                    Surname = "Vaast",
                    CountyTeamID = 2,
                    NameOfGameID = 1 //gold
                },
                new Player()
                {
                    Id = 2,
                    Name = "Caroline",
                    Surname = "Marks",
                    CountyTeamID = 1,
                    NameOfGameID = 1  //gold
                },
                new Player()
                {
                    Id = 3,
                    Name = "Johanne",
                    Surname = "Defay",
                    CountyTeamID = 2,
                    NameOfGameID = 1 // bronze
                },
                new Player()
                {
                    Id = 4,
                    Name = "Yuto",
                    Surname = "Horigome",
                    CountyTeamID = 3,
                    NameOfGameID = 2 //gold  /gold Japan 2020
                },
                new Player()
                {
                    Id = 5,
                    Name = "Jagger",
                    Surname = "Eaton",
                    CountyTeamID = 1,
                    NameOfGameID = 2 //silver  /bronze Japan
                },
                 new Player()
                {
                    Id = 6,
                    Name = "Nyjah",
                    Surname = "Huston",
                    CountyTeamID = 1,
                    NameOfGameID = 2 //bronze
                },
                  new Player()
                {
                    Id = 7,
                    Name = "Cocona",
                    Surname = "Hiraki",
                    CountyTeamID = 3,
                    NameOfGameID = 2 //silver   //Silver (Japan)
                },
                  new Player()
                {
                    Id = 8,
                    Name = "Sky",
                    Surname = "Brown",
                    CountyTeamID = 4,
                    NameOfGameID = 2 //bronze   //Bronze Japan
                },
                  new Player()
                {
                    Id = 9,
                    Name = "Kieran",
                    Surname = "Reilly",
                    CountyTeamID = 4,
                    NameOfGameID = 3 //silver
                },
                  new Player()
                {
                    Id = 10,
                    Name = "Anthony",
                    Surname = "Jeanjean",
                    CountyTeamID = 2,
                    NameOfGameID = 3 //bronze
                },
                  new Player()
                {
                    Id = 11,
                    Name = "Perris",
                    Surname = "Benegas",
                    CountyTeamID = 1,
                    NameOfGameID = 3 //silver
                },
                  //------------------------------------------------------Japan 2020--------------------------------------------------
                  new Player()
                {
                    Id = 12,
                    Name = "Kanoa",
                    Surname = "Igarashi",
                    CountyTeamID = 3,
                    NameOfGameID = 1 //silver
                },
                  new Player()
                {
                    Id = 13,
                    Name = "Carissa",
                    Surname = "Moore",
                    CountyTeamID = 1,
                    NameOfGameID = 1 //Gold
                },
                  new Player()
                {
                    Id = 14,
                    Name = "Amuro",
                    Surname = "Tsuzuki",
                    CountyTeamID = 3,
                    NameOfGameID = 1 //bronze
                },
                  new Player()
                {
                    Id = 15,
                    Name = "Sakura",
                    Surname = "Yosozumi",
                    CountyTeamID = 3,
                    NameOfGameID = 2 //Gold (Japan).
                },
                  new Player()
                {
                    Id = 16,
                    Name = "Declan",
                    Surname = "Brooks",
                    CountyTeamID = 4,
                    NameOfGameID = 3 // Bronze (Great Britain).
                },
                  new Player()
                {
                    Id = 17,
                    Name = "Charlotte",
                    Surname = "Worthington",
                    CountyTeamID = 4,
                    NameOfGameID = 3 //Gold (Great Britain)
                },
                  new Player()
                {
                    Id = 18,
                    Name = "Hannah",
                    Surname = "Roberts",
                    CountyTeamID = 1,
                    NameOfGameID = 3 // Silver (USA)
                },
                  //------------------------------------------------------Canada 2010--------------------------------------------
                  new Player()
                {
                    Id = 19,
                    Name = "Seth",
                    Surname = "Wescott",
                    CountyTeamID = 1,
                    NameOfGameID = 4 //   — Gold (USA).
                },
                  new Player()
                {
                    Id = 20,
                    Name = "Mike",
                    Surname = "Robertson",
                    CountyTeamID = 5,
                    NameOfGameID = 4 // Silver (Canada).
                },
                  new Player()
                {
                    Id = 21,
                    Name = "Tony",
                    Surname = "Ramoin",
                    CountyTeamID = 2,
                    NameOfGameID = 4 //Bronze (France)
                },
                  new Player()
                {
                    Id = 22,
                    Name = "Shaun",
                    Surname = "White",
                    CountyTeamID = 1,
                    NameOfGameID = 5 //Gold (USA).
                },
                  new Player()
                {
                    Id = 23,
                    Name = "Scott",
                    Surname = "Lago",
                    CountyTeamID = 1,
                    NameOfGameID = 5 //   Bronze (USA).
                },
                  new Player()
                {
                    Id = 24,
                    Name = "Hannah",
                    Surname = "Teter",
                    CountyTeamID = 1,
                    NameOfGameID = 5 //    Silver (USA).
                },
                  new Player()
                {
                    Id = 25,
                    Name = "Kelly",
                    Surname = "Clark",
                    CountyTeamID = 1,
                    NameOfGameID = 5 //      — Bronze (USA)    Gold (USA).
                },
                  //-----------------------------------------------------Salt Lake City 2002 (USA)---------------------------------
                  new Player()
                {
                    Id = 26,
                    Name = "Ross",
                    Surname = "Powers",
                    CountyTeamID = 1,
                    NameOfGameID = 5 //    Gold (USA).
                },
                  new Player()
                {
                    Id = 27,
                    Name = "Danny",
                    Surname = "Kass",
                    CountyTeamID = 1,
                    NameOfGameID = 5 //    Silver (USA).
                },
                  new Player()
                {
                    Id = 28,
                    Name = "Jarret (J.J.)",
                    Surname = "Thomas",
                    CountyTeamID = 1,
                    NameOfGameID = 5 //  Bronze (USA)
                },
                  new Player()
                {
                    Id = 29,
                    Name = "Doriane",
                    Surname = "Vidal",
                    CountyTeamID = 2,
                    NameOfGameID = 5 //  Silver (France)
                },



            }); // 1 - The USA 2 - France  3 - Japan  4 - England 5 - Canada                        

            //1 -surfing 2 -skateboarding 3 - bmx freestyle 4 - Snowboarding /5 - Snowboarding halfpipe
        }
        public static void SeedAward(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>().HasData(new Award[] 
            {
                //---------------------------------------------------------France------------------------------------
                new Award()
                {
                    Id = 1,
                    MedalID = 1,
                    OlympicID = 1,
                    PlayerID = 1
                },
                new Award()
                {
                    Id = 2,
                    MedalID = 1,
                    OlympicID = 1,
                    PlayerID = 2
                },
                new Award()
                {
                    Id = 3,
                    MedalID = 3,
                    OlympicID = 1,
                    PlayerID = 3
                },
                new Award()
                {
                    Id = 4,
                    MedalID = 1,
                    OlympicID = 1,
                    PlayerID = 4
                },
                new Award()
                {
                    Id = 5,
                    MedalID = 2,
                    OlympicID = 1,
                    PlayerID = 5
                },
                new Award()
                {
                    Id = 6,
                    MedalID = 3,
                    OlympicID = 1,
                    PlayerID = 6
                },
                new Award()
                {
                    Id = 7,
                    MedalID = 2,
                    OlympicID = 1,
                    PlayerID = 7
                },
                new Award()
                {
                    Id = 8,
                    MedalID = 3,
                    OlympicID = 1,
                    PlayerID = 8
                },
                new Award()
                {
                    Id = 9,
                    MedalID = 2,
                    OlympicID = 1,
                    PlayerID = 9
                },
                new Award()
                {
                    Id = 10,
                    MedalID = 3,
                    OlympicID = 1,
                    PlayerID = 10
                },
                new Award()
                {
                    Id = 11,
                    MedalID = 2,
                    OlympicID = 1,
                    PlayerID = 11
                },
                //---------------------------------------------------Japan------------------------------------------
                new Award()
                {
                    Id = 12,
                    MedalID = 1,
                    OlympicID = 2,
                    PlayerID = 4
                },
                new Award()
                {
                    Id = 13,
                    MedalID = 3,
                    OlympicID = 2,
                    PlayerID = 5
                },
                new Award()
                {
                    Id = 14,
                    MedalID = 2,
                    OlympicID = 2,
                    PlayerID = 7
                },
                new Award()
                {
                    Id = 15,
                    MedalID = 3,
                    OlympicID = 2,
                    PlayerID = 8
                },
                new Award()
                {
                    Id = 16,
                    MedalID = 2,
                    OlympicID = 2,
                    PlayerID = 12
                },
                new Award()
                {
                    Id = 17,
                    MedalID = 1,
                    OlympicID = 2,
                    PlayerID = 13
                },
                new Award()
                {
                    Id = 18,
                    MedalID = 3,
                    OlympicID = 2,
                    PlayerID = 14
                },
                new Award()
                {
                    Id = 19,
                    MedalID = 1,
                    OlympicID = 2,
                    PlayerID = 15
                },
                new Award()
                {
                    Id = 20,
                    MedalID = 3,
                    OlympicID = 2,
                    PlayerID = 16
                },
                new Award()
                {
                    Id = 21,
                    MedalID = 1,
                    OlympicID = 2,
                    PlayerID = 17
                },
                new Award()
                {
                    Id = 22,
                    MedalID = 2,
                    OlympicID = 2,
                    PlayerID = 18
                },
                //------------------------------------------------------Canada 2010--------------------------------------------
                new Award()
                {
                    Id = 23,
                    MedalID = 1,
                    OlympicID = 3,
                    PlayerID = 19
                },
                new Award()
                {
                    Id = 24,
                    MedalID = 3,
                    OlympicID = 2,
                    PlayerID = 20
                },
                new Award()
                {
                    Id = 25,
                    MedalID = 3,
                    OlympicID = 3,
                    PlayerID = 21
                },
                new Award()
                {
                    Id = 26,
                    MedalID = 1,
                    OlympicID = 3,
                    PlayerID = 22
                },
                new Award()
                {
                    Id = 27,
                    MedalID = 3,
                    OlympicID = 3,
                    PlayerID = 23
                },
                new Award()
                {
                    Id = 28,
                    MedalID = 2,
                    OlympicID = 3,
                    PlayerID = 24
                },
                new Award()
                {
                    Id = 29,
                    MedalID = 3,
                    OlympicID = 3,
                    PlayerID = 25
                },
                //-----------------------------------------------------Salt Lake City 2002 (The USA)---------------------------------
                new Award()
                {
                    Id = 30,
                    MedalID = 1,
                    OlympicID = 4,
                    PlayerID = 25
                },
                new Award()
                {
                    Id = 31,
                    MedalID = 1,
                    OlympicID = 4,
                    PlayerID = 26
                },
                new Award()
                {
                    Id = 32,
                    MedalID = 2,
                    OlympicID = 4,
                    PlayerID = 27
                },
                new Award()
                {
                    Id = 33,
                    MedalID = 3,
                    OlympicID = 4,
                    PlayerID = 28
                },
                new Award()
                {
                    Id = 34,
                    MedalID = 2,
                    OlympicID = 4,
                    PlayerID = 29
                },

            });
        }
    }
}
