using Application.Core.Interfaces;
using Application.Core;
using Domain.Core.Interfaces;
using Domain.Core;
using Data.Gateway.SpotifyAPI.Interfaces;
using Data.Gateway.SpotifyAPI;
using Repository.Interfaces;
using Repository;
using Repository.CommandQueries;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class ServiceStartup
    {
        public static void SetServices(IServiceCollection serviceCollection)
        {
            //Data.Repository Services
            serviceCollection.AddSingleton<ICommandText, CommandText>();
            serviceCollection.AddScoped<IRepositoryContext, DapperContext>();
            serviceCollection.AddScoped<IAlbumRepository, AlbumRepository>(); //TO DELETE

            //Application.Core Services
            serviceCollection.AddSingleton<IManagementApp, ManagementApp>();
            serviceCollection.AddSingleton<IMusicApp, MusicApp>();
            serviceCollection.AddSingleton<IShowApp, ShowApp>();

            //Domain.Core Services
            serviceCollection.AddSingleton<IManagement, Management>();
            serviceCollection.AddSingleton<IMusic, Music>();
            serviceCollection.AddSingleton<IShow, Show>();

            //Data.Gateway
            serviceCollection.AddSingleton<ISpotifyService, SpotifyService>();
            serviceCollection.AddSingleton<ISpotifyClient, SpotifyClient>();
        }
    }
}
