using Data.Gateway.SpotifyAPI.DTO;

namespace Data.Gateway.SpotifyAPI.Interfaces
{
    public interface ISpotifyClient
    {
        public Task Authenticate(RequestAuthentication requestAuthentication);
        public Task<ArtistInfoResponse> FetchArtistInfo(RequestArtistInfo requestArtistInfo);
        public Task<AlbumInfoResponse> FetchAlbumInfo(RequestAlbumInfo requestAlbumInfo);
        public Task<TrackInfoResponse> FetchTrackInfo(RequestTrackInfo requestMusicInfo);
    }
}
