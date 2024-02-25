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
using Microsoft.Extensions.Configuration;
using Infrastructure.Configuration.Factories;

namespace Infrastructure.Services
{
    public static class ServiceStartup
    {
        public static void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //Core (Configurations, etc)

            //Infrastructure
            serviceCollection.AddSingleton<SpotifyFactory>();

            //Application.Core Services
            serviceCollection.AddScoped<IManagementApp, ManagementApp>();
            serviceCollection.AddScoped<IMusicApp, MusicApp>();
            serviceCollection.AddScoped<IShowApp, ShowApp>();

            //Domain.Core Services
            serviceCollection.AddScoped<IManagement, Management>();
            serviceCollection.AddScoped<IMusic, Music>();
            serviceCollection.AddScoped<IShow, Show>();

            //Data.Gateway
            serviceCollection.AddScoped<ISpotifyClient, SpotifyClient>();
            serviceCollection.AddScoped<ISpotifyService, SpotifyService>();

            //Data.Repository Services
            serviceCollection.AddSingleton<ICommandText, CommandText>();
            serviceCollection.AddScoped<IRepositoryContext, DapperContext>();
        }

        /*
         * https://code-maze.com/dotnet-factory-pattern-dependency-injection/
         * https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
         */
    }
}
