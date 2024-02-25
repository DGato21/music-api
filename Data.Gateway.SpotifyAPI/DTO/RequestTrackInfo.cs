namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestTrackInfo : RequestBase
    {
        public string musicId { get; set; }
        public RequestTrackInfo(string baseUrl, string musicId) : base(baseUrl)
        {
            this.musicId = musicId;
        }
    }
}
