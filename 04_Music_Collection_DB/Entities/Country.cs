using System.ComponentModel.DataAnnotations;

class Country
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }

    public ICollection<Band> Bands { get; set; }
}
