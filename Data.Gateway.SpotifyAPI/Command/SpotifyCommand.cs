﻿namespace Data.Gateway.SpotifyAPI.Command
{
    internal static class SpotifyCommand
    {
        internal static string AuthenticationUrl(string baseUrl) => $"{baseUrl}/api/token";
        internal static string AlbumInfo => "/spotify/...";
        internal static string ArtistInfo => "/spotify/...";
        internal static string MusicInfo => "/spotify/...";
    }
}