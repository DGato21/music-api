namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestArtistInfo : RequestBase
    {
        public string artistId { get; set; }

        public RequestArtistInfo(string baseUrl, string artistId) : base(baseUrl)
        {
            this.artistId = artistId;
        }
    }
}
