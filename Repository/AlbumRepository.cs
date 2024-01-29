using Dapper;
using Domain.DTO;
using Microsoft.Extensions.Configuration;
using Repository.CommandQueries;
using Repository.Interfaces;
using static Dapper.SqlMapper;

namespace Repository
{
    public class AlbumRepository : DapperContext, IAlbumRepository
    {
        private readonly ICommandText _commandText;

        public AlbumRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            this._commandText = commandText;
        }

        public async Task<IEnumerable<AlbumDTO>> GetAll(IDictionary<string, string> filter)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<AlbumDTO>(_commandText.GetAlbums, filter);
                return query;
            });
        }

        public async Task<AlbumDTO> GetById(Guid id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<AlbumDTO>(_commandText.GetAlbumById, 
                    new { Id = id });
                return query;
            });
        }

        public async Task Add(AlbumDTO albumDTO)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddAlbum,
                new {
                    Id = albumDTO.Id,
                    Title = albumDTO.Title,
                    ArtistName = albumDTO.ArtistName,
                    TypeId = albumDTO.Type,
                    Stock = albumDTO.Stock,
                    Cover = albumDTO.Cover
                });
            });
        }
        public async Task Update(Guid id, AlbumDTO albumDTO)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.UpdateAlbum,
                    new {
                        Title = albumDTO.Title,
                        ArtistName = albumDTO.ArtistName,
                        TypeId = albumDTO.Type,
                        Stock = albumDTO.Stock,
                        Cover = albumDTO.Cover,
                        Id = albumDTO.Id,
                    });
            });
        }

        public async Task Delete(Guid id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.RemoveAlbum, 
                    new { Id = id });
            });
        }
    }
}
