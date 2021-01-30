using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCompraProductoRepo : ICompraProductoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCompraProductoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las CompraProducto de la base de datos.
         */
        public IEnumerable<CompraProducto> GetAll()
        {
            return _context.CompraProducto.ToList();
        }

        /*
         * Retorna una sola CompraProducto por su id.
         */
        public CompraProducto GetById(int id)
        {
            return _context.CompraProducto.FirstOrDefault(cp => cp.idCompraProducto == id);
        }

        /*
         * Retorna una lista de CompraProducto del Comprador especificado.
         */
        public IEnumerable<CompraProducto> GetByComprador(int idComprador)
        {
            //Se obtienen todas las CompraProducto
            IEnumerable<CompraProducto> compraProductoItems = GetAll();

            //Se crea una nueva lista donde se dejaran las CompraProducto especificas
            List<CompraProducto> compraProductoByComprador = new List<CompraProducto>();

            //Se iterara sobre todas las CompraProductos y quedaran solo los de un Comprador especifico
            for (int i = 0; i < compraProductoItems.Count(); i++)
            {
                //Revisa que se cumpla el idComprador
                if (compraProductoItems.ElementAt(i).idComprador == idComprador)
                {
                    compraProductoByComprador.Add(compraProductoItems.ElementAt(i));
                }
            }

            return compraProductoByComprador;
        }

        public IEnumerable<CompraProducto> GetByProducto(int idProducto)
        {
            //Se obtienen todas las CompraProducto
            IEnumerable<CompraProducto> compraProductoItems = GetAll();

            //Se crea una nueva lista donde se dejaran las CompraProducto especificas
            List<CompraProducto> compraProductoByProducto = new List<CompraProducto>();

            //Se iterara sobre todas las CompraProductos y quedaran solo los de un Producto especifico
            for (int i = 0; i < compraProductoItems.Count(); i++)
            {
                //Revisa que se cumpla el idProducto
                if (compraProductoItems.ElementAt(i).idProducto == idProducto)
                {
                    compraProductoByProducto.Add(compraProductoItems.ElementAt(i));
                }
            }

            return compraProductoByProducto;
        }

        /*
         * Retorna el idCompraProducto de una CompraProducto especifica.
         */
        public int GetId(int idProducto, int idComprador)
        {
            //Se obtiene la CompraProducto
            CompraProducto compraProductoItem = _context.CompraProducto.FirstOrDefault(cp => cp.idProducto == idProducto && cp.idComprador == idComprador);

            //Se verifica que la CompraProducto exista
            if (compraProductoItem != null)
            {
                //Si existe, se retorna el idCompraProducto deseado
                return compraProductoItem.idCompraProducto;
            }

            //Si no existe, se retorna un -1
            return -1;
        }

        /*
         * Ingresa a la base de datos una nueva CompraProducto.
         */
        public void Create(CompraProducto compraProducto)
        {
            //Se verifica si la CompraProducto existe
            if (compraProducto == null)
            {
                throw new ArgumentNullException(nameof(compraProducto));
            }

            //Se crea la CompraProducto en la base de datos por medio del context
            _context.CompraProducto.Add(compraProducto);
        }

        /*
         * Actualiza los datos de una CompraProducto en la base de datos.
         */
        public void Update(CompraProducto compraProducto)
        {
            //De esto se encarga el DbContext
        }

        public void Delete(CompraProducto compraProducto)
        {
            throw new NotImplementedException();
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
