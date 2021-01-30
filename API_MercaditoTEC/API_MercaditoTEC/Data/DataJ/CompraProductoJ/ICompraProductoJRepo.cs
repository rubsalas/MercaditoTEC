using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface ICompraProductoJRepo
    {
        IEnumerable<CompraProductoJ> GetAll();
        CompraProductoJ GetById(int id);
        IEnumerable<CompraProductoJ> GetByComprador(int idComprador);
        IEnumerable<CompraProductoJ> GetByProducto(int idProducto);
        IEnumerable<CompraProductoJ> GetByVendedor(int idVendedor);
        int GetId(int idProducto, int idComprador);
        void Create(CompraProductoJ compraProductoJ);
        void Update(CompraProductoJ compraProductoJ);
        void Delete(CompraProductoJ compraProductoJ);

        bool SaveChanges();
    }
}
