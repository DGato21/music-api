using Application.Core;
using Application.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace music_api.Controllers
{
    [Route("music-api/v1/fetch")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicApp musicApp;

        public MusicController(IConfiguration configuration, IMusicApp musicApp)
        {
            this.musicApp = musicApp;
        }

        [Route("/getAlbum/{id}")]
        [HttpGet]
        public async Task<string> getAlbum([FromQuery] string id)
        {
            try
            {
                return await this.musicApp.FetchAlbumInfo(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
