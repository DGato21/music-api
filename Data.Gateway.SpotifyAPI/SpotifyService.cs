using Data.Gateway.SpotifyAPI.Interfaces;
using Data.Gateway.SpotifyAPI.Mappers;
using Microsoft.Extensions.Configuration;

namespace Data.Gateway.SpotifyAPI
{
    public class SpotifyService : ISpotifyService
    {
        private readonly ISpotifyClient spotifyClient;

        public SpotifyService(SpotifyGateway spotifyGateway, ISpotifyClient spotifyClient)
        {
            this.spotifyClient = spotifyClient;

            authenticateClient(spotifyGateway);
        }

        private void authenticateClient(SpotifyGateway spotifyGateway)
        {
            this.spotifyClient.Authenticate(spotifyGateway.ToRequestAuthentication());
        }

        public Task<string> FetchAlbumInfo(string albumId)
        {
            throw new NotImplementedException();
        }

        public Task<string> FetchArtistInfo(string artistId)
        {
            throw new NotImplementedException();
        }

        public Task<string> FetchMusicInfo(string musicId)
        {
            throw new NotImplementedException();
        }
    }
}
