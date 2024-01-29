using Application.DTO;

namespace Application.Core.Interfaces
{
    public interface IAlbumApp
    {
        public Task<AlbumDTO> getAlbumById(Guid id);
        public Task<IEnumerable<AlbumDTO>> getAlbums(IDictionary<string, string> filter = null);
        public Task createAlbum(AlbumDTO album);
        public Task updateAlbum(Guid id, AlbumDTO album);
        public Task deleteAlbum(Guid id);
    }
}
