using Application.Core.Interfaces;
using Application.Core;
using Domain.Core.Interfaces;
using Domain.Core;
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
            serviceCollection.AddTransient<ICommandText, CommandText>();
            serviceCollection.AddSingleton<IRepositoryContext, DapperContext>();
            serviceCollection.AddTransient<IAlbumRepository, AlbumRepository>();

            //Application.Core Services
            serviceCollection.AddScoped<IAlbumApp, AlbumApp>();

            //Domain.Core Services
            serviceCollection.AddScoped<IAlbum, Album>();
        }
    }
}
