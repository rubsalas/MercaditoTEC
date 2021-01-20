using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IUbicacionProductoJRepo
    {
        IEnumerable<UbicacionProductoJ> GetAll();
        UbicacionProductoJ GetById(int id);
        IEnumerable<UbicacionProductoJ> GetByProducto(int idProducto);
        void Create(UbicacionProductoJ ubicacionProductoJ);
        void Update(UbicacionProductoJ ubicacionProductoJ);
        void Delete(UbicacionProductoJ ubicacionProductoJ);

        bool SaveChanges();
    }
}
