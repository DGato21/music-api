using Data.Gateway.SpotifyAPI.Interfaces;
using Data.Gateway.SpotifyAPI.Mappers;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;
using Newtonsoft.Json;

namespace Data.Gateway.SpotifyAPI
{
    public class SpotifyService : ISpotifyService
    {
        private readonly ISpotifyClient spotifyClient;
        private readonly SpotifyConfiguration spotifyConfiguration;

        public SpotifyService(ISpotifyClient spotifyClient, SpotifyFactory spotifyFactory)
        {
            this.spotifyClient = spotifyClient;
            this.spotifyConfiguration = spotifyFactory.GetSpotifyConfiguration();

            //TODO: REMOVE FROM HERE AND DO A FACTORY FOR SPOTIFY SERVICE CALLING AUTH
            authenticateClient(this.spotifyConfiguration);
        }

        public async Task<string> FetchAlbumInfo(string albumId)
        {
            var response = await this.spotifyClient.FetchAlbumInfo(new DTO.RequestAlbumInfo(this.spotifyConfiguration.baseUrl, albumId));

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> FetchArtistInfo(string artistId)
        {
            var response = await this.spotifyClient.FetchArtistInfo(new DTO.RequestArtistInfo(this.spotifyConfiguration.baseUrl, artistId));

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> FetchTrackInfo(string musicId)
        {
            var response = await this.spotifyClient.FetchTrackInfo(new DTO.RequestTrackInfo(this.spotifyConfiguration.baseUrl, musicId));

            return JsonConvert.SerializeObject(response);
        }

        private async void authenticateClient(SpotifyConfiguration spotifyConfiguration)
        {
            await this.spotifyClient.Authenticate(spotifyConfiguration.ToRequestAuthentication());
        }
    }
}
