namespace Data.Gateway.SpotifyAPI.Command
{
    internal static class SpotifyCommand
    {
        internal static string AuthenticationClientUrl(string baseUrl) => $"{baseUrl}/api/token";
        internal static string AuthenticationUserUrl(string baseUrl, string requestQuery) => $"{baseUrl}/authorize?{requestQuery}";
        internal static string AlbumInfo(string baseUrl, string album) => $"{baseUrl}/v1/albums/{album}";
        internal static string ArtistInfo(string baseUrl, string artist) => $"{baseUrl}/v1/artists/{artist}";
        internal static string TrackInfo(string baseUrl, string music) => $"{baseUrl}/v1/musics/{music}";
        internal static string TopItemsInfo(string baseUrl, string type) => $"{baseUrl}/v1/me/top/{type}";
        internal static string SearchInfo(string baseUrl, string requestQuery) => $"{baseUrl}/v1/search?{requestQuery}";
    }
}
