using API_MercaditoTEC.Dtos.Persona;
using API_MercaditoTEC.Models;
using AutoMapper;

namespace API_MercaditoTEC.Profiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            //Fuente -> Objetivo
            CreateMap<Persona, PersonaReadDto>();
            CreateMap<PersonaCreateDto, Persona>();
            CreateMap<PersonaUpdateDto, Persona>();
        }
    }
}
