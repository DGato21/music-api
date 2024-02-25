namespace Data.Gateway.SpotifyAPI.DTO
{
    public abstract class RequestBase
    {
        public string baseUrl { get; set; }

        public RequestBase(string baseUrl) { this.baseUrl = baseUrl; }
    }
}
