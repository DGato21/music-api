using Data.Gateway.SpotifyAPI.DTO.Auxiliar;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class AlbumInfoResponse : BaseResponse
    {
        public AlbumType album_type { get; set; }
        public int total_tracks { get; set; }
        public IEnumerable<string> available_markets { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public IEnumerable<Restriction> restrictions { get; set; }
        public IEnumerable<ArtistInfoResponse> artists { get; set; }
        public AlbumTrackInfoResponse tracks { get; set; }
        public IEnumerable<string> genres { get; set; }
        public ExternalIds external_ids { get; set; }
        public string label { get; set; }
    }

    public enum AlbumType
    {
        album,
        single,
        compilation
    }
}
