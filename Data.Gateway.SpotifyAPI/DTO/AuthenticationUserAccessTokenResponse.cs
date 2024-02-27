namespace Data.Gateway.SpotifyAPI.DTO
{
    public class AuthenticationUserAccessTokenResponse : AuthenticationClientResponse
    {
        public string scope { get; set; }
        public string refresh_token { get; set; }
    }
}
