using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Final_work
{
    public class Olympic
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Country Country { get; set; }
        public int CountyID { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Olympic Olympic { get; set; }
        public ICollection<Olympic> Olympics { get; set; }
        public ICollection<Player> Players { get; set; }


    }
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Country Country{ get; set; }
        public int CountyID { get; set; }
        public NameOfGame NameOfGames { get; set; }
    }
    public class NameOfGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
        public Season Season { get; set; }
        public ICollection<Aword> Awords { get; set; }              // if it is really need many to many?
    }

    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ICollection<NameOfGame> NameOfGames { get; set; }

    }
    public class TypeOfMedal
    {
        public int Id { get; set; }
        public string TypeOfTheMedal { get; set; }
    }
    public class Aword
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public ICollection<NameOfGame> NameOfGames { get; set; }  //one to many
    }





















    internal class OlympicsGamesDbContext
    {
    }

}
