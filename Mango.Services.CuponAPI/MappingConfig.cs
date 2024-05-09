using AutoMapper;
using Mango.Services.CuponAPI.Models;
using Mango.Services.CuponAPI.Models.DTO;

namespace Mango.Services.CuponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<CuponDTO, Cupon>();
                config.CreateMap<Cupon, CuponDTO>();
            });
            return mappingConfiguration;
        }
    }
}
