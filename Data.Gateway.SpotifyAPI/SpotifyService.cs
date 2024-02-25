using Data.Gateway.SpotifyAPI.Interfaces;
using Data.Gateway.SpotifyAPI.Mappers;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;

namespace Data.Gateway.SpotifyAPI
{
    public class SpotifyService : ISpotifyService
    {
        private readonly ISpotifyClient spotifyClient;

        public SpotifyService(ISpotifyClient spotifyClient, SpotifyFactory spotifyFactory)
        {
            this.spotifyClient = spotifyClient;

            if (spotifyFactory.GetSpotifyConfiguration() != null)
            {
                authenticateClient(spotifyFactory.GetSpotifyConfiguration());
            }
        }

        private async void authenticateClient(SpotifyConfiguration spotifyConfiguration)
        {
            await this.spotifyClient.Authenticate(spotifyConfiguration.ToRequestAuthentication());
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
