using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class CursoTutoradoJProfile : Profile
    {
        public CursoTutoradoJProfile()
        {
            CreateMap<CursoTutorado, CursoTutoradoJ>();
            CreateMap<TutoradoJ, CursoTutoradoJ>();
            CreateMap<CursoTutorJ, CursoTutoradoJ>();

            CreateMap<CursoTutoradoJ, CursoTutoradoJReadDto>();

            //Create
            CreateMap<CursoTutoradoJCreateDto, CursoTutoradoJ>();
            CreateMap<CursoTutoradoJ, CursoTutorado>();
        }
    }
}
