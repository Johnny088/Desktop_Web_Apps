using _05_OlympicsDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace _05_Final_work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OlympicsGamesDbContext context = new OlympicsGamesDbContext();
            //var test = context.Players.Include(p => p.NameOfGameID).Include(p => p.CountryTeam);//.Include(p => p.Awards).ThenInclude(p => p.Medal)
            //                                                                                    //.Include(p => p.Awards).ThenInclude(p =>p.Olympic);
            //var test = context.Awards.Include(a => a.Medal).Include(a => a.Olympic).ThenInclude(o => o.CountryHost).Include(a => a.Olympic).ThenInclude(o => o.Season)
            //    .Include(a => a.Player).ThenInclude(p => p.CountryTeam).Include(a => a.Player).ThenInclude(p => p.NameOfGame).Where<CountryHost>(a => a.Name == "Japan");
            var test = context.Medals.Include(m => m.Awards).ThenInclude(a => a.Olympic).ThenInclude(o => o.CountryHost);
            var test2 = context.CountryHosts.Include(c => c.Olympics).ThenInclude(o => o.Awards).ThenInclude(a => a.Medal).Where(c => c.Name == "Japan");
            //.Include(c => c.Olympics).ThenInclude(o => o.);
            var test3 = context.Awards.Include(m => m.Medal).Include(a => a.Player).ThenInclude(p => p.CountryTeam)
                .Include(m => m.Olympic).ThenInclude(o => o.CountryHost).Where(ch => ch.Olympic.CountryHost.Name == "Japan");


            foreach (var item in test3)
            {
                Console.WriteLine($"Country: {item.Player.CountryTeam.Name} \t\tMedals: {item.Medal.TypeOfMedal}");
            }
        }
    }

}
