using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IVendedorJRepo
    {
        IEnumerable<VendedorJ> GetAll();
        VendedorJ GetById(int id);
        VendedorJ GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(VendedorJ vendedorJ);
        void Update(VendedorJ vendedorJ);
        void Delete(VendedorJ vendedorJ);

        bool SaveChanges();
    }
}
