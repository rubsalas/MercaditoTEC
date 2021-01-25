using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class CursoTutorJProfile : Profile
    {
        public CursoTutorJProfile()
        {
            CreateMap<CursoTutor, CursoTutorJ>();
            CreateMap<TutorJ, CursoTutorJ>();
            CreateMap<CursoJ, CursoTutorJ>();

            CreateMap<CursoTutorJ, CursoTutorJReadDto>();
        }
    }
}
