using Data.Gateway.SpotifyAPI.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Data.Gateway.SpotifyAPI
{
    public class SpotifyClient : ISpotifyClient
    {

        public SpotifyClient(IConfiguration configuration)
        {

        }
    }
}
