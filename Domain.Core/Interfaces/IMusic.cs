namespace Domain.Core.Interfaces
{
    public interface IMusic
    {
        public Task<string> FetchArtistInfo(string artistId);
        public Task<string> FetchAlbumInfo(string albumId);
        public Task<string> FetchTrackInfo(string musicId);
    }
}
