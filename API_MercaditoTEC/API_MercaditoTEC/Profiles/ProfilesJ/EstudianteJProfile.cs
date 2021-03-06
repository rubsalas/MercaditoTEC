﻿using API_MercaditoTEC.Dtos.DtosJ.EstudianteJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class EstudianteJProfile : Profile
    {
       public EstudianteJProfile()
        {
            CreateMap<Persona, EstudianteJ>();
            CreateMap<Estudiante, EstudianteJ>();
            CreateMap<Datic, EstudianteJ>();
            CreateMap<Tutor, EstudianteJ>();
            CreateMap<Vendedor, EstudianteJ>();

            CreateMap<EstudianteJ, EstudianteJReadDto>();
            CreateMap<EstudianteJ, EstudianteJProfileDto>();

            CreateMap<EstudianteJCreateDto, EstudianteJ>();

            CreateMap<EstudianteJ, Persona>();
            CreateMap<EstudianteJ, Estudiante>();

            CreateMap<EstudianteJCreateDto, EstudianteJ>();

            CreateMap<EstudianteJUpdateDto, EstudianteJ>();
        }

    }
}
