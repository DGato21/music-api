using Data.Gateway.SpotifyAPI.DTO.Auxiliar;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class ArtistInfoResponse : BaseResponse
    {
        public Followers followers { get; set; }
        public IEnumerable<string> genres { get; set; }
        public IEnumerable<Image> images { get; set; }
    }
}
