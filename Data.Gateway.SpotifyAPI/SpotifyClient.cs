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
        private string refreshToken;
        private IEnumerable<string> available_scopes;

        public SpotifyClient()
        {
            this.httpClient = new HttpClient();
            this.token = null;
        }

        public async Task<AuthenticationClientResponse> AuthenticateClient(RequestAuthenticationClient requestAuthentication)
        {
            try
            {
                HttpContent content = null;

                _setHttpClientDefaultHeaders(HEADER_ACCEPT_MEDIATYPE);
                var stringContent = new StringContent(requestAuthentication.getAuthBody, Encoding.UTF8, REQUEST_MEDIATYPE);
                var response = await this.httpClient.PostAsync(SpotifyCommand.AuthenticationClientUrl(requestAuthentication.baseUrl), stringContent).ConfigureAwait(true);

                //TODO IMPROVE
                var responseStr = response.Content.ReadAsStringAsync().Result;

                var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationClientResponse>(responseStr);

                //Receive the Token and Set
                _setHttpClientToken(authenticationResponse.token_type, authenticationResponse.access_token);

                return authenticationResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AuthenticateUser(RequestAuthenticationUser requestAuthentication)
        {
            try
            {
                var requestQuery = requestAuthentication.getAuthQuery();

                var response = await this.httpClient.GetStringAsync(
                    SpotifyCommand.AuthenticationUserUrl(requestAuthentication.baseUrl, requestQuery)).ConfigureAwait(true);

                System.IO.File.WriteAllText(@$"{AppContext.BaseDirectory}\redirect.html", response);
                System.Diagnostics.Process.Start(response);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AuthenticationUserAccessTokenResponse> AuthenticateUserAccessToken(RequestAuthenticationUserAccessToken requestAuthentication)
        {
            try
            {
                HttpContent content = null;

                var stringContent = new StringContent(requestAuthentication.getAuthHeader, Encoding.UTF8, REQUEST_MEDIATYPE);
                var response = await this.httpClient.PostAsync(SpotifyCommand.AuthenticationClientUrl(requestAuthentication.baseUrl), stringContent).ConfigureAwait(true);

                //TODO IMPROVE
                var responseStr = response.Content.ReadAsStringAsync().Result;

                var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationUserAccessTokenResponse>(responseStr);

                //Receive the Token and Set
                _setHttpClientToken(authenticationResponse.token_type, authenticationResponse.access_token, authenticationResponse.refresh_token);
                if (authenticationResponse.scope != null)
                    _setScopes(authenticationResponse.scope);

                return authenticationResponse;
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

        public async Task<TopItemResponse> FetchTopItems(RequestTopItem requestTopItems)
        {
            try
            {
                var response = await this.httpClient.GetStringAsync(SpotifyCommand.TopItemsInfo(requestTopItems.baseUrl, requestTopItems.type.ToString())).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<TopItemResponse>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _setToken(string token) => this.token = token;
        private void _setTokenType(string tokenType) => this.tokenType = tokenType;
        private void _setRefreshToken(string refreshToken) => this.refreshToken = refreshToken;
        private void _setScopes(string scopes) => this.available_scopes = scopes.Trim().Split(" ");

        private void _setHttpClientToken(string tokenType, string token, string refreshToken = null)
        {
            _setTokenType(tokenType);
            _setToken(token);
            if (refreshToken != null) { _setRefreshToken(refreshToken); }
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(this.tokenType, token);
        }

        private void _setHttpClientDefaultHeaders(string mediatype)
        {
            this.httpClient.DefaultRequestHeaders.Clear();

            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediatype));
        }
    }
}
