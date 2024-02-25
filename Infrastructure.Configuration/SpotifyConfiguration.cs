using Microsoft.Extensions.Options;

namespace Infrastructure.Configuration
{
    public class SpotifyConfiguration
    {
        public const string SpotifyConfigurationBasePath = "Dependencies:Services:SpotifyAPI";
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string baseUrl { get; set; }
        public string authenticationUrl { get; set; }
    }
}
