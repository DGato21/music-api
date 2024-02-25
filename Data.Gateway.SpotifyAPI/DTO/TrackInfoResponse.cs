using Data.Gateway.SpotifyAPI.DTO.Auxiliar;
using Newtonsoft.Json;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class TrackInfoResponse : BaseResponse
    {
        public AlbumInfoResponse album { get; set; }
        public IEnumerable<ArtistInfoResponse> artists { get; set; }
        public IEnumerable<string> available_markets { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        [JsonProperty("explicit")]
        public bool explicit_track { get; set; }
        public bool is_playable { get; set; }
        public Restriction restriction { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
    }
}
