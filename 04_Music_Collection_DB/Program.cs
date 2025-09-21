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
            
            context.Database.Migrate();           //the way to migrate database to sql

            //Add-Migration name        ====>         in the Manager console  is ThreadExceptionEventArgs second way to migrate data
        }
    }
}
