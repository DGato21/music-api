using Infrastructure.CrossCutting;
using Infrastructure.Extensions;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestAuthenticationUser : RequestAuthenticationClient
    {
        public string response_type { get; set; } = "code";
        public string redirect_uri { get; set; }
        public string state { get; set; }
        public string scope { get; set; }
        public bool show_dialog { get; set; } = false;

        public RequestAuthenticationUser(string baseUrl, string client_id, string client_secret, string scope, string redirectUrl) : base(baseUrl, client_id, client_secret)
        {
            this.scope = scope;
            this.redirect_uri = redirectUrl;
            this.state = "".RandomString(16);
        }

        public string getAuthQuery() => UrlMethods.QueryStringBuilder(this, new List<string>() { "response_type", "client_id", "scope", "redirect_uri" });
    }
}
