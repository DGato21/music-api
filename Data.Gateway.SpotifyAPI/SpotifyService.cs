using Data.Gateway.SpotifyAPI.Interfaces;
using Data.Gateway.SpotifyAPI.Mappers;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;
using Infrastructure.Exceptions.Spotify;
using Newtonsoft.Json;

namespace Data.Gateway.SpotifyAPI
{
    //Library: https://github.com/Ringobot/SpotifyApi.NetCore

    public class SpotifyService : ISpotifyService
    {
        private readonly ISpotifyClient spotifyClient;
        private readonly SpotifyConfiguration spotifyConfiguration;
        private bool initializedClient;
        private bool initializedUser;

        private string state = null; //CHECK IF NEEDED STATE PER USER/TRANSACTION?

        public SpotifyService(ISpotifyClient spotifyClient, SpotifyFactory spotifyFactory)
        {
            this.spotifyClient = spotifyClient;
            this.spotifyConfiguration = spotifyFactory.GetSpotifyConfiguration();
            this.initializedClient = false;
            this.initializedUser = false;

            //TODO: REMOVE FROM HERE AND DO A FACTORY FOR SPOTIFY SERVICE CALLING AUTH
            //authenticateClient(this.spotifyConfiguration);
        }

        public async Task<string> FetchAlbumInfo(string albumId)
        {
            if (!initializedClient) { await authenticateClient(this.spotifyConfiguration); }
            var response = await this.spotifyClient.FetchAlbumInfo(new DTO.RequestAlbumInfo(this.spotifyConfiguration.baseUrl, albumId));

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> FetchArtistInfo(string artistId)
        {
            if (!initializedClient) { authenticateClient(this.spotifyConfiguration); }
            var response = await this.spotifyClient.FetchArtistInfo(new DTO.RequestArtistInfo(this.spotifyConfiguration.baseUrl, artistId));

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> FetchTrackInfo(string musicId)
        {
            if (!initializedClient) { authenticateClient(this.spotifyConfiguration); }
            var response = await this.spotifyClient.FetchTrackInfo(new DTO.RequestTrackInfo(this.spotifyConfiguration.baseUrl, musicId));

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> SearchInfo(string filter, IEnumerable<string> typeFilter)
        {
            if (!initializedClient) { authenticateClient(this.spotifyConfiguration); }
            var response = await this.spotifyClient.SearchInfo(new DTO.RequestSearchInfo(this.spotifyConfiguration.baseUrl, filter, typeFilter));

            return JsonConvert.SerializeObject(response);
        }


        public async Task<string> FetchTopItems(string type)
        {
            if (!initializedUser) { throw new SpotifyMissingLoginException("Missing Spotify user login."); }
            var response = await this.spotifyClient.FetchTopItems(new DTO.RequestTopItem(this.spotifyConfiguration.baseUrl, type));

            return JsonConvert.SerializeObject(response);
        }

        /// <summary>
        /// Finish the Spotify User Login using Authorization Code Flow - Step 2
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<string> AuthenticateAccessToken(string code, string state)
        {
            //TODO: Verify the State that was sent
            if (string.IsNullOrEmpty(state))
                throw new Exception("Invalid State...");

            var response = await this.spotifyClient.AuthenticateAccessToken(this.spotifyConfiguration.ToRequestAuthenticationAccessToken(code));
            this.initializedClient = true;

            return JsonConvert.SerializeObject(response);
        }

        //DOUBT: Pass the Authentication Responsability to IManagement: this service will depend on IManagement, in a way that
        //each time authentication was required it should "contact" this service

        /// <summary>
        /// Login a Spotify User using Authorization Code Flow - Step 1
        /// </summary>
        /// <returns></returns>
        public async Task<string> LoginUser()
        {
            var response = await this.spotifyClient.AuthenticateUser(this.spotifyConfiguration.ToRequestAuthenticationUser());
            this.initializedClient = true;
            this.initializedUser = true;
            return response;
        }

        #region ----- Private Methods

        /// <summary>
        /// Authentication using Client Credentials
        /// </summary>
        /// <param name="spotifyConfiguration"></param>
        /// <returns></returns>
        private async Task authenticateClient(SpotifyConfiguration spotifyConfiguration)
        {
            await this.spotifyClient.AuthenticateClient(spotifyConfiguration.ToRequestAuthenticationClient());
            this.initializedClient = true;
        }

        #endregion
    }
}
