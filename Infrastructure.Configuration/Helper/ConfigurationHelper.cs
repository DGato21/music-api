using Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Helper
{
    public static class ConfigurationHelper
    {
        public static SpotifyConfiguration SpotifyConfigurator(IConfiguration configuration)
        {
            return new SpotifyConfiguration
            {
                clientId = configuration.GetValue<string>($"{SpotifyConfiguration.SpotifyConfigurationBasePath}:clientId"),
                clientSecret = configuration.GetValue<string>($"{SpotifyConfiguration.SpotifyConfigurationBasePath}:clientSecret"),
                baseUrl = configuration.GetValue<string>($"{SpotifyConfiguration.SpotifyConfigurationBasePath}:baseUrl"),
                authenticationUrl = configuration.GetValue<string>($"{SpotifyConfiguration.SpotifyConfigurationBasePath}:authenticationUrl")
            };
        }
    }
}
