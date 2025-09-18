using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Configuration;
namespace _04_Music_Collection_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicalCollectionDbContext context = new MusicalCollectionDbContext();
            context.Bands.Add(new Band()
            {
            });
            //string temp = ConfigurationManager.ConnectionStrings["MusicDBConnection"].ConnectionString;
            //Console.WriteLine(temp);
        }
    }
}
