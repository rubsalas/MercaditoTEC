using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class MetodoPagoProductoJProfile : Profile
    {
        public MetodoPagoProductoJProfile()
        {
            CreateMap<MetodoPago, MetodoPagoProductoJ>();
            CreateMap<MetodoPagoProducto, MetodoPagoProductoJ>();

            CreateMap<MetodoPagoProductoJ, MetodoPagoProducto>();

            CreateMap<MetodoPagoProductoJ, MetodoPagoProductoJReadDto>(); 
        }
    }
}
