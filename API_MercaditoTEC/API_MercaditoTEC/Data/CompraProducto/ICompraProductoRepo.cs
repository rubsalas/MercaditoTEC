using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface ICompraProductoRepo
    {
        IEnumerable<CompraProducto> GetAll();
        CompraProducto GetById(int id);
        IEnumerable<CompraProducto> GetByComprador(int idComprador);
        IEnumerable<CompraProducto> GetByProducto(int idProducto); //Puede que no
        IEnumerable<CompraProducto> GetByVendedor(int idVendedor);
        int GetId(int idProducto, int idComprador);
        void Create(CompraProducto compraProducto);
        void Update(CompraProducto compraProducto);
        void Delete(CompraProducto compraProducto);

        bool SaveChanges();
    }
}
