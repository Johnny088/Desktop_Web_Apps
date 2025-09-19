class Playlist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public int CategoryID { get; set; }
    public ICollection<TrackPlaylist> TrackPlaylists { get; set; }

}
