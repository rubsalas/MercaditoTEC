using API_MercaditoTEC.Dtos.DtosJ.VendedorJ;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
namespace API_MercaditoTEC.Profiles.ProfilesJ
{
    public class VendedorJProfile : Profile
    {
        public VendedorJProfile()
        {
            CreateMap<Vendedor, VendedorJ>();
            CreateMap<EstudianteJ, VendedorJ>();

            CreateMap<VendedorJ, VendedorJReadDto>();
        }
    }
}
