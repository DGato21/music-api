using Data.Gateway.SpotifyAPI.Command;
using Data.Gateway.SpotifyAPI.DTO;
using Data.Gateway.SpotifyAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Data.Gateway.SpotifyAPI
{
    public class SpotifyClient : ISpotifyClient
    {
        //TODO: Logic To Do Another Authorization Request after ExpirationTime

        private const string REQUEST_MEDIATYPE = "application/x-www-form-urlencoded";
        private const string HEADER_ACCEPT_MEDIATYPE = "application/json";

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
            try
            {
                HttpContent content = null;

                var stringContent = new StringContent(requestAuthentication.getAuthBody, Encoding.UTF8, REQUEST_MEDIATYPE);
                var response = await this.httpClient.PostAsync(SpotifyCommand.AuthenticationUrl(requestAuthentication.baseUrl), stringContent).ConfigureAwait(false);

                //TODO IMPROVE
                var responseStr = response.Content.ReadAsStringAsync().Result;

                var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(responseStr);

                //Receive the Token and Set
                SetHttpClientToken(authenticationResponse.token_type, authenticationResponse.access_token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AlbumInfoResponse> FetchAlbumInfo(RequestAlbumInfo requestAlbumInfo)
        {
            try
            {
                var response = await this.httpClient.GetStringAsync(SpotifyCommand.AlbumInfo(requestAlbumInfo.baseUrl, requestAlbumInfo.albumId)).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<AlbumInfoResponse>(response);
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<ArtistInfoResponse> FetchArtistInfo(RequestArtistInfo requestArtistInfo)
        {
            try
            {
                var response = await this.httpClient.GetStringAsync(SpotifyCommand.ArtistInfo(requestArtistInfo.baseUrl, requestArtistInfo.artistId)).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ArtistInfoResponse>(response);
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<TrackInfoResponse> FetchTrackInfo(RequestTrackInfo requestTrackInfo)
        {
            try
            {
                var response = await this.httpClient.GetStringAsync(SpotifyCommand.TrackInfo(requestTrackInfo.baseUrl, requestTrackInfo.musicId)).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<TrackInfoResponse>(response);
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        private void SetToken(string token) => this.token = token;
        private void SetTokenType(string tokenType) => this.tokenType = tokenType;

        private void SetHttpClientToken(string tokenType, string token)
        {
            SetTokenType(tokenType);
            SetToken(token);
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(this.tokenType, token);
        }

        private void SetHttpClientDefaultHeaders()
        {
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HEADER_ACCEPT_MEDIATYPE));
        }
    }
}
