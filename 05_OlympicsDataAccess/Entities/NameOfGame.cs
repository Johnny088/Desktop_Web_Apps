namespace _05_OlympicsDataAccess.Entities
{
    public class NameOfGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
        
    }

}
