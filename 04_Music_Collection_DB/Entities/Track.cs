class Track
{
    public  int Id { get; set; }
    public string Name { get; set; }
    public Albom Albom { get; set; }
    public int AlbomID { get; set; }
    public TimeSpan Duration { get; set; }
    public ICollection<TrackPlaylist> TrackPlaylists { get; set; }
}
