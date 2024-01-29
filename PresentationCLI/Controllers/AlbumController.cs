using Application.Core.DTO;
using Application.Core.Interfaces;
using Infrastructure.Configuration;
using System.Web.Http;

namespace PresentationCLI.Controllers
{
    [Route("/v1/album")]
    public class AlbumController
    {
        //Improvments: log system (replace for Console.WriteLine)

        private readonly Configuration configuration;
        private readonly IAlbumApp albumApp;

        public AlbumController(Configuration configuration, IAlbumApp albumApp)
        {
            this.configuration = configuration;
            this.albumApp = albumApp;
        }

        [Route("/get")]
        [HttpGet]
        public async Task<IList<AlbumDTO>> getAlbums(Dictionary<string, string> filters = null)
        {
            try
            {
                return await this.albumApp.getAlbums(filters);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return new List<AlbumDTO>();
            }
        }

        [Route("/set")]
        [HttpPost]
        public async Task<bool> setAlbum(AlbumDTO albumDTO)
        {
            try
            {
                return await this.albumApp.setAlbum(albumDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [Route("/update")]
        [HttpPatch]
        public async Task<bool> updateAlbum(Guid id, AlbumDTO albumDTO)
        {
            try
            {
                return await this.albumApp.updateAlbum(id, albumDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [Route("/delete")]
        [HttpDelete]
        public async Task<bool> deleteAlbum(Guid id)
        {
            try
            {
                return await this.albumApp.deleteAlbum(id       );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
