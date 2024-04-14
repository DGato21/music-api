using Infrastructure.Configuration;

namespace Data.Gateway.SpotifyAPI.Interfaces
{
    public interface ISpotifyService
    {
        public Task<string> FetchArtistInfo(string artistId);
        public Task<string> FetchAlbumInfo(string albumId);
        public Task<string> FetchTrackInfo(string musicId);
        public Task<string> FetchTopItems(string type);
        public Task<string> SearchInfo(string filter, IEnumerable<string> typeFilter);
        public Task<string> LoginUser();
        public Task<string> AuthenticateAccessToken(string code, string state);
    }
}
