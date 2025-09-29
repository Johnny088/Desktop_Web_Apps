using _05_OlympicsDataAccess.Entities;
namespace _05_Final_work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OlympicsGamesDbContext context = new OlympicsGamesDbContext();
            context.Seasons.Add(new Season()
            {
                Id = 13,
                Type = "Test"
            });
        }
    }
    

}
