
using Application.Core;
using Application.Core.Interfaces;
using Domain.Core;
using Domain.Core.Interfaces;
using Repository;
using Repository.CommandQueries;
using Repository.Interfaces;

namespace MusicalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            SetServices(ref builder);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void SetServices(ref WebApplicationBuilder builder)
        {
            //Data.Repository Services
            builder.Services.AddTransient<ICommandText, CommandText>();
            builder.Services.AddSingleton<IRepositoryContext, DapperContext>();
            builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();

            //Application.Core Services
            builder.Services.AddScoped<IAlbumApp, AlbumApp>();

            //Domain.Core Services
            builder.Services.AddScoped<IAlbum, Album>();
        }
    }
}
