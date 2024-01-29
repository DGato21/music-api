using Domain.DTO;

namespace Repository.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumDTO>> GetAll(IDictionary<string, string> filter);
        Task<AlbumDTO> GetById(Guid id);
        Task Add(AlbumDTO albumDTO);
        Task Update(Guid id, AlbumDTO albumDTO);
        Task Delete(Guid id);
    }
}
