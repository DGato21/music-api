using Infrastructure.Configuration;
using PresentationCLI.Controllers;

namespace PresentationCLI
{
    public class PresentationCLI
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Musicalog...");

            Configuration configuration = LoadConfiguration();

            //Load Controllers
            AlbumController albumController;

            Console.WriteLine("Finishing...");
        }

        private static Configuration LoadConfiguration()
        {
            var configuration = new Configuration();

            return configuration;
        }

        private static void LoadControllers(Configuration configuration,
            out AlbumController albumController)
        {
            albumController = new AlbumController(configuration);
        }
    }
}
