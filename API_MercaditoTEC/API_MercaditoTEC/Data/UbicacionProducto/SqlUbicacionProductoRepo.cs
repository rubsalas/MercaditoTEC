using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlUbicacionProductoRepo : IUbicacionProductoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlUbicacionProductoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las UbicacionProducto de la base de datos.
         */
        public IEnumerable<UbicacionProducto> GetAll()
        {
            //Se retorna una lista de todas las UbicacionProducto.
            return _context.UbicacionProducto.ToList();
        }

        /*
         * Retorna una sola UbicacionProducto por su id.
         */
        public UbicacionProducto GetById(int id)
        {
            return _context.UbicacionProducto.FirstOrDefault(up => up.idUbicacionProducto == id);
        }

        /*
         * Retorna una lista de UbicacionProducto de un unico Producto indicado.
         */
        public IEnumerable<UbicacionProducto> GetByProducto(int idProducto)
        {
            //Se obtienen todas las UbicacionProducto
            IEnumerable<UbicacionProducto> ubicacionProductoItems = GetAll();

            //Se crea una nueva lista donde se dejaran las UbicacionProducto especificas
            List<UbicacionProducto> ubicacionProductoEspecificas = new List<UbicacionProducto>();

            for (int i = 0; i < ubicacionProductoItems.Count(); i++)
            {
                //Se obtiene de la lista de UbicacionProducto los que correspondan al idProducto indicado
                if (ubicacionProductoItems.ElementAt(i).idProducto == idProducto)
                {
                    ubicacionProductoEspecificas.Add(ubicacionProductoItems.ElementAt(i));
                }
            }

            return ubicacionProductoEspecificas;
        }

        /*
         * Ingresa a la base de datos una nueva UbicacionProducto.
         */
        public void Create(UbicacionProducto ubicacionProducto)
        {
            //Se verifica si existe
            if (ubicacionProducto == null)
            {
                throw new ArgumentNullException(nameof(ubicacionProducto));
            }

            //Se crea en la base de datos por medio del context
            _context.UbicacionProducto.Add(ubicacionProducto);
        }

        public void Update(UbicacionProducto ubicacionProducto)
        {
            throw new NotImplementedException();
        }

        public void Delete(UbicacionProducto ubicacionProducto)
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
