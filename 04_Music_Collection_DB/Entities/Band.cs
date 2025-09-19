class Band
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; } // one Band to one Country
    public int CountryID { get; set; }
    public ICollection<Albom> Alboms { get; set; }


}
