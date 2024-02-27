using Infrastructure.Extensions;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestAuthenticationUserAccessToken : RequestAuthenticationClient
    {
        public string code { get; set; } = null;
        public string redirect_uri { get; set; } = null;

        /// <summary>
        /// For Authorization Code
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        public RequestAuthenticationUserAccessToken(string baseUrl, string client_id, string client_secret, string code, string redirect_uri) : base(baseUrl, client_id, client_secret)
        {
            base.client_id = client_id;
            base.client_secret = client_secret;
            this.code = code;
            this.redirect_uri = redirect_uri;
            grant_type = "authorization_code";
        }

        public string getAuthHeader => string.Concat("Basic ", $"{base.client_id}:{base.client_secret}".ToBase64Encode());

    }
}
