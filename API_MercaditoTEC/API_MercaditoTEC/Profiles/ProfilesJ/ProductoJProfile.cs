using API_MercaditoTEC.Dtos.DtosJ.ProductoJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;

namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class ProductoJProfile : Profile
    {
        public ProductoJProfile()
        {
            CreateMap<Producto, ProductoJ>();
            CreateMap<VendedorJ, ProductoJ>();

            CreateMap<ProductoJ, ProductoJReadDto>();

            
        }
    }
}
