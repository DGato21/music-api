using Application.DTO;
using Application.Core.Interfaces;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace MusicalogAPI.Controllers
{
    [ApiController]
    [Route("album")]
    public class AlbumController: ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;

        private readonly Configuration _configuration;
        private readonly IAlbumApp _albumApp;

        public AlbumController(ILogger<AlbumController> logger, Configuration configuration, IAlbumApp albumApp)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._albumApp = albumApp;
        }

        [HttpGet(Name = "Get")]
        public async Task<AlbumDTO> getAlbums(Guid id)
        {
            try
            {
                return await this._albumApp.getAlbumById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return null;
            }
        }

        [HttpGet(Name = "List")]
        public async Task<IEnumerable<AlbumDTO>> getAlbums(Dictionary<string, string> filters = null)
        {
            try
            {
                return await this._albumApp.getAlbums(filters);
            }
            catch (Exception ex) 
            {
                this._logger.LogError(ex.Message);
                return new List<AlbumDTO>();
            }
        }

        [HttpPost(Name = "Create")]
        public async Task createAlbum(AlbumDTO albumDTO)
        {
            try
            {
                await this._albumApp.createAlbum(albumDTO);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
            }
        }

        [HttpPatch(Name = "Update")]
        public async Task updateAlbum(Guid id, AlbumDTO albumDTO)
        {
            try
            {
                await this._albumApp.updateAlbum(id, albumDTO);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
            }
        }

        [HttpDelete(Name = "Delete")]
        public async Task deleteAlbum(Guid id)
        {
            try
            {
                await this._albumApp.deleteAlbum(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
            }
        }
    }
}
