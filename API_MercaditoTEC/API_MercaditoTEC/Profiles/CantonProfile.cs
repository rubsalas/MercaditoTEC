using API_MercaditoTEC.Dtos;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class CantonProfile : Profile
    {
        public CantonProfile()
        {
            CreateMap<Canton, CantonReadDto>();
        }
    }
}
