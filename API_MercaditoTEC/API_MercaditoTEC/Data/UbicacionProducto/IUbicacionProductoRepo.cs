using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IUbicacionProductoRepo
    {
        IEnumerable<UbicacionProducto> GetAll();
        UbicacionProducto GetById(int id);
        IEnumerable<UbicacionProducto> GetByProducto(int idProducto);
        void Create(UbicacionProducto ubicacionProducto);
        void Update(UbicacionProducto ubicacionProducto);
        void Delete(UbicacionProducto ubicacionProducto);

        bool SaveChanges();
    }
}
