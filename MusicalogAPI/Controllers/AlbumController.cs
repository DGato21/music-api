using Application.DTO;
using Application.Core.Interfaces;
using MusicalogAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MusicalogAPI.Controllers
{
    [ApiController]
    [Route("album")]
    public class AlbumController : ControllerBase
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
        [ProducesResponseType(typeof(AlbumDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AlbumDTO>> GetAlbumById(Guid id)
        {
            try
            {
                this._logger.Log(LogLevel.Information, "AlbumController.GetAlbumById");
                var response = await this._albumApp.getAlbumById(id);
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return this.BadRequest(new ApiErrorDTO() { ErrorMessage = ex.Message });
            }


        }

        [HttpPost]
        [Route("/getAlbums")]
        [ProducesResponseType(typeof(AlbumDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AlbumDTO>>> GetAlbums([FromBody] Dictionary<string, string> filters = null)
        {
            try
            {
                this._logger.Log(LogLevel.Information, "AlbumController.GetAlbums");
                var response = await this._albumApp.getAlbums(filters);
                return this.Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return this.BadRequest(new ApiErrorDTO() { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        [Route("/create")]
        [ProducesResponseType(typeof(AlbumDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAlbum([FromBody] AlbumDTO albumDTO)
        {
            try
            {
                this._logger.Log(LogLevel.Information, "AlbumController.CreateAlbum");
                await this._albumApp.createAlbum(albumDTO);
                return this.Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return this.BadRequest(new ApiErrorDTO() { ErrorMessage = ex.Message });
            }
        }

        [HttpPatch]
        [Route("/update/{id}")]
        [ProducesResponseType(typeof(AlbumDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAlbum(Guid id, [FromBody] AlbumDTO albumDTO)
        {
            try
            {
                this._logger.Log(LogLevel.Information, "AlbumController.UpdateAlbum");
                await this._albumApp.updateAlbum(id, albumDTO);
                return this.Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return this.BadRequest(new ApiErrorDTO() { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        [ProducesResponseType(typeof(AlbumDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAlbum(Guid id)
        {
            try
            {
                this._logger.Log(LogLevel.Information, "AlbumController.DeleteAlbum");
                await this._albumApp.deleteAlbum(id);
                return this.Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return this.BadRequest(new ApiErrorDTO() { ErrorMessage = ex.Message });
            }
        }
    }
}
