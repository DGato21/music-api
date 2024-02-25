using Data.Gateway.SpotifyAPI.DTO;
using Infrastructure.Configuration;

namespace Data.Gateway.SpotifyAPI.Mappers
{
    internal static class SpotifyAPIMappers
    {
        public static RequestAuthentication ToRequestAuthentication(this SpotifyConfiguration spotifyGateway)
        {
            return new RequestAuthentication(spotifyGateway.authenticationUrl, spotifyGateway.clientId, spotifyGateway.clientSecret);
        }
    }
}
