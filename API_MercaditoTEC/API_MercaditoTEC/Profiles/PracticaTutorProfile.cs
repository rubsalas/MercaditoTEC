using API_MercaditoTEC.Dtos.PracticaTutor;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class PracticaTutorProfile : Profile
    {
        public PracticaTutorProfile()
        {
            CreateMap<PracticaTutor, PracticaTutorReadDto>();
        }
    }
}
