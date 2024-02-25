using Infrastructure.Services.Helper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration.Factories
{
    public class SpotifyFactory
    {
        private readonly SpotifyConfiguration spotifyConfiguration;

        public SpotifyFactory(IConfiguration configuration)
        {
            this.spotifyConfiguration = ConfigurationHelper.SpotifyConfigurator(configuration);
        }

        public SpotifyConfiguration GetSpotifyConfiguration() => this.spotifyConfiguration;
    }
}
