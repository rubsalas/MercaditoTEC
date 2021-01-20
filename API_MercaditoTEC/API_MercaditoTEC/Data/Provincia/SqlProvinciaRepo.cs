using API_MercaditoTEC.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlProvinciaRepo : IProvinciaRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlProvinciaRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todas las Provincias de la base de datos.
         */
        public IEnumerable<Provincia> GetAll()
        {
            //Se retorna una lista de todas las Provincias.
            return _context.Provincia.ToList();
        }

        /*
         * Retorna una sola Provincia por su id.
         */
        public Provincia GetById(int id)
        {
            return _context.Provincia.FirstOrDefault(p => p.idProvincia == id);
        }

        /*
         * Retorna la Provincia con el nombre indicado.
         */
        public Provincia GetByNombre(string nombre)
        {
            //Se retorna la Provincia especifica
            return _context.Provincia.FirstOrDefault(p => p.nombre == nombre);
        }

        /*
         * Retorna el idProvincia de una Provincia especifica.
         */
        public int GetId(string nombre)
        {
            return _context.Provincia.FirstOrDefault(p => p.nombre == nombre).idProvincia;
        }
    }
}
