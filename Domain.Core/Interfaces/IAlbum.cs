using Domain.DTO;

namespace Domain.Core.Interfaces
{
    public interface IAlbum
    {
        public Task<AlbumDTO> getAlbumById(Guid Id);
        public Task<IEnumerable<AlbumDTO>> getAlbums(IDictionary<string, string> filter = null);
        public Task createAlbum(AlbumDTO album);
        public Task updateAlbum(Guid id, AlbumDTO album);
        public Task deleteAlbum(Guid id);
    }
}
