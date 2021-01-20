using API_MercaditoTEC.Data.DataJ;
using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System.Collections.Generic;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class ProductoJProfile : Profile
    {
        public ProductoJProfile()
        {
            CreateMap<Producto, ProductoJ>();
            //CreateMap<VendedorJ, ProductoJ>();
            CreateMap<IEnumerable<MetodoPagoProductoJ>, ProductoJ>();
            //CreateMap<IEnumerable<ImagenProducto>, ProductoJ>();
            CreateMap<IUbicacionProductoJRepo, SqlUbicacionProductoJRepo>();

            CreateMap<ProductoJ, ProductoJReadDto>();
        }
    }
}
