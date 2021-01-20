using API_MercaditoTEC.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_MercaditoTEC.Data
{
    public class SqlCantonRepo : ICantonRepo
    {
        private readonly MercaditoTECContext _context;

        public SqlCantonRepo(MercaditoTECContext context)
        {
            _context = context;
        }

        /*
         * Retorna todos los Cantones de la base de datos.
         */
        public IEnumerable<Canton> GetAll()
        {
            //Se retorna una lista de todos los Cantones.
            return _context.Canton.ToList();
        }

        /*
         * Retorna un solo Canton por su id.
         */
        public Canton GetById(int id)
        {
            return _context.Canton.FirstOrDefault(c => c.idCanton == id);
        }

        /*
         * Retorna el Canton con el nombre indicado.
         */
        public Canton GetByNombre(string nombre)
        {
            return _context.Canton.FirstOrDefault(c => c.nombre == nombre);
        }

        /*
         * Retorna el idCanton de un Canton especifico.
         */
        public int GetId(string nombre)
        {
            return _context.Canton.FirstOrDefault(c => c.nombre == nombre).idCanton;
        }
    }
}
