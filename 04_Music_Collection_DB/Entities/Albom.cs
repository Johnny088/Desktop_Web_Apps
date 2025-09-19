class Albom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Band Band { get; set; }
    public int BandID { get; set; }
    public DateTime Year { get; set; }
    public Genre Genre { get; set; }
    public int GenreID { get; set; }
    public ICollection<Track> Tracks { get; set; }

}
