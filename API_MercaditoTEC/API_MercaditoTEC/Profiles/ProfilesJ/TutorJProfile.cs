using API_MercaditoTEC.Dtos.DtosJ.TutorJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class TutorJProfile : Profile
    {
        public TutorJProfile()
        {
            CreateMap<Tutor, TutorJ>();
            CreateMap<Estudiante, TutorJ>();
            CreateMap<Persona, TutorJ>();

            CreateMap<TutorJ, TutorJReadDto>();
        }
    }
}
