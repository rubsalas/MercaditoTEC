using API_MercaditoTEC.Dtos.DtosJ.EstudianteJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class EstudianteJProfile : Profile
    {
       public EstudianteJProfile()
        {
            CreateMap<EstudianteJ, Persona>();
            CreateMap<EstudianteJ, Estudiante>();
            CreateMap<Persona, EstudianteJ>();
            CreateMap<Estudiante, EstudianteJ>();

            CreateMap<EstudianteJ, EstudianteJReadDto>();
        }

    }
}
