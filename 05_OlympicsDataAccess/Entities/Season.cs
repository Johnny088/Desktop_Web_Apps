namespace _05_OlympicsDataAccess.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Type { get; set; } 
        public ICollection<Olympic> Olympics { get; set; }

    }

}
