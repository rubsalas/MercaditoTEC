using API_MercaditoTEC.Dtos.Carrera;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class CarreraProfile : Profile
    {
        public CarreraProfile()
        {
            CreateMap<Carrera, CarreraReadDto>();
        }
    }
}
