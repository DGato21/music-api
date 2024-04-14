namespace Application.Core.Interfaces
{
    public interface IManagementApp
    {
        public Task<string> LoginSpotify();
        public Task<string> AuthenticateSpotifyAccessToken(string code, string state);
    }
}
