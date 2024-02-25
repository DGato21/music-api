using Application.Core;
using Application.Core.Interfaces;
using Data.Gateway.SpotifyAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace music_api.Controllers
{
    [Route("music-api/v1/fetch")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicApp musicApp;

        public MusicController(IMusicApp musicApp)
        {
            this.musicApp = musicApp;
        }

        [Route("/getAlbum/{id}")]
        [HttpGet]
        public async Task<string> getAlbum(string id)
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
