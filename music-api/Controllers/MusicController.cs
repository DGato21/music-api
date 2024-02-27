using Application.Core.Interfaces;
using Infrastructure.Exceptions.Spotify;
using Microsoft.AspNetCore.Mvc;
using music_api.Exceptions;
using Newtonsoft.Json;

namespace music_api.Controllers
{
    [Route("music-api/v1/fetch")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        //RESPONSE TO -> DTOs Object instead of string

        private readonly IMusicApp musicApp;

        public MusicController(IMusicApp musicApp)
        {
            this.musicApp = musicApp;
        }

        [Route("/getAlbum/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> getAlbum(string id)
        {
            try
            {
                return await this.musicApp.FetchAlbumInfo(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }

        [Route("/getArtist/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> getArtist(string id)
        {
            try
            {
                var response = await this.musicApp.FetchArtistInfo(id);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }

        [Route("/getTrack/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> getTrack(string id)
        {
            try
            {
                return await this.musicApp.FetchTrackInfo(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }

        [Route("/getTopItems")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> getTopItems(string type)
        {
            try
            {
                return await this.musicApp.FetchTopItems(type);
            }
            catch (SpotifyMissingLoginException ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }
    }
}
