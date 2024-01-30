using Application.Core.Interfaces;
using Domain.Core.Interfaces;
using Infrastructure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Core
{
    public class AlbumApp : IAlbumApp
    {
        private readonly ILogger<AlbumApp> _logger;
        private readonly IAlbum _album;

        public AlbumApp(ILogger<AlbumApp> logger, IAlbum album)
        {
            this._logger = logger;
            this._album = album;
        }

        public Task<Application.DTO.AlbumDTO> getAlbumById(Guid id)
        {
            try
            {
                var album = this._album.getAlbumById(id);

                var mapper = MapperConfig.InitializeAutomapper();
                var result = mapper.Map<Domain.DTO.AlbumDTO, Application.DTO.AlbumDTO>(album.Result);

                //Return
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Application.DTO.AlbumDTO>> getAlbums(IDictionary<string, string> filter = null)
        {
            try
            {
                var list = this._album.getAlbums(filter);

                //Mapper
                var mapper = MapperConfig.InitializeAutomapper();
                var result = mapper.Map<IEnumerable<Domain.DTO.AlbumDTO>, IEnumerable<Application.DTO.AlbumDTO>>(list.Result);

                //Return
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task createAlbum(Application.DTO.AlbumDTO album)
        {
            try
            {
                album.Id = Guid.NewGuid();

                var mapper = MapperConfig.InitializeAutomapper();
                var mappedAlbum = mapper.Map<Application.DTO.AlbumDTO, Domain.DTO.AlbumDTO>(album);

                return this._album.createAlbum(mappedAlbum);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task updateAlbum(Guid id, Application.DTO.AlbumDTO album)
        {
            try
            {
                //Mapper
                var mapper = MapperConfig.InitializeAutomapper();
                var mappedAlbum = mapper.Map<Application.DTO.AlbumDTO, Domain.DTO.AlbumDTO>(album);

                return this._album.updateAlbum(id, mappedAlbum);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task deleteAlbum(Guid id)
        {
            try
            {
                return this._album.deleteAlbum(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
