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

        private readonly HashSet<string> VALID_FILTERS = new HashSet<string>() 
        { "Id", "Title", "ArtistName", "Type", "Stock" };

        public AlbumRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            this._commandText = commandText;
        }

        public async Task<IEnumerable<AlbumDTO>> GetAll(IDictionary<string, string> filter)
        {
            var builder = new SqlBuilder();
            var parameter = new DynamicParameters();
            SqlBuilder.Template? select = null;
            if (filter != null && filter.Count > 0)
            {
                parameter = new DynamicParameters(filter);

                foreach (var f in filter)
                {
                    builder = builder.Where($"{f.Key} = @{f.Key}");
                    parameter.Add(f.Key, f.Value);
                }

                select = builder.AddTemplate(this._commandText.GetAlbums + " /**where**/");
            }
            else
            {
                select = builder.AddTemplate(this._commandText.GetAlbums);
            }

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<AlbumDTO>(select.RawSql, parameter);
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
                    Type = albumDTO.Type,
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
                        Type = albumDTO.Type,
                        Stock = albumDTO.Stock,
                        Cover = albumDTO.Cover,
                        Id = id,
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

        public IEnumerable<string> ValidFilters()
        {
            return this.VALID_FILTERS;
        }
    }
}
