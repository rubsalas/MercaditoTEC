using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IVendedorRepo
    {
        IEnumerable<Vendedor> GetAll();
        Vendedor GetById(int id);
        Vendedor GetByEstudiante(int idEstudiante);
        int GetId(int idEstudiante);
        void Create(Vendedor vendedor);
        void Update(Vendedor vendedor);
        void Delete(Vendedor vendedor);

        bool SaveChanges();
    }
}
