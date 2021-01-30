using API_MercaditoTEC.Dtos.Categoria;
using API_MercaditoTEC.Dtos.TasaCambio;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class TasaCambioProfile : Profile
    {
        public TasaCambioProfile()
        {
            CreateMap<TasaCambio, TasaCambioReadDto>();
        }
    }
}
