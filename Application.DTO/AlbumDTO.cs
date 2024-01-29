namespace Application.DTO
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Stock { get; set; }
        public byte[] Cover { get; set; }
        public string Type { get; set; }
    }
}
