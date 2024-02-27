namespace Domain.Core.Interfaces
{
    public interface IManagement
    {
        public Task<string> LoginSpotify();
        public Task<string> AuthenticateSpotifyUserAccessToken();
    }
}
