namespace Data.Gateway.SpotifyAPI.DTO
{
    public class AuthenticationClientResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public double expires_in { get; set; }
    }
}
