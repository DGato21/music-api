namespace Data.Gateway.SpotifyAPI.Command
{
    internal static class SpotifyCommand
    {
        internal static string AuthenticationUrl(string baseUrl) => $"{baseUrl}/api/token";
        internal static string AlbumInfo(string baseUrl, string album) => $"{baseUrl}/v1/albums/{album}";
        internal static string ArtistInfo(string baseUrl, string artist) => $"{baseUrl}/v1/artists/{artist}";
        internal static string TrackInfo(string baseUrl, string music) => $"{baseUrl}/v1/musics/{music}";
    }
}
