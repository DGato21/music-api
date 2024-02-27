namespace Data.Gateway.SpotifyAPI.DTO
{
    public class AuthenticationUserResponse
    {
        /// <summary>
        /// Authorization code that can be exchanged for an access token
        /// </summary>
        public string code { get; set; }

        public string state { get; set; }

        /// <summary>
        /// The reason authorization failed, for example: "access_denied"
        /// </summary>
        public string error { get; set; }
    }
}
