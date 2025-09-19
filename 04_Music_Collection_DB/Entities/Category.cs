class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Playlist> Playlists { get; set; }
}