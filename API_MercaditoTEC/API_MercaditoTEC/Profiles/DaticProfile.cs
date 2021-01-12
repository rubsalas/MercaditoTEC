using API_MercaditoTEC.Dtos.Datic;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class DaticProfile : Profile
    {
        public DaticProfile()
        {
            CreateMap<Datic, DaticVerifyDto>();
            CreateMap<DaticVerifyDto, Datic>();
        }
    }
}
