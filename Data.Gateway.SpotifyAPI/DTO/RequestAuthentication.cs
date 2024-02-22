namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestAuthentication
    {
        public string grantType { get; set; } = "client_credentials";
        public string clientId { get; set; }
        public string clientSecret { get; set; }

        public RequestAuthentication (string client_id, string client_secret)
        {
            this.clientId = client_id;
            this.clientSecret = client_secret;
        }

        public string getAuthBody => $"grant_type={this.grantType}&client_id={this.clientId}&client_secret={clientSecret}";
    }
}
