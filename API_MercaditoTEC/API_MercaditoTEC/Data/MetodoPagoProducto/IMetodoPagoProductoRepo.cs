using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IMetodoPagoProductoRepo
    {
        IEnumerable<MetodoPagoProducto> GetAll();
        MetodoPagoProducto GetById(int id);
        IEnumerable<MetodoPagoProducto> GetByProducto(int idProducto);
        //int GetId(int idEstudiante);
        void Create(MetodoPagoProducto metodoPagoProducto);
        void Update(MetodoPagoProducto metodoPagoProducto);
        void Delete(MetodoPagoProducto metodoPagoProducto);

        bool SaveChanges();
    }
}
