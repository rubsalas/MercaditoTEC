using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICategoriaRepo
    {
        IEnumerable<Categoria> GetAll();
        Categoria GetById(int id);
        Categoria GetByNombre(string nombre);
        int GetId(string nombre);
        void Create(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);

        bool SaveChanges();
    }
}
