using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class CursoJProfile : Profile
    {
        public CursoJProfile()
        {
            CreateMap<Curso, CursoJ>();

            CreateMap<CursoJ, CursoJReadDto>();
        }
    }
}
