using Domain.DTO.Enum;

namespace Domain.DTO
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Stock { get; set;}
        public byte[] Cover { get; set;}
        public AlbumType Type { get; set; }
    }
}
