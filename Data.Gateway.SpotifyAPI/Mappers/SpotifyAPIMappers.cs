using Data.Gateway.SpotifyAPI.DTO;
using Infrastructure.Configuration;

namespace Data.Gateway.SpotifyAPI.Mappers
{
    internal static class SpotifyAPIMappers
    {
        public static RequestAuthenticationClient ToRequestAuthenticationClient(this SpotifyConfiguration spotifyGateway)
        {
            return new RequestAuthenticationClient(spotifyGateway.authenticationUrl, spotifyGateway.clientId, spotifyGateway.clientSecret);
        }

        public static RequestAuthenticationUser ToRequestAuthenticationUser(this SpotifyConfiguration spotifyGateway)
        {
            return new RequestAuthenticationUser(spotifyGateway.authenticationUrl, spotifyGateway.clientId, spotifyGateway.clientSecret, spotifyGateway.scopes, spotifyGateway.redirectUrl);
        }

        public static RequestAuthenticationUserAccessToken ToRequestAuthenticationUserAccessToken(this SpotifyConfiguration spotifyGateway)
        {
            return new RequestAuthenticationUserAccessToken(spotifyGateway.authenticationUrl, spotifyGateway.clientId, spotifyGateway.clientSecret, spotifyGateway.scopes, spotifyGateway.redirectUrl);
        }
    }
}
