using Application.Core.Interfaces;
using Domain.Core;
using Domain.Core.Interfaces;

namespace Application.Core
{
    public class MusicApp : IMusicApp
    {
        private readonly IMusic music;

        public MusicApp(IMusic music)
        {
            this.music = music;
        }

        public Task<string> FetchAlbumInfo(string albumId)
        {
            return this.music.FetchAlbumInfo(albumId);
        }

        public Task<string> FetchArtistInfo(string artistId)
        {
            return this.music.FetchArtistInfo(artistId);
        }

        public Task<string> FetchTrackInfo(string musicId)
        {
            return this.music.FetchTrackInfo(musicId);
        }

        public Task<string> FetchTopItems(string type)
        {
            return this.music.FetchTopItems(type);
        }
    }
}
