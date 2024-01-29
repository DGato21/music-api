using Application.DTO;
using Application.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MusicalogAPI.Controllers
{
    [ApiController]
    [Route("album")]
    public class AlbumController: ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;

        private readonly IConfiguration _configuration;
        private readonly IAlbumApp _albumApp;

        public AlbumController(ILogger<AlbumController> logger, IConfiguration configuration, IAlbumApp albumApp)
        {
            this._logger = logger;
            this._configuration = configuration;
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
                return null;
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
                return new List<AlbumDTO>();
            }
        }

        [HttpPost]
        [Route("/create")]
        public async Task createAlbum([FromBody] AlbumDTO albumDTO)
        {
            try
            {
                string teste = this._configuration.GetValue<string>("AllowedHosts");

                await this._albumApp.createAlbum(albumDTO);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
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
            }
        }
    }
}
