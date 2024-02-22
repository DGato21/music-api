using Data.Gateway.SpotifyAPI.Command;
using Data.Gateway.SpotifyAPI.DTO;
using Data.Gateway.SpotifyAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Data.Gateway.SpotifyAPI
{
    public class SpotifyClient : ISpotifyClient
    {
        //TODO: Logic To Do Another Authorization Request after ExpirationTime

        private readonly HttpClient httpClient;

        private string token;
        private string tokenType;

        public SpotifyClient()
        {
            this.httpClient = new HttpClient();
            this.token = null;
            SetHttpClientDefaultHeaders();
        }

        public async Task Authenticate(RequestAuthentication requestAuthentication)
        {
            HttpContent content = null;

            SetHttpClientToken();

            var stringContent = new StringContent(JsonConvert.SerializeObject(requestAuthentication));
            var response = await this.httpClient.PostAsync(SpotifyCommand.AuthenticationUrl, stringContent).ConfigureAwait(false);

            //TODO
            var responseStr = response.Content.ReadAsStringAsync().Result;
        }

        public async Task<AlbumInfoResponse> FetchAlbumInfo(RequestAlbumInfo requestAlbumInfo)
        {
            var response = await this.httpClient.GetStringAsync(SpotifyCommand.AlbumInfo).ConfigureAwait(false);

            return new AlbumInfoResponse();
        }

        public async Task<ArtistInfoResponse> FetchArtistInfo(RequestArtistInfo requestArtistInfo)
        {
            var response = await this.httpClient.GetStringAsync(SpotifyCommand.ArtistInfo).ConfigureAwait(false);

            return new ArtistInfoResponse();
        }

        public async Task<MusicInfoResponse> FetchMusicInfo(RequestMusicInfo requestMusicInfo)
        {
            var response = await this.httpClient.GetStringAsync(SpotifyCommand.MusicInfo).ConfigureAwait(false);

            return new MusicInfoResponse();
        }

        public void SetToken(string token) => this.token = token;
        public void SetTokenType(string tokenType) => this.tokenType = tokenType;

        private void SetHttpClientToken()
        {
            this.httpClient.DefaultRequestHeaders.Add("Authorization", $"{this.tokenType} {token}");
        }

        private void SetHttpClientDefaultHeaders()
        {
            this.httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
            this.httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");
        }
    }
}
