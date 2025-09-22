using System.ComponentModel.DataAnnotations;

class Track
{
    public  int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public Album Album { get; set; }
    public int AlbumID { get; set; }
    public TimeSpan Duration { get; set; }
    public ICollection<TrackPlaylist> TrackPlaylists { get; set; }
    public double Rating { get; set; }
    public long PlayCount { get; set; }
    [MaxLength(100)]
    public string? Lyrics { get; set; }
}
