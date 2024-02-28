using Data.Gateway.SpotifyAPI.DTO.Auxiliar;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class SearchInfoResponse : BaseResponse
    {
        public IEnumerable<AlbumInfoResponse> albumns { get; set; }
        public IEnumerable<TrackInfoResponse> tracks { get; set; }
        public IEnumerable<ArtistInfoResponse> artists { get; set; }

        //Remaining
    }
}