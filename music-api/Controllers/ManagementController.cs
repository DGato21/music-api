using Application.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music_api.Exceptions;
using Newtonsoft.Json;

namespace music_api.Controllers
{
    [Route("music-api/v1/manager")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IManagementApp managementApp;

        public ManagementController(IManagementApp managementApp)
        {
            this.managementApp = managementApp;
        }

        [Route("/setSomething")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> setSomething(string id)
        {
            try
            {
                //return await this.managementApp.ToString()
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }

        [Route("/loginSpotify")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> loginSpotify()
        {
            try
            {
                return await this.managementApp.LoginSpotify();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }

        [Route("/authUser")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> authenticateSpotifyUserAccessToken()
        {
            try
            {
                return await this.managementApp.AuthenticateSpotifyUserAccessToken();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }
    }
}
