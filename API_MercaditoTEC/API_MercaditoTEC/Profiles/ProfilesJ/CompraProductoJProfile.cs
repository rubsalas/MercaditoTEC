using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System.Collections.Generic;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class CompraProductoJProfile : Profile
    {
        public CompraProductoJProfile()
        {
            CreateMap<CompraProducto, CompraProductoJ>();
            CreateMap<ProductoJ, CompraProductoJ>();
            
            CreateMap<CompraProductoJ, CompraProductoJReadDto>();
        }
    }
}
