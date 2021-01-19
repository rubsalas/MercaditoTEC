using API_MercaditoTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlImagenProductoRepo : IImagenProductoRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlImagenProductoRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las ImagenProducto de la base de datos.
         */
        public IEnumerable<ImagenProducto> GetAll()
        {
            //Se retorna una lista de todos los ImagenProducto.
            return _context.ImagenProducto.ToList();
        }

        /*
         * Retorna una sola ImagenProducto por su id.
         */
        public ImagenProducto GetById(int id)
        {
            return _context.ImagenProducto.FirstOrDefault(ip => ip.idImagenProducto == id);
        }

        /*
         * Retorna una lista de ImagenProducto de un unico Producto indicado.
         */
        public IEnumerable<ImagenProducto> GetByProducto(int idProducto)
        {
            //Se obtienen todas las ImagenProducto
            IEnumerable<ImagenProducto> imagenProducto = GetAll();

            //Se crea una nueva lista donde se dejaran las ImagenProducto especificas
            List<ImagenProducto> imagenProductoEspecificas = new List<ImagenProducto>();

            for (int i = 0; i < imagenProducto.Count(); i++)
            {
                //Se obtiene de la lista de ImagenProducto las que correspondan al idProducto indicado
                if (imagenProducto.ElementAt(i).idProducto == idProducto)
                {
                    imagenProductoEspecificas.Add(imagenProducto.ElementAt(i));
                }
            }

            return imagenProductoEspecificas;
        }

        public void Create(ImagenProducto imagenProducto)
        {
            throw new NotImplementedException();
        }

        public void Update(ImagenProducto imagenProducto)
        {
            throw new NotImplementedException();
        }

        public void Delete(ImagenProducto imagenProducto)
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
