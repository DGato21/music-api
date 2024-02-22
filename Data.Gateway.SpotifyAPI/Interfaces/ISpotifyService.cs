namespace Data.Gateway.SpotifyAPI.Interfaces
{
    public interface ISpotifyService
    {
        public Task<string> FetchArtistInfo(string artistId);
        public Task<string> FetchAlbumInfo(string albumId);
        public Task<string> FetchMusicInfo(string musicId);
    }
}
