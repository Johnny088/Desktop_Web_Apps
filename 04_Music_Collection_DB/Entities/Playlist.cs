using System.ComponentModel.DataAnnotations;

class Playlist
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public Category Category { get; set; }
    public int CategoryID { get; set; }
    public ICollection<TrackPlaylist> TrackPlaylists { get; set; }

}
