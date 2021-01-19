using API_MercaditoTEC.Models;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data
{
    public interface IImagenProductoRepo
    {
        IEnumerable<ImagenProducto> GetAll();
        ImagenProducto GetById(int id);
        IEnumerable<ImagenProducto> GetByProducto(int idProducto);
        void Create(ImagenProducto imagenProducto);
        void Update(ImagenProducto imagenProducto);
        void Delete(ImagenProducto imagenProducto);

        bool SaveChanges();
    }
}
