using Application.Core.Interfaces;
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

        public Task<string> FetchMusicInfo(string musicId)
        {
            return this.music.FetchMusicInfo(musicId);
        }
    }
}
