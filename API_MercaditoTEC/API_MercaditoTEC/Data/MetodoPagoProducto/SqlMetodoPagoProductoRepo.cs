using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlMetodoPagoProductoRepo : IMetodoPagoProductoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlMetodoPagoProductoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los MetodoPagoProducto de la base de datos.
         */
        public IEnumerable<MetodoPagoProducto> GetAll()
        {
            //Se retorna una lista de todos los MetodoPagoProducto.
            return _context.MetodoPagoProducto.ToList();
        }

        /*
         * Retorna un solo MetodoPagoProducto por su id.
         */
        public MetodoPagoProducto GetById(int id)
        {
            return _context.MetodoPagoProducto.FirstOrDefault(mpp => mpp.idMetodoPagoProducto == id);
        }

        /*
         * Retorna una lista de MetodoPagoProducto de un unico Producto indicado.
         */
        public IEnumerable<MetodoPagoProducto> GetByProducto(int idProducto)
        {
            //Se obtienen todos los MetodoPagoProducto
            IEnumerable<MetodoPagoProducto> metodoPagoProducto = GetAll();

            //Se crea una nueva lista donde se dejaran los MetodoPagoProducto especificos
            List<MetodoPagoProducto> metodoPagoProductoEspecifico = new List<MetodoPagoProducto>();

            for (int i = 0; i < metodoPagoProducto.Count(); i++)
            {
                //Se obtiene de la lista de MetodoPagoProducto los que correspondan al idProducto indicado
                if (metodoPagoProducto.ElementAt(i).idProducto == idProducto)
                {
                    metodoPagoProductoEspecifico.Add(metodoPagoProducto.ElementAt(i));
                }
            }

            return metodoPagoProductoEspecifico;
        }

        public void Create(MetodoPagoProducto metodoPagoProducto)
        {
            throw new NotImplementedException();
        }

        public void Update(MetodoPagoProducto metodoPagoProducto)
        {
            throw new NotImplementedException();
        }

        public void Delete(MetodoPagoProducto metodoPagoProducto)
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
