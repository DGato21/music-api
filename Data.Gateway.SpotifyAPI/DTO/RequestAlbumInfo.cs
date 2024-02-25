namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestAlbumInfo : RequestBase
    {
        public string albumId { get; set; }

        public RequestAlbumInfo(string baseUrl, string albumId) : base(baseUrl)
        {
            this.albumId = albumId;
        }
    }
}
