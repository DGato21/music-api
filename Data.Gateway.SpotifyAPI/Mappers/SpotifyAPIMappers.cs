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

        public static RequestAuthenticationAuthorizationCode ToRequestAuthenticationAccessToken(this SpotifyConfiguration spotifyGateway, string code)
        {
            return new RequestAuthenticationAuthorizationCode(spotifyGateway.authenticationUrl, spotifyGateway.clientId, spotifyGateway.clientSecret, code, spotifyGateway.redirectUrl);
        }
    }
}
