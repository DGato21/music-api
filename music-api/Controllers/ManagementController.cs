using Application.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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

        [Route("/authSpotify")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorDTO), StatusCodes.Status400BadRequest)]
        public async Task<string> authenticationSpotify([FromQuery] string code, [FromQuery] string state, [FromQuery] string error)
        {
            try
            {
                if (string.IsNullOrEmpty(error))
                    return await this.managementApp.AuthenticateSpotifyAccessToken(code, state);
                else //TODO: Method to cancel the state of the authentication: reset state, etc
                    return "INVALID";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JsonConvert.SerializeObject(new ApiErrorDTO(ex.Message));
            }
        }
    }
}
