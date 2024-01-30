using Domain.Core.Interfaces;
using Domain.DTO;
using Repository;
using Repository.Interfaces;

namespace Domain.Core
{
    public class Album : IAlbum
    {
        private readonly IAlbumRepository _repository;

        public Album(IAlbumRepository repository)
        {
            this._repository = repository;
        }

        public Task<AlbumDTO> getAlbumById(Guid id)
        {
            try
            {
                var result = this._repository.GetById(id);

                return result;
            }
            catch (Exception ex) { throw ex; }
        }

        public Task<IEnumerable<AlbumDTO>> getAlbums(IDictionary<string, string> filter = null)
        {
            try
            {
                //Validate Filters: check if all filters provided are valid
                if (!validateFilters(filter))
                    throw new Exception("Domain.Core.getAlbums: Invalid filters provided.");

                var result = this._repository.GetAll(filter);

                return result;
            }
            catch (Exception ex) { throw ex; }
        }

        public Task createAlbum(AlbumDTO album)
        {
            try
            {
                var result = this._repository.Add(album);

                return Task.CompletedTask;
            }
            catch (Exception ex) { throw ex; }
        }

        public Task updateAlbum(Guid id, AlbumDTO album)
        {
            try
            {
                //Ensure ID is correct
                album.Id = id;

                var result = this._repository.Update(id, album);

                return Task.CompletedTask;
            }
            catch (Exception ex) { throw ex; }
        }

        public Task deleteAlbum(Guid id)
        {
            try
            {
                var result = this._repository.Delete(id);

                return Task.CompletedTask;
            }
            catch (Exception ex) { throw ex; }
        }

        private bool validateFilters(IDictionary<string, string> filters)
        {
            if (filters != null && filters.Count > 0)
            {
                return filters.Keys.All(key => this._repository.ValidFilters().Contains(key, StringComparer.InvariantCultureIgnoreCase));
            }
            else
                return true;
        }
    }
}
