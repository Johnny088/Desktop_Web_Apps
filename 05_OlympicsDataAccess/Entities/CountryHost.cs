namespace _05_OlympicsDataAccess.Entities
{
    public class CountryHost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Olympic> Olympics { get; set; }
    }

}
