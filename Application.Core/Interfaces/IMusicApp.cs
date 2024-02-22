namespace Application.Core.Interfaces
{
    public interface IMusicApp
    {
        public Task<string> FetchArtistInfo(string artistId);
        public Task<string> FetchAlbumInfo(string albumId);
        public Task<string> FetchMusicInfo(string musicId);
    }
}
