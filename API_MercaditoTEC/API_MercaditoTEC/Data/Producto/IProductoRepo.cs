using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IProductoRepo
    {
        IEnumerable<Producto> GetAll();
        IEnumerable<Producto> GetOrderedByPrecio();
        Producto GetById(int id);
        Producto GetByNombre(string nombre);
        IEnumerable<Producto> GetByCategoria(int idCategoria);
        IEnumerable<Producto> GetByCategoriaOrderedByPrecio(int idCategoria);
        IEnumerable<Producto> GetByEstudiante(int idEstudiante);
        int GetId(string nombre, int idVendedor);
        void Create(Producto producto);
        void Update(Producto producto);
        void Delete(Producto producto);

        bool SaveChanges();
    }
}
