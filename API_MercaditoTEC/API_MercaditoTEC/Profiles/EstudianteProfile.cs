using API_MercaditoTEC.Dtos.Estudiante;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class EstudianteProfile : Profile
    {
        public EstudianteProfile()
        {
            //Fuente -> Objetivo
            CreateMap<Estudiante, EstudianteReadDto>();
            CreateMap<EstudianteCreateDto, Estudiante>();
            CreateMap<EstudianteUpdateDto, Estudiante>();
        }
    }
}
