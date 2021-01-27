using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlProductoRepo : IProductoRepo
    {
        private readonly MercaditoTECContext _context;
        private readonly IVendedorRepo _vendedorJRepo;

        public SqlProductoRepo(MercaditoTECContext context, IVendedorRepo vendedorJRepo)
        {
            _context = context;
            _vendedorJRepo = vendedorJRepo;
        }

        /*
         * Retorna todos los Productos de la base de datos.
         */
        public IEnumerable<Producto> GetAll()
        {
            //Se retorna una lista de todos los Productos.
            return _context.Producto.ToList();
        }

        /*
         * Retorna un solo Producto por su id.
         */
        public Producto GetById(int id)
        {
            return _context.Producto.FirstOrDefault(p => p.idProducto == id);
        }

        /*
         * Retorna el Producto con el nombre indicado.
         */
        public Producto GetByNombre(string nombre)
        {
            //Se retorna el Producto especificado
            return _context.Producto.FirstOrDefault(p => p.nombre == nombre);
        }

        /*
         * Retorna una lista de Productos de la Categoria especificada.
         */
        public IEnumerable<Producto> GetByCategoria(int idCategoria)
        {
            //Se obtienen todos los Productos
            IEnumerable<Producto> productoItems = GetAll();

            //Se crea una nueva lista donde se dejaran los Productos especificos
            List<Producto> productosByCategoria = new List<Producto>();

            //Se iterara sobre todos los productos y quedaran solo los de una Categoria especifica
            for (int i = 0; i < productoItems.Count(); i++)
            {
                //Revisa que se cumpla el idCategoria
                if (productoItems.ElementAt(i).idCategoria == idCategoria)
                {
                    productosByCategoria.Add(productoItems.ElementAt(i));
                }
            }

            return productosByCategoria;
        }

        /*
         * Retorna una lista de Productos del Estudiante especificado.
         */
        public IEnumerable<Producto> GetByEstudiante(int idEstudiante)
        {
            //Se obtienen todos los Productos
            IEnumerable<Producto> productoItems = GetAll();

            //Se crea una nueva lista donde se dejaran los Productos especificos
            List<Producto> productosByEstudiante = new List<Producto>();

            //Se iterara sobre todos los productos y quedaran solo los de un Estudiante especifico
            for (int i = 0; i < productoItems.Count(); i++)
            {
                int idVendedor = _vendedorJRepo.GetId(idEstudiante);

                //Revisa que se cumpla el idVendedor
                if (productoItems.ElementAt(i).idVendedor == idVendedor)
                {
                    productosByEstudiante.Add(productoItems.ElementAt(i));
                }
            }

            return productosByEstudiante;
        }

        /*
         * Retorna el idProducto de un Producto especifico.
         */
        public int GetId(string nombre, int idVendedor)
        {
            //Se obtiene el idProducto de un Producto especifico
            int idProducto = _context.Producto.FirstOrDefault(p => p.nombre == nombre && p.idVendedor == idVendedor).idProducto;

            //Se verifica que el Producto exista
            if (idProducto > 0)
            {
                //Si existe, se retorna el idProducto
                return idProducto;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        /*
         * Ingresa a la base de datos un nuevo Producto.
         */
        public void Create(Producto producto)
        {
            //Se verifica si el Producto existe
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            //Se crea el Producto en la base de datos por medio del context
            _context.Producto.Add(producto);
        }

        /*
         * Actualiza los datos de un Producto en la base de datos.
         */
        public void Update(Producto producto)
        {
            //De esto se encarga el DbContext
        }

        /*
         * Elimina los datos de un Producto en la base de datos.
         */
        public void Delete(Producto producto)
        {
            //Se verifica si el Producto existe
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            //Se elimina el Producot de la base de datos por medio del context
            _context.Producto.Remove(producto);
        }

        /*
         * Guarda los cambios en la Base de Datos de SQLServer.
         */
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
