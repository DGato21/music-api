namespace Domain.Core.Interfaces
{
    public interface IManagement
    {
        public Task<string> LoginSpotify();
        public Task<string> AuthenticateSpotifyAccessToken(string code, string state);
    }
}
