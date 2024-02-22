using Data.Gateway.SpotifyAPI.DTO;

namespace Data.Gateway.SpotifyAPI.Mappers
{
    internal static class SpotifyAPIMappers
    {
        public static RequestAuthentication ToRequestAuthentication(this SpotifyGateway spotifyGateway)
        {
            return new RequestAuthentication(spotifyGateway.clientId, spotifyGateway.clientSecret);
        }
    }
}
