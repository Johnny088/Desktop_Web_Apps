using System.ComponentModel.DataAnnotations;

class Category
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public ICollection<Playlist> Playlists { get; set; }
}