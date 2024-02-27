namespace Application.Core.Interfaces
{
    public interface IManagementApp
    {
        public Task<string> LoginSpotify();
        public Task<string> AuthenticateSpotifyUserAccessToken();
    }
}
