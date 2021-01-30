using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System.Collections.Generic;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class OfertaLaboralJProfile : Profile
    {
        public OfertaLaboralJProfile()
        {
            CreateMap<OfertaLaboral, OfertaLaboralJ>();
            //CreateMap<EmpleadorJ, OfertaLaboralJ>();
            CreateMap<Ubicacion, OfertaLaboralJ>();

            CreateMap<OfertaLaboralJ, OfertaLaboralJReadDto>();
        }
    }
}
