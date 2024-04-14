namespace Data.Gateway.SpotifyAPI.DTO
{
    public class AuthenticationAuthorizationCodeResponse : AuthenticationClientResponse
    {
        public string scope { get; set; }
        public string refresh_token { get; set; }
    }
}
