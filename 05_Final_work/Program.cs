using _05_OlympicsDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace _05_Final_work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OlympicsGamesDbContext context = new OlympicsGamesDbContext();
            var test = context.Awards.Include(m => m.Medal).Include(a => a.Player).ThenInclude(p => p.CountryTeam)
                .Include(m => m.Olympic).ThenInclude(o => o.CountryHost).Where(ch => ch.Olympic.CountryHost.Name == "Japan");
            foreach (var item in test)
            {
                Console.WriteLine($"Country: {item.Player.CountryTeam.Name,10} \t\tMedals: {item.Medal.TypeOfMedal}");
            }
            var result3 = context.Awards.Include(m => m.Medal).Include(a => a.Player).ThenInclude(p => p.CountryTeam)
                .Include(m => m.Olympic).ThenInclude(o => o.CountryHost).Where(ch => ch.Olympic.CountryHost.Name == "Japan").GroupBy(a => a.Player.CountryTeam.Name);
            foreach (var item in result3)
            {
                //Console.WriteLine($"Country: {item.} \t\tMedals: {123}");
            }
        }
    }

}
