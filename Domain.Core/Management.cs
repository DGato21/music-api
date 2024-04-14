using Data.Gateway.SpotifyAPI.Interfaces;
using Domain.Core.Interfaces;

namespace Domain.Core
{
    public class Management : IManagement
    {
        private readonly ISpotifyService spotifyService;

        public Management(ISpotifyService spotifyService)
        {
            this.spotifyService = spotifyService;
        }

        public async Task<string> LoginSpotify()
        {
            return await this.spotifyService.LoginUser();
        }

        public async Task<string> AuthenticateSpotifyAccessToken(string code, string state)
        {
            return await this.spotifyService.AuthenticateAccessToken(code, state);
        }
    }
}
