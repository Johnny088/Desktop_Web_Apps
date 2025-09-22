using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Configuration;
namespace _04_Music_Collection_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicalCollectionDbContext context = new MusicalCollectionDbContext();
            
            context.Database.Migrate();           //the way to update our Database
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The data was migrated");
            Console.ResetColor();
            //Add-Migration name        ====>         in the Manager console  is The second way to migrate data but this way creates the template
            // then we need  'update-database' And our database appears on the sql server

            //-------------------changing------------
            //if we need to change our existing database we need need to update this way ===> add-migration (name what we did example addColumnRating)
        }
    }
}
