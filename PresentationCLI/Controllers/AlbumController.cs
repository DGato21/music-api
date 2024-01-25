using Infrastructure.Configuration;

namespace PresentationCLI.Controllers
{
    public class AlbumController
    {
        private readonly Configuration configuration;

        public AlbumController(Configuration configuration)
        {
            this.configuration = configuration;
        }
    }
}
