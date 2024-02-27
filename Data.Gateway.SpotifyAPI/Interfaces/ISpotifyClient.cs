using Data.Gateway.SpotifyAPI.DTO;

namespace Data.Gateway.SpotifyAPI.Interfaces
{
    public interface ISpotifyClient
    {
        public Task<AuthenticationClientResponse> AuthenticateClient(RequestAuthenticationClient requestAuthentication);
        public Task<string> AuthenticateUser(RequestAuthenticationUser requestAuthentication);
        public Task<AuthenticationUserAccessTokenResponse> AuthenticateUserAccessToken(RequestAuthenticationUserAccessToken requestAuthentication);
        public Task<ArtistInfoResponse> FetchArtistInfo(RequestArtistInfo requestArtistInfo);
        public Task<AlbumInfoResponse> FetchAlbumInfo(RequestAlbumInfo requestAlbumInfo);
        public Task<TrackInfoResponse> FetchTrackInfo(RequestTrackInfo requestMusicInfo);
        public Task<TopItemResponse> FetchTopItems(RequestTopItem requestTopItems);
    }
}
