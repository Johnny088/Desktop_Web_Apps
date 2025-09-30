namespace _05_OlympicsDataAccess.Entities
{
    public class Medal
    {
        public int Id { get; set; }
        public string TypeOfMedal { get; set; }
        public ICollection<Award> Awards { get; set; }

    }

}
