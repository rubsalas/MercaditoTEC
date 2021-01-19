using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IMetodoPagoProductoJRepo
    {
        IEnumerable<MetodoPagoProductoJ> GetAll();
        MetodoPagoProductoJ GetById(int id);
        IEnumerable<MetodoPagoProductoJ> GetByProducto(int idProducto);
        void Create(MetodoPagoProductoJ metodoPagoProductoJ);
        void Update(MetodoPagoProductoJ metodoPagoProductoJ);
        void Delete(MetodoPagoProductoJ metodoPagoProductoJ);

        bool SaveChanges();
    }
}
