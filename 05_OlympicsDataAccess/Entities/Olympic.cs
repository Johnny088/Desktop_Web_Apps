namespace _05_OlympicsDataAccess.Entities
{
    public class Olympic
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CountryHost CountryHost { get; set; }
        public int CountyHostID { get; set; }
        public Season Season { get; set; }
        public int SeasonID { get; set; }
        public ICollection<Award> Awards { get; set; }
    }

}
