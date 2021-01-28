using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class CompradorJProfile : Profile
    {
        public CompradorJProfile()
        {
            CreateMap<Comprador, CompradorJ>();
            CreateMap<EstudianteJ, CompradorJ>();

            //CreateMap<CompradorJ, CompradorJReadDto>();
        }
    }
}
