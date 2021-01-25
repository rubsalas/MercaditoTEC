using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IProductoRepo
    {
        IEnumerable<Producto> GetAll();
        Producto GetById(int id);
        Producto GetByNombre(string nombre);
        IEnumerable<Producto> GetByCategoria(int idCategoria);
        IEnumerable<Producto> GetByEstudiante(int idEstudiante);
        int GetId(string nombre);
        void Create(Producto producto);
        void Update(Producto producto);
        void Delete(Producto producto);

        bool SaveChanges();
    }
}
