namespace _05_OlympicsDataAccess.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CountryTeam CountryTeam { get; set; }
        public int CountyTeamID { get; set; }
        public NameOfGame NameOfGame { get; set; }
        public int NameOfGameID { get; set; }
        public ICollection<Award> Awards { get; set; }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }


    }

}
