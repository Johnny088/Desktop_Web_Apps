using _05_OlympicsDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace _05_Final_work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OlympicsGamesDbContext context = new OlympicsGamesDbContext();
            var test = context.Players.Include(p => p.NameOfGameID).Include(p => p.CountryTeam);//.Include(p => p.Awards).ThenInclude(p => p.Medal)
                //.Include(p => p.Awards).ThenInclude(p =>p.Olympic);
            foreach(var item in test)
            {
                Console.WriteLine($"Name: {item.Name} Surname: {item.Surname}");
            }
        }
    }

}
