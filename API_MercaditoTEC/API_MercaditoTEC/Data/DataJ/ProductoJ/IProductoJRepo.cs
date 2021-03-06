﻿using API_MercaditoTEC.Models.ModelsJ;
using System.Collections.Generic;

namespace API_MercaditoTEC.Data.DataJ
{
    public interface IProductoJRepo
    {
        IEnumerable<ProductoJ> GetAll();
        IEnumerable<ProductoJ> GetOrderedByPrecio();
        ProductoJ GetById(int id);
        int GetId(string nombre, int idVendedor);
        IEnumerable<ProductoJ> GetByCategoria(int idCategoria);
        IEnumerable<ProductoJ> GetByCategoriaOrderedByPrecio(int idCategoria);
        IEnumerable<ProductoJ> GetByEstudiante(int idEstudiante);
        void Create(ProductoJ productoJ);
        void Update(ProductoJ productoJ);
        void Delete(ProductoJ productoJ);

        bool SaveChanges();
    }
}
