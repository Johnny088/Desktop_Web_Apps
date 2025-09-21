using System.ComponentModel.DataAnnotations;

class Band
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public Country Country { get; set; } // one Band to one Country
    public int CountryID { get; set; }
    public ICollection<Album> Albums { get; set; }


}
