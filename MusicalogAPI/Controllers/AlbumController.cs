using Application.DTO;
using Application.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Azure;

namespace MusicalogAPI.Controllers
{
    [ApiController]
    [Route("album")]
    public class AlbumController: ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;
        private readonly IAlbumApp _albumApp;

        public AlbumController(ILogger<AlbumController> logger, IAlbumApp albumApp)
        {
            this._logger = logger;
            this._albumApp = albumApp;
        }

        [HttpGet]
        [Route("/getById/{id}")]
        public async Task<AlbumDTO> getAlbumById(Guid id)
        {
            try
            {
                return await this._albumApp.getAlbumById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("/getAlbums")]
        public async Task<IEnumerable<AlbumDTO>> getAlbums([FromBody] Dictionary<string, string> filters = null)
        {
            try
            {
                return await this._albumApp.getAlbums(filters);
            }
            catch (Exception ex) 
            {
                this._logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("/create")]
        public async Task createAlbum([FromBody] AlbumDTO albumDTO)
        {
            try
            {
                await this._albumApp.createAlbum(albumDTO);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPatch]
        [Route("/update/{id}")]
        public async Task updateAlbum(Guid id, [FromBody] AlbumDTO albumDTO)
        {
            try
            {
                await this._albumApp.updateAlbum(id, albumDTO);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task deleteAlbum(Guid id)
        {
            try
            {
                await this._albumApp.deleteAlbum(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
