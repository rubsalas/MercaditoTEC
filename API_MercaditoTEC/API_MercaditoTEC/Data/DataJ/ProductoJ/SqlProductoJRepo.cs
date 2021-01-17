using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data.DataJ
{
    public class SqlProductoJRepo : IProductoJRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IProductoRepo _productoRepo;
        private readonly IMapper _mapper;

        public SqlProductoJRepo(MercaditoTECContext context, IProductoRepo productoRepo, IMapper mapper)
        {
            _context = context;
            _productoRepo = productoRepo;
            _mapper = mapper;
        }

        public IEnumerable<ProductoJ> GetAll()
        {
            //Mappeo de Productos

            //Se retorna una lista de todos los Productos
            IEnumerable<Producto> productosItems = _productoRepo.GetAll();

            //Se mappea la parte de Producto al ProductoJ
            IEnumerable<ProductoJ> productoJItems = _mapper.Map<IEnumerable<ProductoJ>>(productosItems);

            /*
             * Iteracion para mappear demas atributos a productosJItems
             */

            return productoJItems.ToList();

        }

        /*
         * Retorna un Producto con la informacion de Producto, ....
         */
        public ProductoJ GetById(int id)
        {
            //Mappeo de Producto

            //Se retorna un Producto especifico
            Producto productoItem = _context.Producto.FirstOrDefault(p => p.idProducto == id);

            //Se mappea la parte de Estudiante al EstudianteJ
            ProductoJ productoJItem = _mapper.Map<ProductoJ>(productoItem);

            /*
             * Mappear demas atributos a produtoJItem
             */

            return productoJItem;
        }

        public int GetId(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Create(ProductoJ productoJ)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductoJ productoJ)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductoJ productoJ)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        
    }
}
