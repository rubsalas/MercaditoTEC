using API_MercaditoTEC.Dtos;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class MetodoPagoProfile : Profile
    {
        public MetodoPagoProfile()
        {
            CreateMap<MetodoPago, MetodoPagoReadDto>();
        }
    }
}
