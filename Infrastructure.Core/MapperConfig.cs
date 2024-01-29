using AutoMapper;

namespace Infrastructure.Core
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Application.DTO.AlbumDTO, Domain.DTO.AlbumDTO>();
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
