using System.ComponentModel.DataAnnotations;

class Genre
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public ICollection<Album> Albums { get; set; }
}
