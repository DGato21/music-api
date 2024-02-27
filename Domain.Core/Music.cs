using Data.Gateway.SpotifyAPI.Interfaces;
using Domain.Core.Interfaces;

namespace Domain.Core
{
    public class Music : IMusic
    {
        private readonly ISpotifyService spotifyService;

        public Music (ISpotifyService spotifyService)
        {
            this.spotifyService = spotifyService;
        }

        public Task<string> FetchAlbumInfo(string albumId)
        {
            return this.spotifyService.FetchAlbumInfo(albumId);
        }

        public Task<string> FetchArtistInfo(string artistId)
        {
            return this.spotifyService.FetchArtistInfo(artistId);
        }

        public Task<string> FetchTrackInfo(string musicId)
        {
            return this.spotifyService.FetchTrackInfo(musicId);
        }

        public Task<string> FetchTopItems(string type)
        {
            return this.spotifyService.FetchTopItems(type);
        }

    }
}
