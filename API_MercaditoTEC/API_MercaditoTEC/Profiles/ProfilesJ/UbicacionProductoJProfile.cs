using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class UbicacionProductoJProfile : Profile
    {
        public UbicacionProductoJProfile()
        {
            CreateMap<UbicacionProducto, UbicacionProductoJ>();
        }
    }
}
