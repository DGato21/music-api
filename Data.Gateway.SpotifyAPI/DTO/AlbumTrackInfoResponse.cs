namespace Data.Gateway.SpotifyAPI.DTO
{
    public class AlbumTrackInfoResponse
    {
        public IEnumerable<TrackInfoResponse> items { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int total { get; set; }
    }
}
