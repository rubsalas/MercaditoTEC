using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IProductoJRepo
    {
        IEnumerable<ProductoJ> GetAll();
        ProductoJ GetById(int id);
        int GetId(string nombre);
        void Create(ProductoJ productoJ);
        void Update(ProductoJ productoJ);
        void Delete(ProductoJ productoJ);

        bool SaveChanges();
    }
}
