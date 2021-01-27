using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class PracticaTutorJProfile : Profile
    {
        public PracticaTutorJProfile()
        {
            CreateMap<PracticaTutor, PracticaTutorJ>();

            CreateMap<PracticaTutorJ, PracticaTutorJReadDto>();

            //Create
            CreateMap<PracticaTutorJCreateDto, PracticaTutorJ>();
            CreateMap<PracticaTutorJ, PracticaTutor>();
        }
    }
}
